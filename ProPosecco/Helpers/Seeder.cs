using Microsoft.AspNetCore.Identity;
using ProPosecco.Areas.Identity.Data;
using ProPosecco.Areas.Identity.Data.Entities;
using ProProsecco.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProPosecco.Helpers
{
    public class Seeder
    {
        public static void Seed(ProProseccoDbContext context)
        {
            SeedUsers();
            SeedRoles();
            SeedWines();

            void SeedUsers()
            {
                if (!context.Users.Any())
                {
                    List<User> users = new List<User>()
                    {
                        new User
                        {
                            Id = "310d8cc5-c850-41a9-bbf2-c1f9b5b9d0de",
                            UserName = "valeryia@vasilyeva.pl",
                            Email = "valeryia@vasilyeva.pl",
                            NormalizedUserName = "VALERYIA@VASILYEVA.PL",
                            NormalizedEmail = "VALERYIA@VASILYEVA.PL",
                            PasswordHash = "AQAAAAEAACcQAAAAENCF4jrj6oTe2RdEWUUFnCPNkHkb2rhFBNOGdU1epW/LDQYzzEs/dO18b2wkXx1klw==", // Admin123!
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = "0c059eb7-43c5-4a44-bbff-8865b0e60976",
                            LockoutEnabled = true,
                            UserDetails = new UserDetails()
                            {
                                FirstName = "Valeryia",
                                Surname = "Vasilyeva",
                                ZipCode = "00-930",
                                City = "Warszawa",
                                Street = "Mityczna",
                                HouseNumber = "3/11",
                            }
                        },
                        new User
                        {
                            Id = "fd98cb5e-d030-434a-93a6-815c996f001a",
                            UserName = "jan@kowalski.pl",
                            Email = "jan@kowalski.pl",
                            NormalizedUserName = "JAN@KOWALSKI.PL",
                            NormalizedEmail = "JAN@KOWALSKI.PL",
                            PasswordHash = "AQAAAAEAACcQAAAAEPTTna4g8dflaAqUl/rgZXm81YTD9+O0+GaWCoV/KfG1L9OvpzmFv/WT6QanaOFsLQ==", // H@slo1
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = "516d63aa-1bb5-4a72-aad0-8817ea80669f",
                            LockoutEnabled = true,
                            UserDetails = new UserDetails()
                            {
                                FirstName = "Jan",
                                Surname = "Kowalski",
                                ZipCode = "12-123",
                                City = "Warszawa",
                                Street = "Krowia",
                                HouseNumber = "1",
                            }
                        }
                    };

                    context.Users.AddRange(users);
                    context.SaveChanges();
                }
            }

            void SeedRoles()
            {
                if (!context.Roles.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        List<IdentityRole> roles = new List<IdentityRole>()
                        {
                            new IdentityRole
                            {
                                Id = "709e64ec-1c8e-4ad7-ae7d-fca1ec67d0fe",
                                Name = "Administrator",
                                NormalizedName = "ADMINISTRATOR"
                            },
                            new IdentityRole
                            {
                                Id = "b1c972d4-bafa-4006-931c-623e56f830cd",
                                Name = "User",
                                NormalizedName = "USER"
                            }
                        };

                        context.Roles.AddRange(roles);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                }

                // Roles assignments
                if (!context.UserRoles.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var users = context.Users.ToList();
                        var roles = context.Roles.ToList();

                        List<IdentityUserRole<string>> assignments = new List<IdentityUserRole<string>>()
                        {
                            new IdentityUserRole<string>
                            {
                                RoleId = roles[0].Id,
                                UserId = users[0].Id
                            },
                            new IdentityUserRole<string>
                            {
                                RoleId = roles[1].Id,
                                UserId = users[1].Id
                            }
                        };

                        context.UserRoles.AddRange(assignments);
                        context.SaveChanges();
                        transaction.Commit();
                    }  
                }
            }

            void SeedWines()
            {
                if (!context.Wines.Any())
                {
                    int wineNumber = 1;

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        List<Wine> wines = new List<Wine>();

                        using (StreamReader sr = new StreamReader("Helpers/SeederSources/wines.csv"))
                        {
                            string line = "";

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] values = line.Split(";");
                                byte[] photo = File.ReadAllBytes($"Helpers/SeederSources/wine{wineNumber}.jpg"); 
                                

                                wines.Add(new Wine()
                                {
                                    Name = values[0],
                                    ProductionCountry = (Country)Convert.ToInt32(values[1]),
                                    Color = (WineColor)Convert.ToInt32(values[2]),
                                    Taste = (WineTaste)Convert.ToInt32(values[3]),
                                    ProductionYear = Convert.ToInt32(values[4]),
                                    Price = Convert.ToDecimal(values[5]),
                                    Amount = Convert.ToInt32(values[6]),
                                    Description = values[7],
                                    Photo = photo,
                                    CreatedAt = DateTime.Now
                                });

                                wineNumber++;
                            }
                        }

                        context.Wines.AddRange(wines);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                }
            }
        }
    }
}
