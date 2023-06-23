using System.Diagnostics.CodeAnalysis;
using Infraestructure.Context;
using LearningCenter.Infraestructure.Interfaces;
using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure;

public class UserInfraestructure : IUserInfraestructure
{
    private LearningCenterDBContext _learningCenterDbContext;

    public UserInfraestructure(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }


    public async Task<User> GetByUsername(string username)
    {
        return await _learningCenterDbContext.Users.SingleAsync(u => u.Username == username);
    }




    public async Task<int> Signup(User user)
    {
        user.DateCreated = DateTime.Now;
        _learningCenterDbContext.Users.Add(user);
        await _learningCenterDbContext.SaveChangesAsync();
        return user.Id;
    }
}