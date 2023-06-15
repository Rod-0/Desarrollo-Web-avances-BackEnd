using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Infraestructure.Interfaces;
public interface IDestinationInfraestructure
{

    Task<bool> CreateAsync(Destination destination);
}
