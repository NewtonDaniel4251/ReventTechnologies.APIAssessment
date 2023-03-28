using EF.Core.Repository.Interface.Manager;
using ReventTechnologies.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReventTechnologies.Data.Interfaces.Manager
{
    public interface IRegistrationManager:ICommonManager<Registration>
    {
        Registration GetById(int id);
         

    }
}
