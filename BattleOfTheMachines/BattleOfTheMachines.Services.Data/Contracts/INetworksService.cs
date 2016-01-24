namespace BattleOfTheMachines.Services.Data.Contracts
{
    public interface INetworksService
    {
        void Add(string type, float speed, byte[] image);
    }
}
