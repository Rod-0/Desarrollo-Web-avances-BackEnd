using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Domain.Interfaces;
public interface ITutorialDomain
{
    //Task<List<Tutorial>> GetAll();
    Task<bool> CreateAsync(Tutorial Input);
    Task<bool> Update(int id, Tutorial Input);
    Task<bool> Delete(int id);

}

