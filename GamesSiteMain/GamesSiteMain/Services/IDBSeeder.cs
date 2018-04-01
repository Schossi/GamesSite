using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Services
{
    public interface IDBSeeder
    {
        Task SeedAsync();
    }
}
