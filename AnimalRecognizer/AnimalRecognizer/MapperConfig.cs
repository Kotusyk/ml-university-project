using AutoMapper;
using AnimalRecognizer.Model;
using AnimalRecognizer.DTOs;

namespace AnimalRecognizer
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Pet, PetDTO>();
            CreateMap<Shelter, ShelterDTO>();
            CreateMap<Image, ImageDTO>();
        }
    }
}