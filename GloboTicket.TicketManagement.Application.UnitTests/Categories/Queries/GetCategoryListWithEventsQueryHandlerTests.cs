using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoryListWithEventsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoryListWithEventsQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryWithEventsRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetCategoriesListWithEventsTest()
        {
            var handler = new GetCategoriesListWithEventsQueryHandler(_mockCategoryRepository.Object, _mapper);
            var result = await handler.Handle(new GetCategoriesListWithEventsQuery() { IncludeHistory = true}, CancellationToken.None);
            result.ShouldBeOfType<List<CategoryEventListVm>>();
            result.Count.ShouldBe(4);
        }
    }
}
