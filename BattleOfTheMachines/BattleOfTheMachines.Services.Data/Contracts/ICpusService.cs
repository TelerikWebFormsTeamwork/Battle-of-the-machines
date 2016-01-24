namespace BattleOfTheMachines.Services.Data.Contracts
{
    public interface ICpusService
    {
        void Add(string model, float coreSpeed, ushort cores, byte[] image);
    }
}
