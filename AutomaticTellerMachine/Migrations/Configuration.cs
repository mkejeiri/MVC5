using System.Data.Entity.Migrations;
using AutomaticTellerMachine.Customs;
using AutomaticTellerMachine.Models;

namespace AutomaticTellerMachine.Migrations
{
   
    internal sealed class Configuration : DbMigrationsConfiguration<AutomaticTellerMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AutomaticTellerMachine.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.ApplySeed();
        }
    }
}
