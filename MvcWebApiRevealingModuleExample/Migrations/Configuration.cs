namespace MvcWebApiRevealingModuleExample.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWebApiRevealingModuleExample.Models.ExampleDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcWebApiRevealingModuleExample.Models.ExampleDb context)
        {
            context.Examples.AddOrUpdate(v => v.TheWord,
                new Example() { TheWord = "Bird", Length = 72 },
                new Example() { TheWord = "GrandPrize", Length = 7200 });

            context.SaveChanges();
        }
    }
}
