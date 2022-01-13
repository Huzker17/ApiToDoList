using Projects.Application.Projects.Commands.UpdateTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projects.Domain;
using TaskStatus = Projects.Domain.TaskStatus;
using AutoMapper;

namespace ToDoList.Api.Models
{
    public class UpdateTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public int Priority { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateTaskCommand>()
                .ForMember(updateCommand => updateCommand.Title,
                    opt => opt.MapFrom(updateDto => updateDto.Title))
                .ForMember(updateCommand => updateCommand.Status,
                    opt => opt.MapFrom(updateDto => updateDto.Status))
                .ForMember(updateCommand => updateCommand.Priority,
                    opt => opt.MapFrom(updateDto => updateDto.Priority));
        }
    }
}
