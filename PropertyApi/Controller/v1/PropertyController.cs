using Microsoft.AspNetCore.Mvc;
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

        private IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> _converterToModel;

        public PropertyController(IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding> converterToModel) {
            _converterToModel = converterToModel;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatePropertyEntryModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePropertyAsync([FromBody] CreatePropertyEntryModel oCreatePropertyEntryModel)
        {
            PropertyBuilding oProperty = _converterToModel.FromEntryModelToModel(oCreatePropertyEntryModel);
            oProperty.Id = 1000;
            var res = _converterToModel.FromModelToEntryModel(oProperty);
            return Created(string.Empty, res);
        }
    }
}
