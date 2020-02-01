﻿// <auto-generated />
using System;
using Fuel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fuel.Migrations
{
    [DbContext(typeof(FuelDbContext))]
    partial class FuelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.dcID", "'dcID', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.dfiID", "'dfiID', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.eofID", "'eofID', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.eoflID", "'eoflID', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.eoID", "'eoID', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.fuID", "'fuID', '', '1', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fuel.Models.dcDocuments", b =>
                {
                    b.Property<int>("dcID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR dcID");

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CreateBy");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime>("EditAt");

                    b.Property<int>("EditBy");

                    b.Property<byte[]>("HIID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("dcDate");

                    b.Property<string>("dcNo")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("dcType")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("emID");

                    b.HasKey("dcID");

                    b.ToTable("dcDocuments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("dcDocuments");
                });

            modelBuilder.Entity("Fuel.Models.esfDailyFuelItems", b =>
                {
                    b.Property<int>("dfiID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR dfiID");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("EditAt");

                    b.Property<int>("EditBy");

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<byte[]>("HIID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("Income");

                    b.Property<int>("Outcome");

                    b.Property<int>("Remains");

                    b.Property<int>("dcID");

                    b.Property<int>("eoID");

                    b.Property<int>("fuID");

                    b.HasKey("dfiID");

                    b.HasIndex("dcID");

                    b.HasIndex("eoID");

                    b.HasIndex("fuID");

                    b.ToTable("esfDailyFuelItems");
                });

            modelBuilder.Entity("Fuel.Models.esfFuelTypes", b =>
                {
                    b.Property<int>("fuID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR fuID");

                    b.Property<int>("Code");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("EditAt");

                    b.Property<int>("EditBy");

                    b.Property<byte[]>("HIID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool>("IsHasIncome")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsHasOutcome")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsHasRemains")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("fuID");

                    b.ToTable("esfFuelTypes");
                });

            modelBuilder.Entity("Fuel.Models.mnEnergyObjectFiles", b =>
                {
                    b.Property<int>("eoflID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR eoflID");

                    b.Property<string>("DateFormat")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("FileExt")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<byte[]>("HIID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<int>("eoID");

                    b.HasKey("eoflID");

                    b.HasIndex("eoID");

                    b.ToTable("mnEnergyObjectFiles");
                });

            modelBuilder.Entity("Fuel.Models.mnEnergyObjectFuel", b =>
                {
                    b.Property<int>("eofID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR eofID");

                    b.Property<byte[]>("HIID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("eoID");

                    b.Property<int>("fuID");

                    b.HasKey("eofID");

                    b.HasIndex("eoID");

                    b.HasIndex("fuID");

                    b.ToTable("mnEnergyObjectFuel");
                });

            modelBuilder.Entity("Fuel.Models.mnEnergyObjects", b =>
                {
                    b.Property<int>("eoID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR eoID");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CreateBy");

                    b.Property<DateTime>("EditAt");

                    b.Property<int>("EditBy");

                    b.Property<byte[]>("HIID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("eoCode");

                    b.HasKey("eoID");

                    b.ToTable("mnEnergyObjects");
                });

            modelBuilder.Entity("Fuel.Models.esfDailyFuel", b =>
                {
                    b.HasBaseType("Fuel.Models.dcDocuments");

                    b.HasDiscriminator().HasValue("esfDailyFuel");
                });

            modelBuilder.Entity("Fuel.Models.esfDailyFuelItems", b =>
                {
                    b.HasOne("Fuel.Models.esfDailyFuel", "esfDailyFuel")
                        .WithMany("Items")
                        .HasForeignKey("dcID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fuel.Models.mnEnergyObjects", "mnEnergyObjects")
                        .WithMany()
                        .HasForeignKey("eoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fuel.Models.esfFuelTypes", "esfFuelTypes")
                        .WithMany()
                        .HasForeignKey("fuID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fuel.Models.mnEnergyObjectFiles", b =>
                {
                    b.HasOne("Fuel.Models.mnEnergyObjects", "mnEnergyObjects")
                        .WithMany()
                        .HasForeignKey("eoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fuel.Models.mnEnergyObjectFuel", b =>
                {
                    b.HasOne("Fuel.Models.mnEnergyObjects", "mnEnergyObjects")
                        .WithMany()
                        .HasForeignKey("eoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fuel.Models.esfFuelTypes", "esfFuelTypes")
                        .WithMany()
                        .HasForeignKey("fuID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
