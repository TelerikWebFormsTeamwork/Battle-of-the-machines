namespace BattleOfTheMachines.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Motherboard
    {
        public Motherboard()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Owner")]
        [Required]
        public string OwnerId { get; set; }
        
        public virtual User Owner { get; set; }

        [ForeignKey("GraphicsCard")]
        [Required]
        public Guid GraphicsCardId { get; set; }

        public virtual GraphicsCard GraphicsCard { get; set; }
        
        [ForeignKey("Processor")]
        [Required]
        public Guid ProcessorId { get; set; }

        public virtual Cpu Processor { get; set; }

        [ForeignKey("Ram")]
        [Required]
        public Guid RamId { get; set; }

        public virtual Ram Ram { get; set; }

        [ForeignKey("Network")]
        [Required]
        public Guid NetworkId { get; set; }

        public Network Network { get; set; }
    }
}
