using CodingCamp44.Context;
using CodingCamp44.Models;
using CodingCamp44.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CodingCamp44.Repositories.Data.JobRepository;

namespace CodingCamp44.Repositories.Data
{
    public class ProfilingRepository : GeneralRepository<Profiling, MyContext, string>
    {
        private readonly MyContext mycontext;

        public ProfilingRepository(MyContext myContext) : base(myContext)
        {
            this.mycontext = myContext;
        }
        public Profiling getByNIK(string NIK)
        {
            var result = mycontext.Profiling.Where(value => value.NIK == NIK).FirstOrDefault();
            return result;
        }
    }
}
