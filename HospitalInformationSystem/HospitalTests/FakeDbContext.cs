using HospitalClassLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests
{
    public class FakeDbContext
    {
        public static MyDbContext InitFakeContext()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "fake").Options;
            var context = new MyDbContext(options);
            return context;
        }
    }
}
