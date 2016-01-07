using AutoMapper;

namespace HTML5.ScratchPad.DDD.MVC.Full.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToModelMapper>();
                x.AddProfile<ModelToDomainMapper>();
            });
        }
    }
}