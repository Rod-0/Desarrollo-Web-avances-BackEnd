using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public interface ITutorialDomain
{
    //Task<List<Tutorial>> GetAll();
    Task<bool> CreateAsync(Tutorial Input);
    bool Update(int id, Tutorial Input);
    bool Delete(int id);
    
}

