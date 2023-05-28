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
    public bool Create(string name)
    {
        if (name.Length < 3) throw new Exception("less than 3 char");
        if (name.Length > 10) throw new Exception("more than 10 char");

        return _tutorialinfraestructure.Create(name);
    }
    public bool Update(int id, string name)
    {
        return _tutorialinfraestructure.Update(id, name);
    }
    public bool Delete(int id)
    {
        return _tutorialinfraestructure.Delete(id);
    }



}

