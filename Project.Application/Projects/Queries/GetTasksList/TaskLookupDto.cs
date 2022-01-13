using AutoMapper;
using Projects.Application.Common.Mappings;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetTasksList
{
    public class TaskLookupDto : IMapWith<TaskItem>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public int Priority { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskLookupDto, TaskItem>()
                .ForMember(taskDto => taskDto.Id,
                        opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.Title,
                        opt => opt.MapFrom(task => task.Name))
                .ForMember(taskDto => taskDto.Description,
                        opt => opt.MapFrom(task => task.Description))
                .ForMember(taskDto => taskDto.TaskStatus,
                        opt => opt.MapFrom(task => task.Status))
                .ForMember(taskDto => taskDto.Priority,
                        opt => opt.MapFrom(task => task.Priority));
        }
    }

}
