namespace BattleOfTheMachines.Services.Data
{
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Repositories;
    using BattleOfTheMachines.Services.Data.Contracts;

    public class GpusService : IGpusService
    {
        private IRepository<GraphicsCard> gpus;

        public GpusService(IRepository<GraphicsCard> gpus)
        {
            this.gpus = gpus;
        }

        public void Add(string model, float coreSpeed, ushort cores, byte[] image, int videoMemory)
        {
            var newGpu = new GraphicsCard
            {
                Model = model,
                CoreSpeed = coreSpeed,
                Cores = cores,
                Image = image,
                VideoMemory = videoMemory
            };

            this.gpus.Add(newGpu);
            this.gpus.SaveChanges();
        }
    }
}
