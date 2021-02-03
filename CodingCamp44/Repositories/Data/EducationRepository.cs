using CodingCamp44.Context;
using CodingCamp44.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Repositories.Data
{
    public class EducationRepository : GeneralRepository<Education, MyContext, int>
    {
        public EducationRepository(MyContext myContext) : base(myContext)
        {

        }
    }

}
