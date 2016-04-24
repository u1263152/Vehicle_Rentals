namespace BC_Rentals.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BC_Rentals.Models;
    using BC_Rentals.DAL;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<BC_Rentals.DAL.VehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BC_Rentals.DAL.VehicleContext context)
        {
            var customers = new List<Customer>
           {
               new Customer {First_Name="Ben", Last_Name="Cox",
                   Email ="benjamin.cox@hotmail.co.uk",Phone="07875980748",
                   Postcode ="BD111DF", Licence="hskdhf7163hdh"}
           };

            customers.ForEach (c => context.Customer.AddOrUpdate(b => b.Last_Name, c));
            context.SaveChanges();

            var vehicles = new List<Vehicle>
           {
               new Vehicle{Vehicle_Manuf="Ford", Vehicle_Model="150",
                   Vehicle_Colour ="Red",Vehicle_Licence="YJ168BQ",
                   Vehicle_Rate = 120}
           };

            vehicles.ForEach(c => context.Vehicle.AddOrUpdate(b => b.Vehicle_Model, c));
            context.SaveChanges();

            var rentals = new List<Rental>
           {
               new Rental{Customer_ID = customers.Single( b => b.Last_Name == "Cox").Customer_ID,
                         Vehicle_ID =  vehicles.Single(b => b.Vehicle_Model == "150").Vehicle_ID,
                         Rental_Start =DateTime.Parse("2016-06-26"),
                         Rental_End = DateTime.Parse("2017-06-26") }

           };

            foreach (Rental r in rentals)
            {
                var rentalInDataBase = context.Rental.Where(
                    b =>
                        b.Customer.Customer_ID == r.Customer_ID &&
                        b.Vehicle.Vehicle_ID == r.Vehicle_ID).SingleOrDefault();
                if (rentalInDataBase == null)
                {
                    context.Rental.Add(r);
                }
            }
        
            context.SaveChanges();


        }
    }
}
