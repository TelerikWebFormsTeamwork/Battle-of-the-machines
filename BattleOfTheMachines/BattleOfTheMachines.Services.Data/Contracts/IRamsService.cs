namespace BattleOfTheMachines.Services.Data.Contracts
{
    public interface IRamsService
    {
        void Add(string model, float memorySpeed, byte[] image, int memory);
    }
}
