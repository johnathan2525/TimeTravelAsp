using System;
using System.Data.Entity.Migrations;
using TimeTravelAsp.Models;

namespace TimeTravelAsp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TimeTravelAspContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TimeTravelAspContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Transporters.AddOrUpdate(
                new Transporter {Name = "DeLorean"},
                new Transporter {Name = "Phone Booth"}
            );

            context.SaveChanges();

            context.Passengers.AddOrUpdate(
                new Passenger
                {
                    Name = "Marty McFly",
                    PositionInTime = new DateTime(2015, 10, 21),
                    Destination = "Hill Valley",
                    TransporterId = 1
                },
                new Passenger
                {
                    Name = "Emmett Brown",
                    PositionInTime = new DateTime(1885, 9, 2),
                    Destination = "Old West",
                    TransporterId = 1
                },
                new Passenger
                {
                    Name = "Jennifer Parker",
                    PositionInTime = new DateTime(1985, 7, 3),
                    Destination = "The 80s",
                    TransporterId = 1
                },
                new Passenger
                {
                    Name = "Bill S. Preston, Esquire",
                    PositionInTime = new DateTime(1985, 7, 3),
                    Destination = "The 80s",
                    TransporterId = 2
                },
                new Passenger
                {
                    Name = "Ted 'Theodore' Logan",
                    PositionInTime = new DateTime(1985, 7, 3),
                    Destination = "The 80s",
                    TransporterId = 2
                }
            );

            context.SaveChanges();

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}