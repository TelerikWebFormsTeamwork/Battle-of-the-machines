namespace BattleOfTheMachines.Services.Data
{
    using BattleOfTheMachines.Data.Models;
    using BattleOfTheMachines.Data.Repositories;
    using Contracts;

    public class NetworksService : INetworksService
    {
        private IRepository<Network> networks;

        public NetworksService(IRepository<Network> networks)
        {
            this.networks = networks;
        }

        public void Add(string type, float speed, byte[] image)
        {
            var newNetwork = new Network
            {
                Type = type,
                Speed = speed,
                Image = image
            };

            this.networks.Add(newNetwork);
            this.networks.SaveChanges();
        }
    }
}
