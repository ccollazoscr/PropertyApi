using Property.Model.Dto;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.Service
{
    public interface ISecurityService
    {
        public Task<TokenResultDto> ValidateToken(string token);
    }
}
