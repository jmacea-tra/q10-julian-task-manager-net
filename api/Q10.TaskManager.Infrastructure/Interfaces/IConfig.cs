using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Interfaces
{
    public interface IConfig
    {
        //Establecemos un contrato
        string GetValue(string key);
    }
}
