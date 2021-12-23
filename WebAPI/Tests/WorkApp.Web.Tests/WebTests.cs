namespace WorkApp.Web.Tests
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using WorkApp.Services.Register.InputModels;
    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public WebTests(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Fact(Skip = "Integration test that uses the actual database. Fails if the user already exists.")]
        public async Task RegisterClientShouldReturnOkWithValidInput()
        {
            RegisterClientInputModel inputModel = new RegisterClientInputModel()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test1234@abv.bg",
                Password = "TestTest1",
                CompanyName = "Microsoft"
            };

            var client = this.server.CreateClient();
            var response = await client.PostAsJsonAsync("/api/register/client", inputModel);

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("tooLongFirstNameeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", "test", "test@abv.bg", "password1", "Microsoft")]
        [InlineData("test", "tooLongLastNameeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", "test@abv.bg", "password1", "Microsoft")]
        [InlineData("test", "test", "wrongemail.com", "password1", "Microsoft")]
        public async Task RegisterClientShouldNotReturnOkWithInvalidInput(string firstName, string lastName, string email, string password, string companyName)
        {
            RegisterClientInputModel inputModel = new RegisterClientInputModel()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                CompanyName = companyName
            };

            var client = this.server.CreateClient();
            var response = await client.PostAsJsonAsync("/api/register/client", inputModel);

            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact(Skip = "Example test. Disabled for CI.")]
        public async Task IndexPageShouldReturnStatusCode200WithTitle()
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>", responseContent);
        }

        [Fact(Skip = "Example test. Disabled for CI.")]
        public async Task AccountManagePageRequiresAuthorization()
        {
            var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.GetAsync("Identity/Account/Manage");
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
    }
}
