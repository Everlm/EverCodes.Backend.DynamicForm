using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.TestData
{
    /// <summary>
    /// Clase para crear datos reutilizables de prueba para los tests
    /// </summary>
    public static class FormlyTestDataBuilder
    {


        /// <summary>
        /// Crea un formulario básico vacío
        /// </summary>
        public static FormlyForm CreateEmptyForm(string name = "Test Form")
        {
            return new FormlyForm
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = $"Description for {name}",
                Fields = new List<FormlyFieldConfig>()
            };
        }

        /// <summary>
        /// Crea un formulario completo con campos de ejemplo
        /// </summary>
        public static FormlyForm CreateCompleteForm()
        {
            var form = CreateEmptyForm("Complete Test Form");
            form.Fields.Add(CreateSimpleInputField(form.Id, "name", "Name"));
            form.Fields.Add(CreateEmailField(form.Id, "email", "Email"));
            form.Fields.Add(CreateSelectField(form.Id, "role", "Role"));
            return form;
        }





        /// <summary>
        /// Crea un campo simple sin padre (campo raíz)
        /// </summary>
        public static FormlyFieldConfig CreateSimpleField(Guid formId, string key, string type = "input")
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = key,
                Type = type,
                ParentId = null,
                FormlyFormId = formId,
                FieldGroup = new List<FormlyFieldConfig>()
            };
        }

        /// <summary>
        /// Crea un campo de entrada de texto básico con Props
        /// </summary>
        public static FormlyFieldConfig CreateSimpleInputField(
            Guid formId,
            string key,
            string label,
            bool required = false,
            string placeholder = "")
        {
            var field = CreateSimpleField(formId, key, "input");
            field.Props = CreateBasicProps(label, "text", required, placeholder);
            return field;
        }

        /// <summary>
        /// Crea un campo de email con validación
        /// </summary>
        public static FormlyFieldConfig CreateEmailField(
            Guid formId,
            string key,
            string label,
            bool required = true)
        {
            var field = CreateSimpleField(formId, key, "input");
            field.Props = CreateBasicProps(label, "email", required, "usuario@ejemplo.com");
            field.Validation = CreateEmailValidation(required);
            return field;
        }

        /// <summary>
        /// Crea un campo de contraseña con validación
        /// </summary>
        public static FormlyFieldConfig CreatePasswordField(
            Guid formId,
            string key,
            string label,
            int minLength = 6,
            int maxLength = 20,
            bool required = true)
        {
            var field = CreateSimpleField(formId, key, "input");
            field.Props = new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Label = label,
                Type = "password",
                Required = required,
                MinLength = minLength,
                MaxLength = maxLength,
                Placeholder = "Ingrese su contraseña",
                Appearance = "outline"
            };
            field.Validation = CreatePasswordValidation(minLength, maxLength, required);
            return field;
        }

        /// <summary>
        /// Crea un campo select con opciones
        /// </summary>
        public static FormlyFieldConfig CreateSelectField(
            Guid formId,
            string key,
            string label,
            List<(string value, string label)>? options = null)
        {
            var field = CreateSimpleField(formId, key, "select");
            field.Props = new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Label = label,
                Required = false,
                Appearance = "outline",
                Options = options != null
                    ? options.Select(o => CreateOption(o.value, o.label)).ToList()
                    : CreateDefaultRoleOptions()
            };
            return field;
        }

        /// <summary>
        /// Crea un grupo contenedor (sin key, solo FieldGroupClassName)
        /// </summary>
        public static FormlyFieldConfig CreateFieldGroup(
            Guid formId,
            string fieldGroupClassName = "display-grid",
            Guid? parentId = null)
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                FieldGroupClassName = fieldGroupClassName,
                ParentId = parentId,
                FormlyFormId = formId,
                FieldGroup = new List<FormlyFieldConfig>()
            };
        }

        /// <summary>
        /// Crea un grupo con key y clase CSS
        /// </summary>
        public static FormlyFieldConfig CreateNamedGroup(
            Guid formId,
            string key,
            string fieldGroupClassName = "section",
            Guid? parentId = null)
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = key,
                FieldGroupClassName = fieldGroupClassName,
                ParentId = parentId,
                FormlyFormId = formId,
                FieldGroup = new List<FormlyFieldConfig>()
            };
        }

        /// <summary>
        /// Crea un campo hijo con su padre configurado
        /// </summary>
        public static FormlyFieldConfig CreateChildField(
            Guid formId,
            FormlyFieldConfig parent,
            string key,
            string type = "input",
            string? className = null)
        {
            var child = new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = key,
                Type = type,
                ClassName = className ?? string.Empty,
                ParentId = parent.Id,
                FormlyFormId = formId,
                FormlyFieldConfigParent = parent,
                FieldGroup = new List<FormlyFieldConfig>()
            };
            return child;
        }




        /// <summary>
        /// Crea Props básicas para un campo
        /// </summary>
        public static FormlyFieldProp CreateBasicProps(
            string label,
            string type = "text",
            bool required = false,
            string placeholder = "",
            string appearance = "outline")
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Label = label,
                Type = type,
                Placeholder = placeholder,
                Required = required,
                Disabled = false,
                Readonly = false,
                Appearance = appearance
            };
        }

        /// <summary>
        /// Crea Props con validación de longitud
        /// </summary>
        public static FormlyFieldProp CreatePropsWithLength(
            string label,
            int minLength,
            int maxLength,
            string type = "text",
            bool required = false)
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Label = label,
                Type = type,
                MinLength = minLength,
                MaxLength = maxLength,
                Required = required,
                Appearance = "outline"
            };
        }



        /// <summary>
        /// Crea una opción para campos select/radio
        /// </summary>
        public static FormlyFieldOption CreateOption(string value, string label)
        {
            return new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = value,
                Label = label
            };
        }

        /// <summary>
        /// Crea opciones predeterminadas de roles
        /// </summary>
        public static List<FormlyFieldOption> CreateDefaultRoleOptions()
        {
            return new List<FormlyFieldOption>
            {
                CreateOption("admin", "Administrator"),
                CreateOption("user", "User"),
                CreateOption("guest", "Guest")
            };
        }

        /// <summary>
        /// Crea opciones predeterminadas de países
        /// </summary>
        public static List<FormlyFieldOption> CreateCountryOptions()
        {
            return new List<FormlyFieldOption>
            {
                CreateOption("MX", "México"),
                CreateOption("ES", "España"),
                CreateOption("AR", "Argentina"),
                CreateOption("CO", "Colombia")
            };
        }





        /// <summary>
        /// Crea una validación básica solo con mensaje de required
        /// </summary>
        public static FormlyValidation CreateRequiredValidation(string message = "Este campo es obligatorio")
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Name = "validation",
                Show = true,
                Messages = new Dictionary<string, string>
                {
                    { "required", message }
                }
            };
        }

        /// <summary>
        /// Crea validación para campo de email
        /// </summary>
        public static FormlyValidation CreateEmailValidation(bool includeRequired = true)
        {
            var messages = new Dictionary<string, string>
            {
                { "email", "Ingrese un email válido" }
            };

            if (includeRequired)
            {
                messages.Add("required", "El email es obligatorio");
            }

            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Name = "validation",
                Show = true,
                Messages = messages
            };
        }

        /// <summary>
        /// Crea validación para campo de contraseña
        /// </summary>
        public static FormlyValidation CreatePasswordValidation(
            int minLength = 6,
            int maxLength = 20,
            bool includeRequired = true)
        {
            var messages = new Dictionary<string, string>
            {
                { "minlength", $"La contraseña debe tener al menos {minLength} caracteres" },
                { "maxlength", $"La contraseña no puede exceder {maxLength} caracteres" }
            };

            if (includeRequired)
            {
                messages.Add("required", "La contraseña es obligatoria");
            }

            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Name = "validation",
                Show = true,
                Messages = messages
            };
        }

        /// <summary>
        /// Crea una validación con múltiples mensajes personalizados
        /// </summary>
        public static FormlyValidation CreateCustomValidation(Dictionary<string, string> messages)
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Name = "validation",
                Show = true,
                Messages = messages
            };
        }



        /// <summary>
        /// Crea una jerarquía completa de 2 niveles (Grupo con campos hijos)
        /// </summary>
        public static FormlyFieldConfig CreateTwoLevelHierarchy(Guid formId, string groupClassName = "display-grid")
        {
            // Crear grupo padre
            var parentGroup = CreateFieldGroup(formId, groupClassName);

            // Crear campos hijos
            var usernameField = CreateChildField(formId, parentGroup, "username", "input", "col-6");
            usernameField.Props = CreateBasicProps("Username", "text", true, "Enter username");

            var emailField = CreateChildField(formId, parentGroup, "email", "input", "col-6");
            emailField.Props = CreateBasicProps("Email", "email", true, "Enter email");

            var passwordField = CreateChildField(formId, parentGroup, "password", "input", "col-6");
            passwordField.Props = CreateBasicProps("Password", "password", true, "Enter password");

            // Agregar hijos al padre
            parentGroup.FieldGroup.Add(usernameField);
            parentGroup.FieldGroup.Add(emailField);
            parentGroup.FieldGroup.Add(passwordField);

            return parentGroup;
        }

        /// <summary>
        /// Crea una jerarquía de 3 niveles (Grupo -> SubGrupo -> Campos)
        /// </summary>
        public static FormlyFieldConfig CreateThreeLevelHierarchy(Guid formId)
        {
            // Nivel 1: Grupo principal
            var mainGroup = CreateNamedGroup(formId, "personalInfo", "section");

            // Nivel 2: Campo simple
            var nameField = CreateChildField(formId, mainGroup, "name", "input");
            nameField.Props = CreateBasicProps("Name", "text", true);
            mainGroup.FieldGroup.Add(nameField);

            // Nivel 2: SubGrupo
            var subGroup = CreateNamedGroup(formId, "address", "subsection", mainGroup.Id);
            subGroup.FormlyFieldConfigParent = mainGroup;

            // Nivel 3: Campos dentro del subgrupo
            var streetField = CreateChildField(formId, subGroup, "street", "input");
            streetField.Props = CreateBasicProps("Street", "text");

            var cityField = CreateChildField(formId, subGroup, "city", "input");
            cityField.Props = CreateBasicProps("City", "text");

            subGroup.FieldGroup.Add(streetField);
            subGroup.FieldGroup.Add(cityField);

            mainGroup.FieldGroup.Add(subGroup);

            return mainGroup;
        }

        /// <summary>
        /// Crea un formulario completo de registro con todos los elementos
        /// </summary>
        public static FormlyForm CreateCompleteRegistrationForm()
        {
            var form = CreateEmptyForm("Registration Form");
            form.Description = "Complete registration form with all features";

            // Campo simple raíz
            var nameField = CreateSimpleInputField(form.Id, "name", "Name", true, "Enter your name");
            nameField.Validation = CreateRequiredValidation("El nombre es obligatorio");
            form.Fields.Add(nameField);

            // Campo de email
            var emailField = CreateEmailField(form.Id, "email", "Email", true);
            form.Fields.Add(emailField);

            // Campo select con opciones
            var roleField = CreateSelectField(form.Id, "role", "Role");
            form.Fields.Add(roleField);

            // Grupo con campos anidados
            var credentialsGroup = CreateTwoLevelHierarchy(form.Id, "credentials-section");
            form.Fields.Add(credentialsGroup);

            return form;
        }

        /// <summary>
        /// Crea múltiples campos hijos para un padre
        /// </summary>
        public static List<FormlyFieldConfig> CreateMultipleChildFields(
            Guid formId,
            FormlyFieldConfig parent,
            int count,
            string keyPrefix = "field")
        {
            var children = new List<FormlyFieldConfig>();

            for (int i = 0; i < count; i++)
            {
                var child = CreateChildField(formId, parent, $"{keyPrefix}{i}", "input");
                child.Props = CreateBasicProps($"Field {i}", "text");
                children.Add(child);
            }

            return children;
        }



        /// <summary>
        /// Agrega un campo hijo a un grupo padre (configura todas las relaciones)
        /// </summary>
        public static void AddChildToParent(FormlyFieldConfig parent, FormlyFieldConfig child)
        {
            child.ParentId = parent.Id;
            child.FormlyFieldConfigParent = parent;
            parent.FieldGroup.Add(child);
        }

        /// <summary>
        /// Agrega múltiples campos hijos a un grupo padre
        /// </summary>
        public static void AddChildrenToParent(FormlyFieldConfig parent, params FormlyFieldConfig[] children)
        {
            foreach (var child in children)
            {
                AddChildToParent(parent, child);
            }
        }


    }
}
