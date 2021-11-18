using MediatR;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Command;
using Property.Application.Dto;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.EntryModel;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace PropertyApi.Controller.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        IMediator _mediator;
        private IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> _converterToModel;
        private IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding> _converterUpdateToModel;

        public PropertyController(IMediator mediator, 
            IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> converterToModel, 
            IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding> converterUpdateToModel)
        {
            _converterToModel = converterToModel;
            _converterUpdateToModel = converterUpdateToModel;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatePropertyDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePropertyAsync([FromBody] CreatePropertyEntryModel oCreatePropertyEntryModel)
        {
            PropertyBuilding oProperty = _converterToModel.FromEntryModelToModel(oCreatePropertyEntryModel);
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(oProperty);
            CreatePropertyDto oCreatePropertyDto = await _mediator.Send(oCreatePropertyCommand);
            return Created(string.Empty, oCreatePropertyDto);
        }

        [HttpPatch("updateprice")]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePrice([FromBody] UpdatePriceEntryModel oUpdatePriceEntryModel)
        {
            UpdatePriceCommand oUpdatePriceCommand = new UpdatePriceCommand().SetId(oUpdatePriceEntryModel.Id).SetPrice(oUpdatePriceEntryModel.Price);
            ResponseDto oResponseDto = await _mediator.Send(oUpdatePriceCommand);
            return Ok(JsonSerializer.Serialize(oResponseDto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePropertyAsync([FromBody] UpdatePropertyEntryModel oUpdatePropertyEntryModel)
        {
            PropertyBuilding oProperty = _converterUpdateToModel.FromEntryModelToModel(oUpdatePropertyEntryModel);
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(oProperty);
            ResponseDto oResponseDto = await _mediator.Send(oUpdatePropertyCommand);
            return Created(string.Empty, oResponseDto);
        }
    }
}
