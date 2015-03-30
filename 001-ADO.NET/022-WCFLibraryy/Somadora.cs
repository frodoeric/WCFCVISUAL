using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _022_WCFLibraryy
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Somadora" in both code and config file together.
    public class Somadora : ISomadora
    {

        public int Somar(int x, int y)
        {
            return x + y;
        }
    }
}
