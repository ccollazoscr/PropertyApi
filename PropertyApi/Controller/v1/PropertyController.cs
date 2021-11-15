using MediatR;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Command;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.EntryModel;
using System.Net;
using System.Threading.Tasks;


namespace PropertyApi.Controller.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        IMediator _mediator;
        private IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> _converterToModel;

        public PropertyController(IMediator mediator, IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> converterToModel)
        {
            _converterToModel = converterToModel;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatePropertyEntryModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePropertyAsync([FromBody] CreatePropertyEntryModel oCreatePropertyEntryModel)
        {
            PropertyBuilding oProperty = _converterToModel.FromEntryModelToModel(oCreatePropertyEntryModel);
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(oProperty);
            PropertyBuilding oResPropertyBuilding = await _mediator.Send(oCreatePropertyCommand);
            oCreatePropertyEntryModel.Id = oResPropertyBuilding.Id;
            return Created(string.Empty, oCreatePropertyEntryModel);
        }
    }
}
