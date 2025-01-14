﻿using AutoMapper;
using System.Net.Sockets;
using Tourism.Application.Dto;
using Tourism.Core.Entitiy;
using static Tourism.Core.Enums.Enums;

namespace Tourism.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Map User entity to UsersDto
            CreateMap<User, UsersDto>();

            // Map RegisterDto to User for registration
            CreateMap<RegisterDto, User>();


            // Map LoginDto to User for login 
            CreateMap<LoginDto, User>();
            CreateMap<ArticleDto, UserArticle>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<ArticleDto, UserArticle>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => (Cities)src.CityId))
            .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => Enum.GetName(typeof(ArticleTopic), src.TopicId)));

            CreateMap<TicketDto, UserTicket>()
                .ForMember(dest => dest.FilePath, opt => opt.Ignore());


            CreateMap<UserTicket, TicketDetailDto>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}

