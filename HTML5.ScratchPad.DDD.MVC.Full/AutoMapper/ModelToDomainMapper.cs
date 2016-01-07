using AutoMapper;
using HTML5.ScratchPad.DDD.Domain.Entities;
using HTML5.ScratchPad.DDD.MVC.Full.Models;

namespace HTML5.ScratchPad.DDD.MVC.Full.AutoMapper
{
    public class ModelToDomainMapper : Profile
    {
        //public override string ProfileName { get { return "DomainToModelMappings"; } }

        protected override void Configure()
        {
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}