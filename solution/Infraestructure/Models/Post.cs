using Infraestructure.Models;

namespace LearningCenter.Infraestructure.Models;

public class Post : BaseModel
{
    public string Title { get; set; }
    public string Author { get; set; }

    public int userId { get; set; }
    public User user { get; set; }

}