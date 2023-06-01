using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public interface ITutorialDomain
{
    List<Tutorial> GetAll();
    bool Create(Tutorial Input);
    bool Update(int id, Tutorial Input);
    bool Delete(int id);
    
}

