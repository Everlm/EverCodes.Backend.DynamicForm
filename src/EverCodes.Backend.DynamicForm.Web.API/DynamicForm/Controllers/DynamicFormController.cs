using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.DTOs;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Mappers;
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

        [HttpGet("sample-dto")]
        public ActionResult<FormlyFormDto> GetSampleFormDto()
        {
            var form = SeedFormData.BuildDynamicForm();

            if (form is null)
            {
                return NotFound();
            }

            var formDto = FormlyMapper.ToDto(form);
            return Ok(formDto);
        }
    }
}