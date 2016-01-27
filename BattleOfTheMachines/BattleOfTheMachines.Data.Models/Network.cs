namespace BattleOfTheMachines.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Network
    {
        private const float PowerBalanceModifier = 0.8f;

        public Network()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Type { get; set; }

        public float Speed { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [NotMapped]
        public float Power
        {
            get
            {
                return this.Speed / PowerBalanceModifier;
            }
        }
    }
}