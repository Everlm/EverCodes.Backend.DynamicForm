using EverCodes.Backend.DynamicForm.Tests.TestData;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.UnitTests
{
    /// <summary>
    /// Tests para verificar las relaciones entre entidades del sistema de formularios dinámicos
    /// </summary>
    public class EntityRelationshipsTests
    {
        #region FormlyForm → FormlyFieldConfig (1:N)

        [Fact]
        public void FormlyForm_ShouldContainMultipleFields()
        {
            // Arrange
            var form = FormlyFormTestData.CreateSampleFormlyFormData();
            var field1 = FormlyFieldConfigTestData.CreateUsernameFieldConfig();
            var field2 = FormlyFieldConfigTestData.CreateEmailFieldConfig();
            var field3 = FormlyFieldConfigTestData.CreatePasswordFieldConfig();

            // Act
            form.Fields.Add(field1);
            form.Fields.Add(field2);
            form.Fields.Add(field3);

            // Assert
            Assert.Equal(3, form.Fields.Count);
            Assert.Contains(form.Fields, f => f.Key == "username");
            Assert.Contains(form.Fields, f => f.Key == "email");
            Assert.Contains(form.Fields, f => f.Key == "password");
        }

        [Fact]
        public void FormlyFieldConfig_ShouldReferenceParentForm()
        {
            // Arrange
            var formId = Guid.NewGuid();
            var form = FormlyFormTestData.CreateFormlyFormData(formId);
            var field = FormlyFieldConfigTestData.CreateUsernameFieldConfig();

            // Act
            field.FormlyFormId = formId;
            field.FormlyForm = form;

            // Assert
            Assert.Equal(formId, field.FormlyFormId);
            Assert.NotNull(field.FormlyForm);
            Assert.Equal(form.Name, field.FormlyForm.Name);
        }

        [Fact]
        public void FormlyForm_AddingField_ShouldMaintainBidirectionalRelationship()
        {
            // Arrange
            var form = FormlyFormTestData.CreateSampleFormlyFormData();

            var field = FormlyFieldConfigTestData.CreateEmailFieldConfig();

            // Act
            field.FormlyFormId = form.Id;
            field.FormlyForm = form;
            form.Fields.Add(field);

            // Assert
            Assert.Single(form.Fields);
            Assert.Equal(form.Id, field.FormlyFormId);
            Assert.Same(form, field.FormlyForm);
        }

        [Fact]
        public void FormlyForm_RemovingField_ShouldUpdateCollection()
        {
            // Arrange
            var form = FormlyFormTestData.CreateFormlyFormWhitFieldsData();
            var initialCount = form.Fields.Count;

            // Act
            var fieldToRemove = form.Fields.First(f => f.Key == "email");
            form.Fields.Remove(fieldToRemove);

            // Assert
            Assert.Equal(initialCount - 1, form.Fields.Count);
            Assert.DoesNotContain(form.Fields, f => f.Key == "email");
        }

        #endregion

        #region FormlyFieldConfig → FormlyFieldProp (1:1)

        [Fact]
        public void FormlyFieldConfig_ShouldHaveOneProps()
        {
            // Arrange
            var field = FormlyFieldConfigTestData.CreateUsernameFieldConfig();

            // Act
            var props = field.Props;

            // Assert
            Assert.NotNull(props);
            Assert.Equal("text", props.Type);
            Assert.Equal("Username", props.Label);
        }

        [Fact]
        public void FormlyFieldProp_ShouldReferenceParentFieldConfig()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var field = new FormlyFieldConfig { Id = fieldId };
            var props = FormlyFieldPropTestData.CreateEmailProp();

            // Act
            props.FormlyFieldConfigId = fieldId;
            props.FormlyFieldConfig = field;
            field.Props = props;

            // Assert
            Assert.Equal(fieldId, props.FormlyFieldConfigId);
            Assert.NotNull(props.FormlyFieldConfig);
            Assert.Same(field, props.FormlyFieldConfig);
        }

        [Fact]
        public void FormlyFieldConfig_ChangingProps_ShouldReplaceReference()
        {
            // Arrange
            var field = FormlyFieldConfigTestData.CreateUsernameFieldConfig();
            var originalProps = field.Props;
            var newProps = FormlyFieldPropTestData.CreatePasswordProp();

            // Act
            field.Props = newProps;

            // Assert
            Assert.NotSame(originalProps, field.Props);
            Assert.Same(newProps, field.Props);
            Assert.Equal("password", field.Props.Type);
        }

        #endregion

        #region FormlyFieldConfig → FormlyValidation (1:1)

        [Fact]
        public void FormlyFieldConfig_ShouldHaveValidation()
        {
            // Arrange
            var field = FormlyFieldConfigTestData.CreateEmailFieldConfig();

            // Act
            var validation = field.Validation;

            // Assert
            Assert.NotNull(validation);
            Assert.NotEmpty(validation.Messages);
            Assert.True(validation.Messages.ContainsKey("required"));
        }

        [Fact]
        public void FormlyValidation_ShouldReferenceParentFieldConfig()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var field = new FormlyFieldConfig { Id = fieldId };
            var validation = FormlyValidationTestData.CreatePasswordValidation();

            // Act
            validation.FormlyFieldConfigId = fieldId;
            validation.FormlyFieldConfig = field;
            field.Validation = validation;

            // Assert
            Assert.Equal(fieldId, validation.FormlyFieldConfigId);
            Assert.NotNull(validation.FormlyFieldConfig);
            Assert.Same(field, validation.FormlyFieldConfig);
        }


        [Fact]
        public void FormlyFieldConfig_ChangingValidation_ShouldReplaceReference()
        {
            // Arrange
            var field = FormlyFieldConfigTestData.CreateEmailFieldConfig();
            var originalValidation = field.Validation;
            var newValidation = FormlyValidationTestData.CreatePasswordValidation();

            // Act
            field.Validation = newValidation;

            // Assert
            Assert.NotSame(originalValidation, field.Validation);
            Assert.Same(newValidation, field.Validation);
        }

        #endregion

        #region FormlyFieldConfig → FormlyFieldConfig (Parent-Child / FieldGroup)

        [Fact]
        public void FormlyFieldConfig_ShouldHaveFieldGroup()
        {
            // Arrange
            var parentField = new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                FieldGroupClassName = "display-grid",
                FieldGroup = new List<FormlyFieldConfig>()
            };

            var child1 = FormlyFieldConfigTestData.CreateUsernameFieldConfig();
            var child2 = FormlyFieldConfigTestData.CreateEmailFieldConfig();

            // Act
            parentField.FieldGroup.Add(child1);
            parentField.FieldGroup.Add(child2);

            // Assert
            Assert.Equal(2, parentField.FieldGroup.Count);
            Assert.Contains(parentField.FieldGroup, f => f.Key == "username");
            Assert.Contains(parentField.FieldGroup, f => f.Key == "email");
        }

        [Fact]
        public void FormlyFieldConfig_ChildShouldReferenceParent()
        {
            // Arrange
            var parentId = Guid.NewGuid();
            var parent = new FormlyFieldConfig
            {
                Id = parentId,
                FieldGroup = new List<FormlyFieldConfig>()
            };

            var child = FormlyFieldConfigTestData.CreateUsernameFieldConfig();

            // Act
            child.ParentId = parentId;
            child.FormlyFieldConfigParent = parent;
            parent.FieldGroup.Add(child);

            // Assert
            Assert.Equal(parentId, child.ParentId);
            Assert.NotNull(child.FormlyFieldConfigParent);
            Assert.Same(parent, child.FormlyFieldConfigParent);
            Assert.Contains(child, parent.FieldGroup);
        }

        [Fact]
        public void FormlyFieldConfig_NestedFieldGroups_ShouldMaintainHierarchy()
        {
            // Arrange
            var grandparent = new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                FieldGroupClassName = "root",
                FieldGroup = new List<FormlyFieldConfig>()
            };

            var parent = new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                ParentId = grandparent.Id,
                FieldGroupClassName = "child-group",
                FieldGroup = new List<FormlyFieldConfig>()
            };

            var child = FormlyFieldConfigTestData.CreateUsernameFieldConfig();

            // Act
            child.ParentId = parent.Id;
            parent.FieldGroup.Add(child);
            grandparent.FieldGroup.Add(parent);

            // Assert
            Assert.Single(grandparent.FieldGroup);
            Assert.Single(parent.FieldGroup);
            Assert.Equal(parent.Id, child.ParentId);
        }

        [Fact]
        public void FormlyFieldConfig_WithoutParent_ParentIdShouldBeNull()
        {
            // Arrange & Act
            var field = FormlyFieldConfigTestData.CreateUsernameFieldConfig();

            // Assert
            Assert.Null(field.ParentId);
            Assert.Null(field.FormlyFieldConfigParent);
        }

        #endregion

        #region FormlyFieldProp → FormlyFieldOption (1:N)

        [Fact]
        public void FormlyFieldProp_ShouldHaveMultipleOptions()
        {
            // Arrange
            var field = FormlyFieldConfigTestData.CreateRoleFieldConfig();

            // Assert
            Assert.Equal(3, field.Props!.Options.Count);
            Assert.Contains(field.Props.Options, o => o.Value == "admin");
            Assert.Contains(field.Props.Options, o => o.Value == "user");
            Assert.Contains(field.Props.Options, o => o.Value == "guest");
        }

        [Fact]
        public void FormlyFieldOption_ShouldReferenceParentProp()
        {
            // Arrange
            var propId = Guid.NewGuid();
            var props = FormlyFieldPropTestData.CreateSelectProp("Role", new List<FormlyFieldOption>());

            var option = FormlyFieldOptionTestData.CreateAdminOption();

            // Act
            option.FormlyFieldPropId = propId;
            option.FormlyFieldProp = props;
            props.Options.Add(option);

            // Assert
            Assert.Equal(propId, option.FormlyFieldPropId);
            Assert.NotNull(option.FormlyFieldProp);
            Assert.Same(props, option.FormlyFieldProp);
            Assert.Contains(option, props.Options);
        }

        [Fact]
        public void FormlyFieldProp_AddingOption_ShouldUpdateCollection()
        {
            // Arrange
            var props = FormlyFieldPropTestData.CreateSelectProp("Country", FormlyFieldOptionTestData.CreateCountryOptions());
            var initialCount = props.Options.Count;
            var newOption = FormlyFieldOptionTestData.CreateGuestOption();

            // Act
            props.Options.Add(newOption);

            // Assert
            Assert.Equal(initialCount + 1, props.Options.Count);
            Assert.Contains(props.Options, o => o.Value == "guest");
        }

        [Fact]
        public void FormlyFieldProp_RemovingOption_ShouldUpdateCollection()
        {
            // Arrange
            var props = FormlyFieldPropTestData.CreateSelectProp("Status", FormlyFieldOptionTestData.CreateStatusOptions());
            var initialCount = props.Options.Count;

            // Act
            var optionToRemove = props.Options.First(o => o.Value == "inactive");
            props.Options.Remove(optionToRemove);

            // Assert
            Assert.Equal(initialCount - 1, props.Options.Count);
            Assert.DoesNotContain(props.Options, o => o.Value == "inactive");
        }

        [Fact]
        public void FormlyFieldProp_WithoutOptions_ShouldBeEmptyCollection()
        {
            // Arrange & Act
            var props = FormlyFieldPropTestData.CreateTextInputProp("Name", "Enter name");

            // Assert
            Assert.NotNull(props.Options);
            Assert.Empty(props.Options);
        }

        #endregion

        #region Relaciones Complejas: Full Form with All Relationships

        [Fact]
        public void CompleteForm_ShouldMaintainAllRelationships()
        {
            // Arrange
            var form = FormlyFormTestData.CreateSampleFormlyFormData();

            var emailField = FormlyFieldConfigTestData.CreateEmailFieldConfig();
            emailField.FormlyFormId = form.Id;
            emailField.FormlyForm = form;

            var emailProps = FormlyFieldPropTestData.CreateEmailProp();
            emailProps.FormlyFieldConfigId = emailField.Id;
            emailProps.FormlyFieldConfig = emailField;
            emailField.Props = emailProps;

            var emailValidation = FormlyValidationTestData.CreateEmailValidation();
            emailValidation.FormlyFieldConfigId = emailField.Id;
            emailValidation.FormlyFieldConfig = emailField;
            emailField.Validation = emailValidation;

            var roleField = FormlyFieldConfigTestData.CreateRoleFieldConfig();
            roleField.FormlyFormId = form.Id;
            roleField.FormlyForm = form;



            // Act
            form.Fields.Add(emailField);
            form.Fields.Add(roleField);

            // Assert - Verificar todas las relaciones
            Assert.Equal(2, form.Fields.Count);

            // Email field relationships
            var email = form.Fields.First(f => f.Key == "email");
            Assert.Equal(form.Id, email.FormlyFormId);
            Assert.NotNull(email.Props);
            Assert.NotNull(email.Validation);
            Assert.Equal(email.Id, email.Props.FormlyFieldConfigId);
            Assert.Equal(email.Id, email.Validation.FormlyFieldConfigId);

            // Role field relationships
            var role = form.Fields.First(f => f.Key == "role");
            Assert.Equal(form.Id, role.FormlyFormId);
            Assert.NotNull(role.Props);
            Assert.Equal(3, role.Props.Options.Count);
        }

        [Fact]
        public void FieldGroup_WithNestedFieldsAndRelationships_ShouldMaintainIntegrity()
        {
            // Arrange
            var form = FormlyFormTestData.CreateSampleFormlyFormData();

            var groupField = FormlyFieldConfigTestData.CreateGroupField(form.Id, form);

            var usernameField = FormlyFieldConfigTestData.CreateUsernameFieldConfig();
            usernameField.ParentId = groupField.Id;
            usernameField.FormlyFieldConfigParent = groupField;
            usernameField.FormlyFormId = form.Id;

            var emailField = FormlyFieldConfigTestData.CreateEmailFieldConfig();
            emailField.ParentId = groupField.Id;
            emailField.FormlyFieldConfigParent = groupField;
            emailField.FormlyFormId = form.Id;

            // Act
            groupField.FieldGroup.Add(usernameField);
            groupField.FieldGroup.Add(emailField);
            form.Fields.Add(groupField);

            // Assert
            Assert.Single(form.Fields);
            Assert.Equal(2, groupField.FieldGroup.Count);
            Assert.All(groupField.FieldGroup, field =>
            {
                Assert.Equal(groupField.Id, field.ParentId);
                Assert.Same(groupField, field.FormlyFieldConfigParent);
                Assert.Equal(form.Id, field.FormlyFormId);
            });
        }

        #endregion

        #region Navigation Property Tests

        [Fact]
        public void Navigation_FromFormToFieldsToPropsToOptions_ShouldTraverseCorrectly()
        {
            // Arrange
            var form = FormlyFormTestData.CreateSampleFormlyFormData();
            var field = FormlyFieldConfigTestData.CreateCustomField(form.Id, form, "country", "select");

            var props = FormlyFieldPropTestData.CreateSelectProp("Country", FormlyFieldOptionTestData.CreateCountryOptions());
            props.FormlyFieldConfigId = field.Id;
            props.FormlyFieldConfig = field;
            field.Props = props;

            form.Fields.Add(field);

            // Act - Navigate through relationships
            var formName = form.Name;
            var fieldKey = form.Fields.First().Key;
            var propsLabel = form.Fields.First().Props?.Label;
            var firstOptionLabel = form.Fields.First().Props?.Options.First().Label;

            // Assert
            Assert.Equal("Test Form", formName);
            Assert.Equal("country", fieldKey);
            Assert.Equal("Country", propsLabel);
            Assert.Equal("United States", firstOptionLabel);
        }

        #endregion
    }
}
