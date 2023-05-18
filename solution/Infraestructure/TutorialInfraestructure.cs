using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure;
public class TutorialInfraestructure : ITutorialInfraestructure
{
    public IEnumerable<string> GetAll()
    {

        return new string[] { "value1 Infraestructure SQL", "value2 Infraestructure SQL" };
    }
}

