using System.Net.Http.Json;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.DTOs;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EverCodes.Backend.DynamicForm.Tests.IntegrationTests
{
    public class DynamicFormApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public DynamicFormApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetSampleForm_WithIgnoreCycles_ShouldReturnForm()
        {
            // Act
            var response = await _client.GetAsync("/api/dynamic-forms/sample");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            
            var form = await response.Content.ReadFromJsonAsync<FormlyForm>();
            Assert.NotNull(form);
            Assert.Equal("User", form.Name);
            Assert.Equal(3, form.Fields.Count);
        }

        [Fact]
        public async Task GetSampleFormDto_WithDto_ShouldReturnFormWithoutCycles()
        {
            // Act
            var response = await _client.GetAsync("/api/dynamic-forms/sample-dto");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
            
            var formDto = await response.Content.ReadFromJsonAsync<FormlyFormDto>();
            Assert.NotNull(formDto);
            Assert.Equal("User", formDto.Name);
            Assert.Equal(3, formDto.Fields.Count);
        }

        [Fact]
        public async Task CompareResponses_BothEndpointsShouldReturnSameStructure()
        {
            // Act
            var response1 = await _client.GetAsync("/api/dynamic-forms/sample");
            var response2 = await _client.GetAsync("/api/dynamic-forms/sample-dto");

            var form = await response1.Content.ReadFromJsonAsync<FormlyForm>();
            var formDto = await response2.Content.ReadFromJsonAsync<FormlyFormDto>();

            // Assert
            Assert.NotNull(form);
            Assert.NotNull(formDto);
            
            Assert.Equal(form.Name, formDto.Name);
            Assert.Equal(form.Description, formDto.Description);
            Assert.Equal(form.Fields.Count, formDto.Fields.Count);
        }
    }
}
