using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuel.Models;
using Microsoft.EntityFrameworkCore;

namespace Fuel.InitData
{
    public class InitialValues
    {
        public static void Init(FuelDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (!context.esfFuelTypes.Any())
                    {
                        context.AddRange(
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
                                Code = 855,
                                Name = "Мазут(Сторонні організації)",
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
                                Name = "Донецький АШ",
                                IsHasIncome = true,
                                IsHasOutcome = true,
                                IsHasRemasins = true,
                                IsActive = true
                            },
                            new esfFuelTypes
                            {
                                Code = 1,
                                Name = "Донецьке вугілля",
                                IsHasIncome = true,
                                IsHasOutcome = true,
                                IsHasRemasins = true,
                                IsActive = true
                            }
                        );
                    };
                    context.SaveChanges();

                    if (!context.mnEnergyObjects.Any())
                    {
                        context.AddRange(
                            new mnEnergyObjects
                            {
                                eoCode = 1,
                                Name = "Трипільська ТЕС"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 12,
                                Name = "Київенерго ТЕЦ-5"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 16,
                                Name = "Київенерго ТЕЦ-6"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 79,
                                Name = "Київенерго ПКТС"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 10,
                                Name = "Дарницька ТЕЦ"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 11,
                                Name = "Черкаська ТЕЦ"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 13,
                                Name = "Чернігівська ТЕЦ"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 17,
                                Name = "Білоцерківська ТЕЦ"
                            },
                            new mnEnergyObjects
                            {
                                eoCode = 15,
                                Name = "Уманський ТК"
                            }
                        );
                    };
                    context.SaveChanges();

                    if (!context.mnEnergyObjectFiles.Any())
                    {
                        context.AddRange(
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 1).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "TPTC",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 12).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "TEC5",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 16).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "TEC6",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 79).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "PKTS",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 10).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "DTEC",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 11).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "CKTC",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 13).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "CNTC",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 17).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "BCTC",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            },
                            new mnEnergyObjectFiles
                            {
                                eoID = context.mnEnergyObjects.Where(eo => eo.eoCode == 15).First().eoID,
                                Path = "D:\\Test\\Palyvo",
                                Filename = "UMTK",
                                DateFormat = "ddmm",
                                FileExt = "txt",
                                IsDefault = true
                            }
                        );
                    };
                    context.SaveChanges();

                    if (!context.mnEnergyObjectFuel.Any())
                    {
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 1).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID);
                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);

                        AddFuelType(context, context.mnEnergyObjects.First(eo => eo.eoCode == 15).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID);
                    };
                    context.SaveChanges();

                    if (!context.esfDailyFuel.Any())
                    {
                        esfDailyFuel Doc;
                        context.Add(
                            Doc = new esfDailyFuel
                            {
                                dcNo = "Паливо1",
                                dcDate = DateTime.Parse("01.08.2019"),
                                dcType = "Паливо",
                                emID = 3
                            }
                        );
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 590, 8000, 254830, "TPTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 8, 2613, "TPTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 79, 0, "TPTC0108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 33310, "TEC50108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 515, 0, "TEC50108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID, 0, 0, 170, "TEC50108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 13242, "TEC60108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 19, 0, "TEC60108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID, 0, 0, 0, "TEC60108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 883, 54600, "DTEC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 894, "DTEC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 130, 0, "DTEC0108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 1).fuID, 0, 0, 63462, "CKTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 0, "CKTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 215, 0, "CKTC0108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 791, 96755, "CNTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 0, "CNTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 93, 0, "CNTC0108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 1136, "BCTC0108.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 482, 0, "BCTC0108.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 15).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 11, 0, "UMTK0108.txt");
                        context.Add(
                            Doc = new esfDailyFuel
                            {
                                dcNo = "Паливо2",
                                dcDate = DateTime.Parse("02.08.2019"),
                                dcType = "Паливо",
                                emID = 3,
                                Comment = "lalala"
                            }
                        );
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 6056, 248774, "TPTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 2613, "TPTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 12, 0, "TPTC0208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 33310, "TEC50208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 512, 0, "TEC50208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID, 0, 0, 170, "TEC50208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 13242, "TEC60208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 19, 0, "TEC60208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID, 0, 0, 0, "TEC60208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 1000, 53600, "DTEC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 894, "DTEC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 130, 0, "DTEC0208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 1).fuID, 0, 0, 63462, "CKTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 0, "CKTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 214, 0, "CKTC0208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 850, 95905, "CNTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 0, "CNTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 92, 0, "CNTC0208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 1136, "BCTC0208.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 448, 0, "BCTC0208.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 15).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 7, 0, "UMTK0208.txt");
                        context.Add(
                            Doc = new esfDailyFuel
                            {
                                dcNo = "Паливо3",
                                dcDate = DateTime.Parse("03.08.2019"),
                                dcType = "Паливо",
                                emID = 4,
                            }
                        );
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 747, 5550, 243971, "TPTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 8, 2605, "TPTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 1).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 45, 0, "TPTC0308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 33310, "TEC50308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 509, 0, "TEC50308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 12).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID, 0, 0, 170, "TEC50308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 13242, "TEC60308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 19, 0, "TEC60308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 16).eoID, context.esfFuelTypes.First(ft => ft.Code == 855).fuID, 0, 0, 0, "TEC60308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 79).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 0, 0, "PKTS0308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 1000, 52600, "DTEC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 894, "DTEC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 10).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 140, 0, "DTEC0308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 1).fuID, 0, 0, 63462, "CKTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 0, "CKTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 11).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 226, 0, "CKTC0308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 940, 94965, "CNTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 0, "CNTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 13).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 107, 0, "CNTC0308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 55).fuID, 0, 0, 1136, "BCTC0308.txt");
                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 17).eoID, context.esfFuelTypes.First(ft => ft.Code == 65).fuID, 0, 453, 0, "BCTC0308.txt");

                        AddItems(context, Doc.dcID, context.mnEnergyObjects.First(eo => eo.eoCode == 15).eoID, context.esfFuelTypes.First(ft => ft.Code == 41).fuID, 0, 10, 0, "UMTK0308.txt");
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            };
        }

        private static void AddFuelType(FuelDbContext context, int eoID, int fuID)
        {
            if (!context.mnEnergyObjectFuel.Where(of => (of.fuID == fuID) && (of.eoID == eoID)).Any())
            {
                context.Add(
                    new mnEnergyObjectFuel
                    {
                        eoID = eoID,
                        fuID = fuID
                    }
                );
            }
        }

        private static void AddItems(FuelDbContext context, int dcID, int eoID, int fuID, int income, int outcome, int remains, string filename)
        {
            if (!context.esfDailyFuelItems.Where(i => i.dcID == dcID).Any())
            {
                context.Add(
                    new esfDailyFuelItems
                    {
                        dcID = dcID,
                        eoID = eoID,
                        fuID = fuID,
                        FileName = filename,
                        Income = income,
                        Outcome = outcome,
                        Remains = remains
                    }
                );
            }
        }
    }
}
