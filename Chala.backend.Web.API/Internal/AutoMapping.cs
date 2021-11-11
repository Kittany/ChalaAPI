using AutoMapper;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chala.backend.Web.API.Internal
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDTOs.Create, User>();
            CreateMap<UserDTOs.Edit, User>();

            CreateMap<TodoTaskDTOs.Create, TodoTask>();
            CreateMap<TodoTaskDTOs.Edit, TodoTask>();

            CreateMap<RoutineDTOs.Create, Routine>();
            CreateMap<RoutineDTOs.Edit, Routine>();

            //CreateMap<EventDTOs.Create, Event>();
            CreateMap<EventDTOs.Edit, Event>();
        }
    }
}
