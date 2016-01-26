namespace BattleOfTheMachines.Services.Data.Contracts
{
    using System.Linq;
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Models.Enums;

    public interface IQuestsService
    {
        IQueryable<Quest> GetQuestsOfType(PartType type);

        void StartQuest(string name, string ownerId);

        void Add(string name, string description, int duration, float powerRequired, byte[] image, PartType specialization);
    }
}
