using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Infraestructure.Interfaces;
public interface ITutorialInfraestructure
{
    Task<List<Tutorial>> GetAll();
    Task<Tutorial> GetbyId(int id);
    Task<List<Tutorial>> GetByName(string name);
    Task<bool> CreateAsync(Tutorial tutorial);
    Task<bool> Update(int id, Tutorial tutorial);
    Task<bool> Delete(int id);
}
