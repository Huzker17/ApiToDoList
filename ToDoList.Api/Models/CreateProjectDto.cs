using AutoMapper;
using Projects.Application.Common.Mappings;
using Projects.Application.Projects.Commands.CreateProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Api.Models
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand> 
    {
        public string Title { get; set; }
        public int Priority { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                   .ForMember(projectCommand => projectCommand.Title,
                            opt => opt.MapFrom(projectDto => projectDto.Title))
                   .ForMember(projectCommand => projectCommand.Priority,
                            opt => opt.MapFrom(projectDto => projectDto.Priority));
        } 
    }
}
