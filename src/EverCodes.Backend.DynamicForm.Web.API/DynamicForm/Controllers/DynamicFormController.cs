using Microsoft.AspNetCore.Mvc;
using src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos;
using src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData;

namespace src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DynamicFormController : ControllerBase
    {

        [HttpGet]
        public ActionResult<FormDefinitionDto> GetFormDefinition()
        {
            var form = DynamicFormData.GetFormDefinitionMockData();

            if (form is null)
            {
                return NotFound();
            }
            return Ok(form);
        }
    }
}