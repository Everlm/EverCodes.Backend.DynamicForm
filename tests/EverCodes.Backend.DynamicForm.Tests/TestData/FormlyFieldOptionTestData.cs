using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.TestData
{
    public class FormlyFieldOptionTestData
    {
        public static FormlyFieldOption CreateAdminOption()
        {
            return new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = "admin",
                Label = "Administrator"
            };
        }

        public static FormlyFieldOption CreateUserOption()
        {
            return new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = "user",
                Label = "User"
            };
        }

        public static FormlyFieldOption CreateGuestOption()
        {
            return new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = "guest",
                Label = "Guest"
            };
        }

        public static List<FormlyFieldOption> CreateRoleOptions()
        {
            return new List<FormlyFieldOption>
            {
                CreateAdminOption(),
                CreateUserOption(),
                CreateGuestOption()
            };
        }

        public static List<FormlyFieldOption> CreateCountryOptions()
        {
            return new List<FormlyFieldOption>
            {
                new FormlyFieldOption { Id = Guid.NewGuid(), Value = "us", Label = "United States" },
                new FormlyFieldOption { Id = Guid.NewGuid(), Value = "mx", Label = "Mexico" },
                new FormlyFieldOption { Id = Guid.NewGuid(), Value = "ca", Label = "Canada" }
            };
        }

        public static List<FormlyFieldOption> CreateStatusOptions()
        {
            return new List<FormlyFieldOption>
            {
                new FormlyFieldOption { Id = Guid.NewGuid(), Value = "active", Label = "Active" },
                new FormlyFieldOption { Id = Guid.NewGuid(), Value = "inactive", Label = "Inactive" },
                new FormlyFieldOption { Id = Guid.NewGuid(), Value = "pending", Label = "Pending" }
            };
        }


    }
}