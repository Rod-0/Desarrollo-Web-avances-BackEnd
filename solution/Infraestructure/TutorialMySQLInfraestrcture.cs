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

public class TutorialMySQLInfraestrcture : ITutorialInfraestructure
{
    private LearningCenterDBContext _learningCenterDBContext;
    public TutorialMySQLInfraestrcture(LearningCenterDBContext learningCenterDBContext)
    {
        _learningCenterDBContext = learningCenterDBContext;
    }

  

    public async Task<List<Tutorial>>GetAll()
    {
        /*_learningCenterDBContext.Tutorial.Add(new Tutorial()      escribiendo
        { 
            name = "tutorial 1",
            Description = "Description 1"
        });

        _learningCenterDBContext.Tutorial.Add(new Tutorial()
        {
            name = "tutorial 2",
            Description = "Description 2"
        });

        _learningCenterDBContext.SaveChanges();*/

    
        //LearningCenterDBContext;

        return await _learningCenterDBContext.Tutorials.Where(tutorial => tutorial.IsActive).ToListAsync(); //el await nos indica que estamos un metodo asincrono

    }
    public async Task<Tutorial> GetbyId(int id)
    {
        return await _learningCenterDBContext.Tutorials.SingleAsync(tutorial => tutorial.IsActive && tutorial.Id==id);
    }

    public async Task<List<Tutorial>> GetByName(string name)
    {
        return await _learningCenterDBContext.Tutorials.Where(tutorial => tutorial.IsActive && tutorial.Name == name).ToListAsync();
       // return _learningCenterDBContext.Tutorials.Where(tutorial => tutorial.IsActive && tutorial.Name.Contains(name)).ToList(); SI SOLO LO CONTIENE
    }

    public async Task<bool> CreateAsync(Tutorial tutorial)
    {
        try
        {
            /*Tutorial tutorial = new Tutorial();
            tutorial.Name = name;*/
            tutorial.IsActive = true;

            _learningCenterDBContext.Tutorials.Add(tutorial);
            await _learningCenterDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { return false; }
    }
    public async Task<bool> Update(int id, Tutorial input)
    {
        
            try
            {
                //tutorial.Id = id;

                var tutorial = _learningCenterDBContext.Tutorials.Find(id); //obtengo

                tutorial.Name = input.Name; //Modifico
                tutorial.Description = input.Description;

                _learningCenterDBContext.Tutorials.Update(tutorial); //modifco y mando el objeto


                await _learningCenterDBContext.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

    public async Task<bool> Delete(int id)
    {
        var tutorial = _learningCenterDBContext.Tutorials.Find(id); //obtengo

        tutorial.IsActive= false; //Modifico

        _learningCenterDBContext.Tutorials.Update(tutorial); //modifco y mando el objeto


        await _learningCenterDBContext.SaveChangesAsync();

        return true;
    }

   
}

