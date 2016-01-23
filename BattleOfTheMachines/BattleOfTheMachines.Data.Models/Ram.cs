namespace BattleOfTheMachines.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ram
    {
        private const float PowerBalanceModifier = 0.8f;

        public Ram()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public float MemorySpeed { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public int Memory { get; set; }

        [NotMapped]
        public float Power
        {
            get
            {
                return (this.MemorySpeed * this.Memory) / PowerBalanceModifier;
            }
        }
    }
}