using AutoMapper;
using Task4_userAPI.DataTransferObject;
using Task4_userAPI.Models;

namespace Task4_userAPI.AMProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<user, UserVM>()
                .ForMember(c => c.Id, a => a.MapFrom(src => src.Id))
            .ForMember(c => c.fname, a => a.MapFrom(src => src.fname))
            .ForMember(c => c.lname, a => a.MapFrom(src => src.lname))
            .ForMember(c => c.postId, a => a.MapFrom(src => src.posts.ToList()));

        }
    }
}
