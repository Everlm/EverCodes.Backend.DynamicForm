using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.TestData
{
    public class FormlyFormTestData
    {
        public static FormlyForm CreateFormlyFormData(Guid formlyFormId)
        {
            return new FormlyForm
            {
                Id = formlyFormId,
                Name = "Test Form",
                Description = $"Description for Test Form",
                Fields = new List<FormlyFieldConfig>()
            };
        }

        public static FormlyForm CreateSampleFormlyFormData()
        {
            var formlyFormId = Guid.NewGuid();
            return new FormlyForm
            {
                Id = formlyFormId,
                Name = "Test Form",
                Description = $"Description for Test Form",
                Fields = new List<FormlyFieldConfig>()
            };
        }
        public static FormlyForm CreateFormlyFormWhitFieldsData()
        {
            return new FormlyForm
            {
                Id = Guid.NewGuid(),
                Name = "Test Form",
                Description = $"Description for Test Form",
                Fields = FormlyFieldConfigTestData.CreateBasicFormFields()
            };
        }
    }
}