using Property.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Property.Model.Dto;

namespace Property.Infraestructure.Adapter.Service
{
    public class SecurityService : ISecurityService
    {
        private IGeneralSettings _generalSettings;
        public SecurityService(IGeneralSettings generalSettings) {
            _generalSettings = generalSettings;
        }
        public async Task<TokenResultDto> ValidateToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", "");
                string urlValidateToken = $"{_generalSettings.GetSecurityServiceUrl()}/api/token/validatetoken?token={token}";
                TokenResultDto oTokenResultDto = await urlValidateToken.GetJsonAsync<TokenResultDto>();
                return oTokenResultDto;
            }
            catch
            {
            }
            return null;
        }
    }
}
