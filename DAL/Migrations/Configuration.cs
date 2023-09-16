namespace DAL.Migrations
{
    using DAL.EF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.PBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.PBContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //for (int i = 01; i <= 5; i++)
            //{
            //    User user = new User()
            //    {
            //        Name = $"name{i}",
            //        Email = $"email{i}@example.com",
            //        PhoneNumber = $"123-456-789{i}",
            //        UserName = $"user{i}",
            //        Password = "123",// "passwordHash", // Set the password hash or encryption here
            //        Role = "user{i}",
            //        IsDelete = false,
            //        IsBan = false

            //    };
            //    context.Users.Add(user);
            //    context.SaveChanges();
            //}
        }
    }
}
