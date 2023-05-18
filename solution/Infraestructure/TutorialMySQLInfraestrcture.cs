using Infraestructure.Context;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        return _learningCenterDBContext.Tutorial.ToList();

    }
}

