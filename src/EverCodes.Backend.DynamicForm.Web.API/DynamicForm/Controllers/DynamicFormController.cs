using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData;
using Microsoft.AspNetCore.Mvc;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DynamicFormController : ControllerBase
    {

        [HttpGet("get-form-definition")]
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