using System;
using Gramium.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Test.Base
{
    public class TestBase
    {
        public TestBase()
        {
        }

        public static GramiumDbContext GetDatabase()
        {
            var options = new DbContextOptionsBuilder<GramiumDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new GramiumDbContext(options);

            return db;
        }
    }
}
