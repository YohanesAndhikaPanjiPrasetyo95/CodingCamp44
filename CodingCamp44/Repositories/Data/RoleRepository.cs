using CodingCamp44.Context;
using CodingCamp44.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Repositories.Data
{
public class RoleRepository : GeneralRepository<Role, MyContext, int>
    {
        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}

