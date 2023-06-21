using Infraestructure.Context;
using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure;

public class PostInfraestructure : IPostInfraestructure
{
    private LearningCenterDBContext _learningCenterDbContext;

    public PostInfraestructure(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }
    private IPostInfraestructure _postInfraestructureImplementation;

    public async Task<List<Post>> GetAll()
    {
        return await _learningCenterDbContext.Posts.ToListAsync();
    }

    public Post GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(Post input)
    {  
        _learningCenterDbContext.Posts.Add(input);
        await _learningCenterDbContext.SaveChangesAsync();
        return true;
    }

    public bool Update(int id, Post input)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}