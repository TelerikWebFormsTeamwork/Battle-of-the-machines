namespace BattleOfTheMachines.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cpu
    {
        private const float PowerBalanceModifier = 0.8f;

        public Cpu()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public float CoreSpeed { get; set; }

        [Required]
        [Range(1, 8)]
        public int Cores { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [NotMapped]
        public float Power
        {
            get
            {
                return (this.CoreSpeed * this.Cores) / PowerBalanceModifier;
            }
        }
    }
}