namespace BattleOfTheMachines.WebForms.Models
{
    public class GraphicsViewModel
    {
        public string Id { get; set; }
        
        public string Model { get; set; }
        
        public float CoreSpeed { get; set; }
        
        public ushort Cores { get; set; }
        
        public int VideoMemory { get; set; }

        public float Price { get; set; }

        public bool CanBuy { get; set; }
    }
}