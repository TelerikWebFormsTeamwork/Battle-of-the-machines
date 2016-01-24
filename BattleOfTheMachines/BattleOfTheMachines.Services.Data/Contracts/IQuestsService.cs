namespace BattleOfTheMachines.Services.Data.Contracts
{
    using BattleOfTheMachines.Data.Models.Enums;

    public interface IQuestsService
    {
        void Add(string name, string description, float duration, float powerRequired, byte[] image, PartType specialization);
    }
}
