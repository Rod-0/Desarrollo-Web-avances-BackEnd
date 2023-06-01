using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure;
public interface ITutorialInfraestructure
{
    List<Tutorial> GetAll();
    Tutorial GetbyId(int id);
    List<Tutorial> GetByName(string name);
    bool Create(Tutorial tutorial);
    bool Update(int id, Tutorial tutorial);
    bool Delete(int id);
}
