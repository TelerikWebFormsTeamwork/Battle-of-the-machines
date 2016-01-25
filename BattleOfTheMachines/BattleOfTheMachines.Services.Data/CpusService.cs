namespace BattleOfTheMachines.Services.Data
{
    using BattleOfTheMachines.Services.Data.Contracts;
    using BattleOfTheMachines.Data.Repositories;
    using BattleOfTheMachines.Data.Models;

    public class CpusService : ICpusService
    {
        private IRepository<Cpu> cpus;

        public CpusService(IRepository<Cpu> cpus)
        {
            this.cpus = cpus;
        }

        public void Add(string model, float coreSpeed, ushort cores, byte[] image)
        {
            var newCpu = new Cpu
            {
                Model = model,
                CoreSpeed = coreSpeed,
                Cores = cores,
                Image = image
            };

            this.cpus.Add(newCpu);
            this.cpus.SaveChanges();
        }
    }
}
