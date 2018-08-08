using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestLDI.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestLDI_Context>
    {
        /// <summary>
        /// CreateDbContext: Crea la cadena de conexión en tiempo de ejecución
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public TestLDI_Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TestLDI_Context>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new TestLDI_Context(builder.Options);
        }
    }
}
