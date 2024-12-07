using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts
{
    public interface ILoggedInUserService
    {
        public string UserId { get; }
    }
}
