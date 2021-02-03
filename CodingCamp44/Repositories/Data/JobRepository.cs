using CodingCamp44.Context;
using CodingCamp44.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Repositories.Data
{
    public class JobRepository : GeneralRepository <Job, MyContext, int>
    {
        MyContext context;
        public JobRepository(MyContext myContext) : base(myContext) 
        {
            context = myContext;
        }
    }
}
