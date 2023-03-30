using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using ReventTechnologies.Data.Context;
using ReventTechnologies.Data.Interfaces.Manager;
using ReventTechnologies.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReventTechnologies.Data.Manager
{
    public class RegistrationManger : CommonManager<Registration>, IRegistrationManager
    {
        private readonly ApplicationDBContext Db;

        public RegistrationManger(ApplicationDBContext _dBContext) : base(new RegistrationRepository(_dBContext))
        {
          Db = _dBContext;
        }

        public Registration GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);      

           
        }

       
    }
}
