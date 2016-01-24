namespace BattleOfTheMachines.Services.Data
{
    using System;
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Models.Enums;
    using BattleOfTheMachines.Data.Repositories;
    using BattleOfTheMachines.Services.Data.Contracts;

    public class QuestsService : IQuestsService
    { 
        private IRepository<Quest> quests;

        public QuestsService(IRepository<Quest> quests)
        {
            this.quests = quests;
        }

        public void Add(string name, string description, float duration, float powerRequired, byte[] image, PartType specialization)
        {
            var newQuest = new Quest
            {
                Name = name,
                Description = description,
                DurationInMinutes = duration,
                PowerRequired = powerRequired,
                Image = image,
                Specialization = specialization
            };

            this.quests.Add(newQuest);
            this.quests.SaveChanges();
        }
    }
}
