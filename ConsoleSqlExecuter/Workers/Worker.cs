using System.Threading.Tasks;
using ConsoleSqlExcecuter.Gateways;

namespace ConsoleSqlExcecuter.Workers
{
    public class Worker : IWorker
    {
        private readonly Gateway _gateway;
       
        public Worker(Gateway gateway) 
        {
            _gateway = gateway;
        }

        public void Work()
        {
            _gateway.Execute();
        }
    }
}