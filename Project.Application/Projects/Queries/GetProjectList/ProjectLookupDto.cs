using AutoMapper;
using Projects.Application.Common.Mappings;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Application.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<ProjectItem>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectItem, ProjectLookupDto>()
                .ForMember(projectDto => projectDto.Id, opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.Title, opt => opt.MapFrom(project => project.Title));
        }
    }
}
