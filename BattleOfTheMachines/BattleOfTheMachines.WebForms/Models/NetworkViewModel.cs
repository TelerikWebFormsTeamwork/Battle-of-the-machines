namespace BattleOfTheMachines.WebForms.Models
{
    public class NetworkViewModel
    {
        public string Id { get; set; }
        
        public string Type { get; set; }

        public float Speed { get; set; }

        public float Price { get; set; }

        public bool CanBuy { get; set; }
    }
}