using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Infraestructure.Models;

public class BaseModel
{
    //campos auditoria
    public int Id { get; set; }
    public bool IsActive{ get; set; }
    public DateTime DateCreated{ get; set; }
    public DateTime? DateUpdated { get; set; }
}
