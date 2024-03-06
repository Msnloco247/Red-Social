
using AutoMapper;
using Red_Social1.Core.Application.Dtos.Account;
using Red_Social1.Core.Application.ViewModels.Publication;
using Red_Social1.Core.Application.ViewModels.User;
using Red_Social1.Core.Domain.Entities;
using Red_Social1.Infrastructure.Identity.Entities;
using Red_Social1.Infrastructure.Identity.ViewModels.Comentary;
using Red_Social1.Infrastructure.Identity.ViewModels.Publication;

namespace Red_Social1.Infrastructure.Identity.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region PublicationProfile
            CreateMap<PublicationUser, PublicationUserViewModel>()
                .ForMember(x => x.UserName, opt => opt.Ignore())
            .ForMember(x => x.PhotoUrl, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
            .ForMember(x => x.ComentaryId, opt => opt.Ignore())
            .ForMember(x => x.User, opt => opt.Ignore());

            CreateMap<PublicationUser, SavePublicationUserViewModel>()

              .ReverseMap()
              .ForMember(x => x.Comentaries, opt => opt.Ignore())
              .ForMember(x => x.Created, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
               .ForMember(x => x.ComentaryId, opt => opt.Ignore());



            #endregion


            #region ComentaryProfile
            CreateMap<ComentaryUser, ComentaryUserViewModel>()
                .ForMember(x => x.UserName, opt => opt.Ignore())
                .ForMember(x => x.PhotoUrl, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
            .ForMember(x => x.User, opt => opt.Ignore())
            .ForMember(x => x.Publication, opt => opt.Ignore());

            CreateMap<ComentaryUser, SaveComentaryUserViewModel>()

              .ReverseMap()
              .ForMember(x => x.User, opt => opt.Ignore())
              .ForMember(x => x.Created, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
               .ForMember(x => x.Publication, opt => opt.Ignore());



            #endregion

        }
    }
}
