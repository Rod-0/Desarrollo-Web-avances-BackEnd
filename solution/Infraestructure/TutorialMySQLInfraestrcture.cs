using Infraestructure.Context;
using Infraestructure.Models;
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

  

    public List<Tutorial> GetAll()
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

        return _learningCenterDBContext.Tutorials.ToList();

    }

    public bool Create(string name)
    {
        try
        {
            Tutorial tutorial = new Tutorial();
            tutorial.Name = name;
            tutorial.IsActive = true;

            _learningCenterDBContext.Tutorials.Add(tutorial);
            _learningCenterDBContext.SaveChanges();
            return true;
        }
        catch (Exception exception) { return false; }
    }
    public bool Update(int id, string name)
    {
        
            try
            {
                var tutorial = _learningCenterDBContext.Tutorials.Find(id); //obtengo

                tutorial.Name = name; //Modifico

                _learningCenterDBContext.Tutorials.Update(tutorial); //modifco y mando el objeto


                _learningCenterDBContext.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

    public bool Delete(int id)
    {
        var tutorial = _learningCenterDBContext.Tutorials.Find(id); //obtengo

        tutorial.IsActive= false; //Modifico

        _learningCenterDBContext.Tutorials.Update(tutorial); //modifco y mando el objeto


        _learningCenterDBContext.SaveChanges();

        return true;
    }

    
}

