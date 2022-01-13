using AutoMapper;
using Projects.Application.Projects.Commands.CreateTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Api.Models
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                   .ForMember(taskCommand => taskCommand.Title,
                            opt => opt.MapFrom(taskDto => taskDto.Title))
                   .ForMember(taskCommand => taskCommand.Description,
                            opt=> opt.MapFrom(taskDto => taskDto.Description))
                   .ForMember(taskCommand => taskCommand.Priority,
                            opt => opt.MapFrom(taskDto => taskDto.Priority));
        }
    }
}
