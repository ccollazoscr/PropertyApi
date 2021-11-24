using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Property.Common.Configuration;
using Property.Infraestructure.Adapter.Service;
using Property.Model.Dto;
using System.Threading.Tasks;

namespace Property.Api.Filter
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof(AuthorizeFilter))
        {
        }
    }

    public class AuthorizeFilter : IAsyncAuthorizationFilter
    {
        private ISecurityService _securityService { get; }
        private IGeneralSettings _generalSettings { get; }


        public AuthorizeFilter(ISecurityService securityService, IGeneralSettings generalSettings)
        {
            _securityService = securityService;
            _generalSettings = generalSettings;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!_generalSettings.GetEnabledSecurity())
                return;

            var token = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                TokenResultDto oTokenResultDto = await _securityService.ValidateToken(token);
                if (oTokenResultDto == null)
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    context.HttpContext.Items.Add("Name", oTokenResultDto.Name);
                    context.HttpContext.Items.Add("Code", oTokenResultDto.Code);
                    context.HttpContext.Items.Add("UserName", oTokenResultDto.UserName);
                }
            }
        }
    }
}
