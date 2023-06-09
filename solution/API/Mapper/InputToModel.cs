﻿using Infraestructure.Models;
using LearningCenter.API.Response;
using AutoMapper;
using LearningCenter.API.Input;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.API.Mapper;

public class InputToModel:Profile
{
    public InputToModel()
    {

        CreateMap<TutorialInput, Tutorial>();
        CreateMap<UserInput, User>();
        CreateMap<UserLoginInput, User>();
        CreateMap<PostInput, Post>();
    }
}
