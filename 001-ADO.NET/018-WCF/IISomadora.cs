using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _018_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IISomadora" in both code and config file together.
    [ServiceContract]
    public interface IISomadora
    {
        [OperationContract]
        double Somar(double x, double y);
    }
}
