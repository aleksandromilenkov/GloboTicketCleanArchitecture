using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Controllers
{
    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/category/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<CategoryListVm>>(responseString);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ReturnsSuccessResultWithEvents()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/category/allwithevents");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<CategoryEventListVm>>(responseString);

            Assert.IsType<List<CategoryEventListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
