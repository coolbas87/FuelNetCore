using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuel.Models;

namespace Fuel.InitData
{
    public class InitialValues
    {
        public static void Init(FuelDbContext content)
        {
            if (!content.esfFuelTypes.Any())
            {
                content.AddRange(
                    new esfFuelTypes
                    {
                        Code = 55,
                        Name = "Мазут",
                        IsHasIncome = true,
                        IsHasOutcome = true,
                        IsHasRemasins = true,
                        IsActive = true
                    },
                    new esfFuelTypes
                    {
                        Code = 65,
                        Name = "Газ",
                        IsHasIncome = false,
                        IsHasOutcome = false,
                        IsHasRemasins = true,
                        IsActive = true
                    },
                    new esfFuelTypes
                    {
                        Code = 41,
                        Name = "Вугілля",
                        IsHasIncome = true,
                        IsHasOutcome = true,
                        IsHasRemasins = true,
                        IsActive = true
                    }
                );
            }

            if (!content.esfDailyFuel.Any())
            {
                content.AddRange(
                    new esfDailyFuel
                    {
                        dcNo = "Паливо1",
                        dcDate = DateTime.Parse("01.08.2019"),
                        dcType = "Паливо",
                        emID = 3,
                    },
                    new esfDailyFuel
                    {
                        dcNo = "Паливо2",
                        dcDate = DateTime.Parse("02.08.2019"),
                        dcType = "Паливо",
                        emID = 3,
                        Comment = "lalala"
                    }
                );
            }

            content.SaveChanges();
        }
    }
}
