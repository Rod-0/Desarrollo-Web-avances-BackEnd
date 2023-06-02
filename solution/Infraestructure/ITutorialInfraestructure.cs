using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure;
public interface ITutorialInfraestructure
{
    Task<List<Tutorial>> GetAll();
    Tutorial GetbyId(int id);
    List<Tutorial> GetByName(string name);
    Task<bool> CreateAsync(Tutorial tutorial);
    bool Update(int id, Tutorial tutorial);
    bool Delete(int id);
}
