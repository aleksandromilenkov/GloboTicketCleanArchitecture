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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext){ }
        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
           var allCategories = await _dbContext.Categories.Include(c=> c.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(c => c.Events.ToList().RemoveAll(e => e.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}
