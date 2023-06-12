using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain.Interfaces;

public interface IUserDomain
{
    Task<string> Login(User user);
    Task<int> Signup(User user);
    Task<User> GetByUsername(string username);
}