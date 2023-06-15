using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public interface IPostDomain
{

    Task<bool> CreateAsync(Post post);
    bool Update(int id, Post post);
    bool Delete(int id);
}