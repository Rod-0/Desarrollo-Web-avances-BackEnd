using Infraestructure.Context;
using Infraestructure.Models;
using LearningCenter.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infraestructure;

public class DestinationInfraestrcture : IDestinationInfraestructure
{
    private SuscriptionDBContext _suscriptionDBContext;
    public DestinationInfraestrcture(SuscriptionDBContext suscriptionDBContext)
    {
        _suscriptionDBContext = suscriptionDBContext;
    }

 

    public async Task<bool> CreateAsync(Destination destination)
    {
        try
        {


            _suscriptionDBContext.Destinations.Add(destination);
            await _suscriptionDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { throw; return false; }
    }


   
}

