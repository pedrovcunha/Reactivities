using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();

            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.HostUsername, opt => opt.MapFrom(src => src.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName))
                .ForMember(dest => dest.Attendees, opt => opt.MapFrom(src => src.Attendees));

            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.AppUser.DisplayName))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.AppUser.Bio))
                .ForMember(d => d.Image, opt => opt.MapFrom(src => src.AppUser.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(d => d.Image, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}