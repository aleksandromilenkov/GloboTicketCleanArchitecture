using GloboTicket.TicketManagment.Persistence;
using System;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
namespace GloboTicket.TicketManagement.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(GloboTicketDbContext context)
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            var eventId1 = new Guid();
            var eventId2 = new Guid();

            context.Categories.Add(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts",
                Events = new List<Event>() {
                    new Event()
                    {
                            EventId = eventId1,
                            Name = "Going to adventure",
                            Price = 200,
                            Date = DateTime.Now,
                            CategoryId = concertGuid
                        }
                }
            });
            context.Categories.Add(new Category
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
            });
            context.Categories.Add(new Category
            {
                CategoryId = playGuid,
                Name = "Plays",
                Events = new List<Event>()
            });
            context.Categories.Add(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences",
                Events = new List<Event>()
            });

            context.SaveChanges();
        }
    }
}
