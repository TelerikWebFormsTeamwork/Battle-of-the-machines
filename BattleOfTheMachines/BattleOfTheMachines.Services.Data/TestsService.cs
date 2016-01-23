using BattleOfTheMachines.Data.Models;
using BattleOfTheMachines.Data.Repositories;
using BattleOfTheMachines.Services.Data.Contracts;
using System;

namespace BattleOfTheMachines.Services.Data
{
    public class TestsService : ITestsService
    {
        private IRepository<Test> tests;

        public TestsService(IRepository<Test> tests)
        {
            this.tests = tests;
        }

        public void Add(string name)
        {
            var newTest = new Test
            {
                Name = name
            };

            this.tests.Add(newTest);
            this.tests.SaveChanges();
        }
    }
}
