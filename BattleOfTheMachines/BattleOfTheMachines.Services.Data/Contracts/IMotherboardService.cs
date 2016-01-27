namespace BattleOfTheMachines.Services.Data.Contracts
{
    using System;
    using BattleOfTheMachines.Data.Models;

    public interface IMotherboardService
    {
        DateTime? GetQuestTimerById(string id);

        Motherboard GetMotherboardByOwnerId(string id);
    }
}
