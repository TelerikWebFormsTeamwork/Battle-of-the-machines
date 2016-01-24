namespace BattleOfTheMachines.Services.Data.Contracts
{
    public interface IGpusService
    {
        void Add(string model, float coreSpeed, ushort cores, byte[] image, int videoMemory);
    }
}
