using AutoMapper;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.WebServices.DataContracts;

namespace HTML5.ScratchPad.DDD.WebServices.AutoMapper
{
    public class EFEntityToDtoMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Address, AddressDto>();
   
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom( src => src.Address));

            //or ignore relationship properties
            //Mapper.CreateMap<Customer, CustomerDto>()
            //    .ForMember(dest => dest.Address, opt => opt.Ignore());
        }
    }
}