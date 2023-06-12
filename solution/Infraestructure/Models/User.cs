using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Infraestructure.Models;

public class User : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Roles { get; set; }
}
