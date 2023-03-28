using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using ReventTechnologies.Data.Context;
using ReventTechnologies.Data.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReventTechnologies.Data.Repository
{
    public class RegistrationRepository : CommonRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
    }
}
