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

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        [ForeignKey("GraphicsCard")]
        public Guid GraphicsCardId { get; set; }

        [Required]
        public virtual GraphicsCard GraphicsCard { get; set; }
        
        [ForeignKey("Processor")]
        public Guid ProcessorId { get; set; }

        public virtual Cpu Processor { get; set; }

        [ForeignKey("Ram")]
        public Guid RamId { get; set; }

        public virtual Ram Ram { get; set; }

        [ForeignKey("Network")]
        public Guid NetworkId { get; set; }

        public Network Network { get; set; }

        public DateTime? OnQuestUntil { get; set; }
    }
}
