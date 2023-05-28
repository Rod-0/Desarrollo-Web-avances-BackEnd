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
    bool Create(string name);
    bool Update(int id, string name);
    bool Delete(int id);
    
}

