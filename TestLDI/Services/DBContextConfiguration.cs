using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TestLDI.Entities;

namespace TestLDI.Services
{
    public class DBContextConfiguration : IDBContextConfiguration
    {
        private readonly TestLDI_Context Context;
        public readonly IConfiguration Configuration;
        private readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// DataBaseName: Contiene la información de la base de datos.
        /// </summary>
        public string DataBaseName { get; set; }


        /// <summary>
        /// DBContextConfiguration: Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        /// <param name="serviceProvider"></param>
        public DBContextConfiguration(TestLDI_Context context, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Context = context;
            Configuration = configuration;
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// InstallDBContext: Indica si se creo la base de datos
        /// </summary>
        /// <returns></returns>
        public bool InstallDBContext()
        {
            var DBStatus = Initialize();

            if (DBStatus == TaskStatus.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Initialize: Crea la base de datos y aplica las migraciones pendientes
        /// </summary>
        /// <returns></returns>
        private TaskStatus Initialize()
        {
            try
            {
                var context = ServiceProvider.GetRequiredService<TestLDI_Context>();
                context.Database.Migrate();
                DataBaseName = context.Database.GetDbConnection().Database;
                return TaskStatus.Created;
            }
            catch (Exception)
            {
                return TaskStatus.Faulted;
            }
        }        
    }
}