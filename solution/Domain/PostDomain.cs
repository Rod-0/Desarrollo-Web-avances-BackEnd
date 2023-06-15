using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public class PostDomain : IPostDomain
{
    private IPostInfraestructure _postInfraestructure;

    public PostDomain(IPostInfraestructure postInfraestructure)
    {
        _postInfraestructure = postInfraestructure;
    }

    public async Task<bool> CreateAsync(Post post)
    {
        await _postInfraestructure.CreateAsync(post);
        return true;
    }

    public bool Update(int id, Post post)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}