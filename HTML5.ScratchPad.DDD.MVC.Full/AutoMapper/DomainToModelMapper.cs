using AutoMapper;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.MVC.Full.Models;

namespace HTML5.ScratchPad.DDD.MVC.Full.AutoMapper
{
    public class DomainToModelMapper : Profile
    {
        //public override string ProfileName { get { return "ModelToDomainMappings"; } }

        protected override void Configure()
        {
            Mapper.CreateMap<CustomerViewModel, Customer>();
            Mapper.CreateMap<ProductViewModel, Product>();
        }
    }
}