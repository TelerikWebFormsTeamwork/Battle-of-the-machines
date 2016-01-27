namespace BattleOfTheMachines.WebForms.Models
{
    public class CpuViewModel
    {
        public string Id { get; set; }
        
        public string Model { get; set; }
        
        public float CoreSpeed { get; set; }
        
        public int Cores { get; set; }
        
        public float Price { get; set; }

        public bool CanBuy { get; set; }
    }
}