namespace BattleOfTheMachines.Data.Models
{
    using System;
    using System.ComponentModel;
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
        public string GraphicsCardId { get; set; }

        public virtual GraphicsCard GraphicsCard { get; set; }
        
        [ForeignKey("Processor")]
        [Required]
        public string ProcessorId { get; set; }

        public virtual Cpu Processor { get; set; }

        [ForeignKey("Ram")]
        [Required]
        public string RamId { get; set; }

        public virtual Ram Ram { get; set; }
        
        [DefaultValue(0)]
        public int Currency { get; set; }

        [ForeignKey("Network")]
        [Required]
        public string NetworkId { get; set; }

        public virtual Network Network { get; set; }

        public DateTime? OnQuestUntil { get; set; }

        public int CurrentQuestReward { get; set; }
    }
}
