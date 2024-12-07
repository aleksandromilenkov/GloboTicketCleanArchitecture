using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts"
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals"
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences"
                },
                 new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
        public static Mock<ICategoryRepository> GetCategoryWithEventsRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            var eventId1 = new Guid();
            var eventId2 = new Guid();

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts",
                    Events = new List<Event>()
                    {
                        new Event()
                        {
                            EventId = eventId1,
                            Name = "Going to adventure",
                            Price = 200,
                            Date = DateTime.Now,
                            CategoryId = concertGuid
                        }
                    }
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals",
                    Events = new List<Event>()
                    {
                        new Event()
                        {
                            EventId = eventId2,
                            Name = "Going to Asd",
                            Price = 200,
                            Date = DateTime.Now,
                            CategoryId = musicalGuid
                        }
                    }
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences",
                    Events = new List<Event>()
                },
                 new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays",
                    Events = new List<Event>()
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.GetCategoriesWithEvents(true)).ReturnsAsync(categories);

            return mockCategoryRepository;
        }
    }
}
