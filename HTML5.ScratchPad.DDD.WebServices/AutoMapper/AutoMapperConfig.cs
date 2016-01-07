using AutoMapper;

namespace HTML5.ScratchPad.DDD.WebServices.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(x =>
            {
                x.AddProfile<EFEntityToDtoMapper>();
            });
        }
    }
}