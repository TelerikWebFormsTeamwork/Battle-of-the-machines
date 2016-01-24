namespace BattleOfTheMachines.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BattleOfTheMachines.Data.Models.Enums;

    public class Quest
    {
        public Quest()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public float DurationInMinutes { get; set; }

        public byte[] Image { get; set; }

        public PartType Specialization { get; set; }

        [Required]
        public float PowerRequired { get; set; }
    }
}
