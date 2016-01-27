namespace BattleOfTheMachines.Services.Data
{
    using System;
    using System.Linq;

    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Models.Enums;
    using BattleOfTheMachines.Data.Repositories;
    using BattleOfTheMachines.Services.Data.Contracts;

    public class QuestsService: IQuestsService
    {
        private IRepository<Quest> quests;
        private IRepository<Motherboard> motherboards;

        public QuestsService(IRepository<Quest> quests, IRepository<Motherboard> motherboards)
        {
            this.quests = quests;
            this.motherboards = motherboards;
        }

        public IQueryable<Quest> GetQuestsOfType(PartType type)
        {
            return this.quests.All().Where(q => q.Specialization == type);
        }

        public void StartQuest(string name, string ownerId)
        {
            var questDuration = quests.All().Where(q => q.Name == name).FirstOrDefault().DurationInMinutes;

            var motherboard = motherboards.All()
                .Where(m => m.OwnerId == ownerId)
                .FirstOrDefault();

            motherboard.OnQuestUntil = DateTime.Now.AddMinutes(questDuration);

            motherboards.Update(motherboard);
            motherboards.SaveChanges();
        }

        public void FinishQuest(string ownerId)
        {
            var motherboard = motherboards.All()
                .Where(m => m.OwnerId == ownerId)
                .FirstOrDefault();

            motherboard.OnQuestUntil = null;
            //motherboard.Currency += 
            motherboards.Update(motherboard);
            motherboards.SaveChanges();


        }

        public void Add(string name, string description, int duration, float powerRequired, byte[] image, PartType specialization)
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
