using LearningCenter.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Models; 
public class Category : BaseModel
{
   
    public string Description { get; set; }

    public List<Tutorial>Tutorials { get; set; } //una categoria puede tener varios tutoriales
}

