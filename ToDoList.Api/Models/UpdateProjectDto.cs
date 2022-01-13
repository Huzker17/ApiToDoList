using AutoMapper;
using Projects.Application.Common.Mappings;
using Projects.Application.Projects.Commands.UpdateProject;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Api.Models
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ProjectStatus  Status {get;set;}
        public int Priority { get; set; }
        public DateTime CompletionDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(updateCommand => updateCommand.Title,
                    opt => opt.MapFrom(updateDto => updateDto.Title))
                .ForMember(updateCommand => updateCommand.Status,
                    opt => opt.MapFrom(updateDto => updateDto.Status))
                .ForMember(updatedCommand=> updatedCommand.CompletionDate,
                     opt=> opt.MapFrom(updateDto=>updateDto.CompletionDate))
                .ForMember(updateCommand => updateCommand.Priority,
                    opt => opt.MapFrom(updateDto => updateDto.Priority));
        }
    }
}
