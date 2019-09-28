using Autofac;
using ConsoleSqlExcecuter.Gateways;
using ConsoleSqlExcecuter.Models;
using ConsoleSqlExcecuter.Readers;
using ConsoleSqlExcecuter.Workers;

namespace ConsoleSqlExcecuter
{
    public static class ContainerConfiguration
    {
        public static IContainer InitContainer(string localConnectionString, FileReaderParam @params)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileReader>()
                .WithParameter(new TypedParameter(typeof(FileReaderParam), @params))
                .As<IFileReader>();

            builder.RegisterType<Gateway>()
                .WithParameter(new TypedParameter(typeof(IDataReader), new DataReader(localConnectionString)));

           builder.RegisterType<Worker>().As<IWorker>();

            return builder.Build();
        }
    }
}
