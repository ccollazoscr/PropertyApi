using MediatR;
using Microsoft.AspNetCore.Mvc;
using Property.Api.Filter;
using Property.Application.Command;
using Property.Application.Query;
using Property.Common.Converter;
using Property.Model.Dto;
using Property.Model.Model;
using PropertyApi.EntryModel;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace PropertyApi.Controller.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        IMediator _mediator;
        private IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> _converterToModel;
        private IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding> _converterUpdateToModel;
        private IEntryModelConverter<GetListPropertyEntryModel, PropertyBuilding> _converterGetListToModel;
        public PropertyController(IMediator mediator, 
            IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> converterToModel, 
            IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding> converterUpdateToModel,
            IEntryModelConverter<GetListPropertyEntryModel, PropertyBuilding> converterGetListToModel
            )
        {
            _converterToModel = converterToModel;
            _converterUpdateToModel = converterUpdateToModel;
            _converterGetListToModel = converterGetListToModel;
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
            return Ok(oResponseDto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetListPropertyDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetListAsync([FromBody] GetListPropertyEntryModel oGetListEntryModel)
        {
            PropertyBuilding oProperty = _converterGetListToModel.FromEntryModelToModel(oGetListEntryModel);
            GetListPropertyQuery oUpdatePropertyCommand = new GetListPropertyQuery(oProperty);
            List<GetListPropertyDto> oListResponse = await _mediator.Send(oUpdatePropertyCommand);
            return Ok(oListResponse);
        }
    }
}
