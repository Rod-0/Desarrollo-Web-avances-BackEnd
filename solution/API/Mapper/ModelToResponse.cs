using AutoMapper;
using Infraestructure.Models;
using LearningCenter.API.Response;


namespace LearningCenter.API.Mapper;

public class ModelToResponse:Profile
{
    public ModelToResponse()
    {
        CreateMap<Destination, DestinationResponse>();
        
    }
}
