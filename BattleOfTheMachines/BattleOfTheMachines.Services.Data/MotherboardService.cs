namespace BattleOfTheMachines.Services.Data
{
    using System;
    using System.Linq;

    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Repositories;
    using BattleOfTheMachines.Services.Data.Contracts;

    public class MotherboardService: IMotherboardService
    {
        private IRepository<Motherboard> motherboards;

        public MotherboardService(IRepository<Motherboard> motherboards)
        {
            this.motherboards = motherboards;
        }

        public DateTime? GetQuestTimerById(string id)
        {
            var timer = motherboards.All()
                .Where(m => m.OwnerId == id)
                .Select(m => m.OnQuestUntil)
                .FirstOrDefault();

            return timer;
        }

        public Motherboard GetMotherboardByOwnerId(string id)
        {
            var motherboard = motherboards.All()
                .Where(m => m.OwnerId == id)
                .FirstOrDefault();

            return motherboard;
        }
    }
}
