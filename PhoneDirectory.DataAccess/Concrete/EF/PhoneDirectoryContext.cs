using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.DataAccess.Concrete.EF
{
    public class PhoneDirectoryContext:DbContext
    {
        public PhoneDirectoryContext(DbContextOptions<PhoneDirectoryContext> options)
            :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        enum InfoType
        {
            Phone,
            Email,
            Location
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasKey(x=>x.UserID);
            //modelBuilder.Entity<ContactInfo>().HasKey(x=>x.ContactInfoID);

            modelBuilder.Entity<User>().HasData(
                new User { 
                    UserID = 1,
                    Name = "Joey",
                    Surname = "Wayne",
                    Company = "ABC"},
                new User { UserID = 2,
                    Name = "Uma",
                    Surname = "Rabbit",
                    Company = "DEF",
                }
                );

            modelBuilder.Entity<ContactInfo>().HasData(
                        new ContactInfo() { 
                            ContactInfoID = 1,
                            InfoType = ((int)InfoType.Phone),
                            InfoContent = "1234567890",
                            UserID = 1 },
                        new ContactInfo() { 
                            ContactInfoID = 2,
                            InfoType = ((int)InfoType.Email),
                            InfoContent = "joey@email.com",
                            UserID = 1 },
                         new ContactInfo()
                         {
                             ContactInfoID = 3,
                             InfoType = ((int)InfoType.Phone),
                             InfoContent = "1234567890",
                             UserID = 2
                         },
                        new ContactInfo()
                        {
                            ContactInfoID = 4,
                            InfoType = ((int)InfoType.Location),
                            InfoContent = "Rome",
                            UserID = 2
                        }
                    );
        }
    }
}
