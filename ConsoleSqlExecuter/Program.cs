using System.Configuration;
using Autofac;
using ConsoleSqlExcecuter.Models;
using ConsoleSqlExcecuter.Workers;


namespace ConsoleSqlExcecuter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            var localConnectionString = connectionStrings["LocalConnectionString"].ConnectionString;
            var root = ConfigurationManager.AppSettings["Root"];
            var rootFolder = ConfigurationManager.AppSettings["RootFolder"];
            var destinationFolder = ConfigurationManager.AppSettings["DestinationFolder"];
            
            var @params = new FileReaderParam(root, rootFolder, destinationFolder);


            using (var container = ContainerConfiguration.InitContainer(localConnectionString,  @params))
            {
                container.Resolve<IWorker>().Work();
            }
        }
    }
}
