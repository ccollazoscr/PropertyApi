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
    public class OwnerController : ControllerBase
    {
        IMediator _mediator;
        public OwnerController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateOwnerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePropertyAsync([FromForm] CreateOwnerEntryModel oCreateOwnerEntryModel)
        {
            CreateOwnerCommand oCreateOwnerCommand = new CreateOwnerCommand()
                                                            .SetName(oCreateOwnerEntryModel.Name)
                                                            .SetAddress(oCreateOwnerEntryModel.Address)
                                                            .SetPhoto(oCreateOwnerEntryModel.Photo)
                                                            .SetBirthday(oCreateOwnerEntryModel.Birthday);

            CreateOwnerDto oCreateOwnerDto = await _mediator.Send(oCreateOwnerCommand);
            return Created(string.Empty, oCreateOwnerDto);
        }

    }
}
