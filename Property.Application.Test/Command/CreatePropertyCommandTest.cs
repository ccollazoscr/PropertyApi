using MediatR;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using Property.Model.Model;

namespace Property.Application.Test.Command
{
    public class CreatePropertyCommandTest
    {
        [Test]
        public void CreatePropertyCommand_ImplementIRequest_GetInterface()
        {
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(null);
            bool IsIRequestInterface = oCreatePropertyCommand is IRequest<CreatePropertyDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void CreatePropertyCommand_SetNullProperty_GetNullProperty()
        {
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(null);
            Assert.That(oCreatePropertyCommand.Property, Is.EqualTo(null));
        }

        [Test]
        public void CreatePropertyCommand_SetProperty_GetValidIdProperty()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding() { Id = 1 };
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(oPropertyBuilding);
            Assert.That(oCreatePropertyCommand.Property.Id, Is.EqualTo(1));
        }
    }
}
