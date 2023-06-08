using AutoMapper;
using EBYS.BusinessLayer.Dtos.Departman;
using EBYS.BusinessLayer.Dtos.Görev;
using EBYS.BusinessLayer.Dtos.Kullanici;
using EBYS.BusinessLayer.Dtos.Personel;
using EBYS.BusinessLayer.Dtos.Sirket;
using EBYS.EntityLayer.Concrete;

namespace EBYS.BusinessLayer.Mapper
{
    public class DtoAndEntityProfile : Profile
    {
        public DtoAndEntityProfile()
        {
            //Departman
            CreateMap<CreateDepartmanDto, DepartmanEntity>();
            CreateMap<DepartmanEntity, DepartmanDto>();
            CreateMap<UpdateDepartmanDto, DepartmanEntity>();

            //Sirket
            CreateMap<CreateSirketDto, SirketEntity>();
            CreateMap<SirketEntity, SirketDto>();
            CreateMap<UpdateSirketDto, SirketEntity>();

            //Personel
            CreateMap<CreatePersonelDto, PersonelEntity>();
            CreateMap<PersonelEntity, PersonelDto>()
                .ForMember(x => x.SirketId, opt => opt.MapFrom(x => x.SirketEntity.Id))
                .ForMember(x => x.SirketName, opt => opt.MapFrom(x => x.SirketEntity.Ad))
                .ForMember(x => x.DepartmanId, opt => opt.MapFrom(x => x.Departman.Id))
                .ForMember(x => x.DepartmanName, opt => opt.MapFrom(x => x.Departman.Ad));
            CreateMap<UpdatePersonelDto, PersonelEntity>();

            //Görev
            CreateMap<CreateGorevDto, GorevEntity>();
            CreateMap<GorevEntity, GorevDto>()
                .ForMember(x => x.PersonelAd, opt => opt.MapFrom(x => x.Personel.Ad + " " + x.Personel.Soyad))
                .ForMember(x => x.PersonelId, opt => opt.MapFrom(x => x.Personel.Id));
            CreateMap<UpdateGorevDto, GorevEntity>();

            //Kullanıcı
            CreateMap<KullaniciEntity, LoginJwtDto>();
            CreateMap<KullaniciEntity, KullaniciListDto>();
            CreateMap<CreateKullaniciDto, KullaniciEntity>();
            CreateMap<UpdateKullaniciDto, KullaniciEntity>();
        }
    }
}
