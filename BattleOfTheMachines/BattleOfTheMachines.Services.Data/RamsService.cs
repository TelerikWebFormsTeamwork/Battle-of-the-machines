namespace BattleOfTheMachines.Services.Data
{
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Repositories;
    using BattleOfTheMachines.Services.Data.Contracts;

    public class RamsService : IRamsService
    {
        private IRepository<Ram> rams;

        public RamsService(IRepository<Ram> rams)
        {
            this.rams = rams;
        }

        public void Add(string model, float memorySpeed, byte[] image, int memory)
        {
            var newRam = new Ram
            {
                Model = model,
                MemorySpeed = memorySpeed,
                Memory = memory,
                Image = image
            };

            this.rams.Add(newRam);
            this.rams.SaveChanges();
        }
    }
}
