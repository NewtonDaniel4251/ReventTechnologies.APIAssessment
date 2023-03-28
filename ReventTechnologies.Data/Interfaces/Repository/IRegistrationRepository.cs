using EF.Core.Repository.Interface.Repository;
using ReventTechnologies.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReventTechnologies.Data.Interfaces.Repository
{
    public interface IRegistrationRepository:ICommonRepository<Registration>
    {
    }
}
