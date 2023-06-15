using Infraestructure.Models;
using LearningCenter.Domain.Interfaces;
using LearningCenter.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain;
public class DestinationDomain : IDestinationDomain
{
    private IDestinationInfraestructure _destinationinfraestructure;
    public DestinationDomain(IDestinationInfraestructure destinationinfraestructure) //la inyecto a travez del constructor
    {
        _destinationinfraestructure = destinationinfraestructure;
    }

   

    public async Task<bool> CreateAsync(Destination input)
    {

        //if (input.name.Equals(true) ) throw new Exception("less or equal than 0 users");
        if (input.maxUser <= 0 ) throw new Exception("less or equal than 0 users");
        if (input.isRisky !=0 && input.isRisky != 1) throw new Exception("only values 0 or 1 are allowed");

        return await _destinationinfraestructure.CreateAsync(input);
    }




}

