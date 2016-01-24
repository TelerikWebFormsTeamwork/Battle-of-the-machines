namespace BattleOfTheMachines.Services.Data.Contracts
{
    using BattleOfTheMachines.Data.Models.Enums;

    public interface IQuestsService
    {
        void Add(string name, string description, float duration, byte[] image, PartType specialization);
    }
}
