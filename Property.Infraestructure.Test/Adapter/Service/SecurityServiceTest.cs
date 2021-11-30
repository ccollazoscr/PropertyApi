using Flurl.Http.Testing;
using Moq;
using NUnit.Framework;
using Property.Common.Configuration;
using Property.Infraestructure.Adapter.Service;
using Property.Model.Dto;
using System.Threading.Tasks;

namespace Property.Infraestructure.Test.Adapter.Service
{
    public class SecurityServiceTest
    {
        private Mock<IGeneralSettings> _mockGeneralSettings;
        private SecurityService oSecurityService;
        private HttpTest _httpTest;
        [SetUp]
        public void Setup()
        {
            _mockGeneralSettings = new Mock<IGeneralSettings>();
            oSecurityService = new SecurityService(_mockGeneralSettings.Object);
            _httpTest = new HttpTest();
        }

        [Test]
        public void SecurityService_ImplementISecurityService_GetInterface()
        {
            bool IsIRequestInterface = oSecurityService is ISecurityService;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public async Task ValidateToken_SetValidToken_GetTokenResultDtoAsync()
        {
            TokenResultDto oParamTokenResultDto = new TokenResultDto() { Code = "Code", Name = "Name", UserName = "UserName" };
            _mockGeneralSettings.Setup(m => m.GetSecurityServiceUrl()).Returns("http://localhost/");
            _httpTest.RespondWithJson(oParamTokenResultDto);
            TokenResultDto oTokenResultDto = await oSecurityService.ValidateToken("abc.abc.abc");
            Assert.AreEqual(oParamTokenResultDto.Code, oTokenResultDto.Code);
            Assert.AreEqual(oParamTokenResultDto.Name, oTokenResultDto.Name);
            Assert.AreEqual(oParamTokenResultDto.UserName, oTokenResultDto.UserName);
        }
    }
}
