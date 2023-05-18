using Infraestructure;
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

    public List<Tutorial> GetAll()
    {
        //Reglas de negocio
        return _tutorialinfraestructure.GetAll();

        //TutorialInfraestructure tutorialInfraestructure = new TutorialInfraestructure();
        //return tutorialInfraestructure.GetAll();
    }
}

