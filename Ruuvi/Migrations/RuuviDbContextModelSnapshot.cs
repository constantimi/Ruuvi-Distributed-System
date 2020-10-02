using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ruuvi.Data;

namespace Ruuvi.Migrations
{
    [DbContext(typeof(RuuviDbContext))]
    partial class RuuviDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ruuvi.Models.Location", b =>
                {
                    b.Property<int>("IdLocation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Accuracy")
                        .HasColumnType("double");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.HasKey("IdLocation");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Ruuvi.Models.RuuviStation", b =>
                {
                    b.Property<int>("IdStation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BatteryLevel")
                        .HasColumnType("int");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<int>("LocationIdLocation")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdStation");

                    b.HasIndex("LocationIdLocation");

                    b.ToTable("RuuviStations");
                });

            modelBuilder.Entity("Ruuvi.Models.Tag", b =>
                {
                    b.Property<int>("IdTag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AccelX")
                        .HasColumnType("double");

                    b.Property<double>("AccelY")
                        .HasColumnType("double");

                    b.Property<double>("AccelZ")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DataFormat")
                        .HasColumnType("int");

                    b.Property<int>("DefaultBackground")
                        .HasColumnType("int");

                    b.Property<bool>("Favorite")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Humidity")
                        .HasColumnType("double");

                    b.Property<double>("HumidityOffset")
                        .HasColumnType("double");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<int>("MeasurementSequenceNumber")
                        .HasColumnType("int");

                    b.Property<int>("MovementCounter")
                        .HasColumnType("int");

                    b.Property<long>("Pressure")
                        .HasColumnType("bigint");

                    b.Property<int>("Rssi")
                        .HasColumnType("int");

                    b.Property<int?>("RuuviStationIdStation")
                        .HasColumnType("int");

                    b.Property<double>("Temperature")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Voltage")
                        .HasColumnType("double");

                    b.Property<int>("txPower")
                        .HasColumnType("int");

                    b.HasKey("IdTag");

                    b.HasIndex("RuuviStationIdStation");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Ruuvi.Models.RuuviStation", b =>
                {
                    b.HasOne("Ruuvi.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationIdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ruuvi.Models.Tag", b =>
                {
                    b.HasOne("Ruuvi.Models.RuuviStation", null)
                        .WithMany("Tags")
                        .HasForeignKey("RuuviStationIdStation");
                });
#pragma warning restore 612, 618
        }
    }
}
