using Infraestructure.Models;
using LearningCenter.API.Response;
using AutoMapper;
using LearningCenter.API.Input;

namespace LearningCenter.API.Mapper;

public class InputToModel:Profile
{
    public InputToModel()
    {

        CreateMap<TutorialInput, Tutorial>();

    }
}
