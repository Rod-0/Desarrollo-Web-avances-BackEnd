using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure.Interfaces;

public interface IUserInfraestructure
{
    Task<User> GetByUsername(string username);

    Task<int> Signup(User user);
}