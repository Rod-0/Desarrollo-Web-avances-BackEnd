using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Domain.Interfaces;
public interface IDestinationDomain
{

    Task<bool> CreateAsync(Destination input);


}

