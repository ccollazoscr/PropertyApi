using MediatR;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using Property.Model.Model;

namespace Property.Application.Test.Command
{
    public class UpdatePropertyCommandTest
    {
        [Test]
        public void UpdatePropertyCommand_ImplementIRequest_GetInterface()
        {
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(null);
            bool IsIRequestInterface = oUpdatePropertyCommand is IRequest<ResponseDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void UpdatePropertyCommand_SetNullProperty_GetNullProperty()
        {
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(null);
            Assert.That(oUpdatePropertyCommand.Property, Is.EqualTo(null));
        }

        [Test]
        public void UpdatePropertyCommand_SetProperty_GetValidIdProperty()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding() { Id = 1 };
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(oPropertyBuilding);
            Assert.That(oUpdatePropertyCommand.Property.Id, Is.EqualTo(1));
        }
    }
}
