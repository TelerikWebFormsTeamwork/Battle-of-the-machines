namespace BattleOfTheMachines.WebForms.Models
{
    public class RamViewModel
    {
        public string Id { get; set; }
        
        public string Model { get; set; }
        
        public float MemorySpeed { get; set; }

        public int Memory { get; set; }

        public float Price { get; set; }

        public bool CanBuy { get; set; }
    }
}