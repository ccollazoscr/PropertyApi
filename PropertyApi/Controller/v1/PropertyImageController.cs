using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Command;
using Property.Application.Dto;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.Converter;
using PropertyApi.EntryModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
