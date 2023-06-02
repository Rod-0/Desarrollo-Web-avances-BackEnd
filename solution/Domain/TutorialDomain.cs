﻿using Infraestructure;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain;
public class TutorialDomain : ITutorialDomain
{
    private ITutorialInfraestructure _tutorialinfraestructure;
    public TutorialDomain(ITutorialInfraestructure tutorialinfraestructure) //la inyecto a travez del constructor
    {
        _tutorialinfraestructure = tutorialinfraestructure;
    }

   
    /*public Task<List<Tutorial>> GetAll()
    {
        //Reglas de negocio
        return await _tutorialinfraestructure.GetAll();

        //TutorialInfraestructure tutorialInfraestructure = new TutorialInfraestructure();
        //return tutorialInfraestructure.GetAll();
    }*/
    public async Task<bool> CreateAsync(Tutorial input)
    {
        if (input.Name.Length < 3) throw new Exception("less than 3 char");
        if (input.Name.Length > 10) throw new Exception("more than 10 char");

        return await _tutorialinfraestructure.CreateAsync(input);
    }
    public bool Update(int id, Tutorial tutorial)
    {
        return _tutorialinfraestructure.Update(id, tutorial);
    }
    public bool Delete(int id)
    {
        return _tutorialinfraestructure.Delete(id);
    }



}

