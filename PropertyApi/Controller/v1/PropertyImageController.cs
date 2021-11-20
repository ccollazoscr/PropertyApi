using MediatR;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Command;
using Property.Model.Dto;
using PropertyApi.EntryModel;
using System.Net;
using System.Threading.Tasks;

namespace PropertyApi.Controller.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        IMediator _mediator;

        public PropertyImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatePropertyImageDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePropertyAsync([FromForm] CreatePropertyImageEntryModel oCreatePropertyEntryModel)
        {
            CreatePropertyImageCommand oCreatePropertyCommand = new CreatePropertyImageCommand()
                                                                    .SetIdProperty(oCreatePropertyEntryModel.IdProperty)
                                                                    .SetFile(oCreatePropertyEntryModel.File)
                                                                    .SetEnabled(oCreatePropertyEntryModel.Enabled);
            CreatePropertyImageDto oResCreatePropertyImageDto = await _mediator.Send(oCreatePropertyCommand);
            //TODO: Response
            return Created(string.Empty, oResCreatePropertyImageDto);
        }
    }
}
