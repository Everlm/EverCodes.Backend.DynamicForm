using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData;
using Microsoft.AspNetCore.Mvc;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Controllers
{
    [ApiController]
    [Route("api/dynamic-forms")]
    public class DynamicFormController : ControllerBase
    {
        [HttpGet("sample")]
        public ActionResult<FormlyForm> GetSampleForm()
        {
            var form = SeedFormData.BuildDynamicForm();

            if (form is null)
            {
                return NotFound();
            }
            return Ok(form);
        }
    }
}