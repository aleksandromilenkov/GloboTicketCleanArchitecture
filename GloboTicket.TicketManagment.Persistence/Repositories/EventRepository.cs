using GloboTicket.TicketManagement.Application.Contracts.Persistance;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            return await _dbContext.Events.AnyAsync(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate));
        }
    }
}
