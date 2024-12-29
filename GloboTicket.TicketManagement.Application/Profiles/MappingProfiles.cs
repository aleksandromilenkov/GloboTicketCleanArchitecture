using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event,CreateEventCommand>().ReverseMap();    
            CreateMap<Event, UpdateEventCommand>().ReverseMap();    
            CreateMap<Event, DeleteEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>(); 
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryEventListVm>()
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));
        }
    }
}
