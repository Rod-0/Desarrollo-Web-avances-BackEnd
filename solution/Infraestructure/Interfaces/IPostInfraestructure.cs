using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public interface IPostInfraestructure
{

    Task<List<Post>> GetAll();
    Post GetById(int id);
    Task<bool> CreateAsync(Post input);
    bool Update(int id, Post input);
    bool Delete(int id);
}