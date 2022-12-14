// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResourceManagementSystem.Infrastructure.Data;

#nullable disable

namespace ResourceManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Staffs", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Claims", (string)null);
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Category", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = "C001",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8246),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Food Items"
                        },
                        new
                        {
                            ID = "C002",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8270),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Clothing"
                        },
                        new
                        {
                            ID = "C003",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8271),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Electronic Appliances"
                        },
                        new
                        {
                            ID = "C004",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8273),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Art & Music"
                        },
                        new
                        {
                            ID = "C005",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8274),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Sport Accessories"
                        });
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Order", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StaffID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ID");

                    b.HasIndex("StaffID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.OrderLine", b =>
                {
                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("LineTotal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Product", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = "P001",
                            CategoryID = "C001",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8584),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bread",
                            Price = 1.45m,
                            Quantity = 1000
                        },
                        new
                        {
                            ID = "P002",
                            CategoryID = "C001",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8587),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Eggs",
                            Price = 4.5m,
                            Quantity = 500
                        },
                        new
                        {
                            ID = "P003",
                            CategoryID = "C002",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8590),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Polo T-Shirt",
                            Price = 7.00m,
                            Quantity = 25
                        },
                        new
                        {
                            ID = "P004",
                            CategoryID = "C002",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8592),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Regular Jeans",
                            Price = 7.45m,
                            Quantity = 25
                        },
                        new
                        {
                            ID = "P005",
                            CategoryID = "C002",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8596),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Travel Joggers",
                            Price = 12m,
                            Quantity = 20
                        },
                        new
                        {
                            ID = "P006",
                            CategoryID = "C003",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8598),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Samsung Galaxy S22 Ultra",
                            Price = 250m,
                            Quantity = 15
                        },
                        new
                        {
                            ID = "P007",
                            CategoryID = "C003",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8600),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ASUS Zenbook",
                            Price = 1250m,
                            Quantity = 15
                        },
                        new
                        {
                            ID = "P008",
                            CategoryID = "C004",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8602),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lord of the Ring",
                            Price = 18.25m,
                            Quantity = 15
                        },
                        new
                        {
                            ID = "P009",
                            CategoryID = "C004",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8603),
                            LastModifiedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8604),
                            Name = "Fender Guitar",
                            Price = 100m,
                            Quantity = 12
                        },
                        new
                        {
                            ID = "P010",
                            CategoryID = "C005",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8605),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Hockey Stick",
                            Price = 125m,
                            Quantity = 15
                        },
                        new
                        {
                            ID = "P011",
                            CategoryID = "C005",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8606),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sports Wear",
                            Price = 50m,
                            Quantity = 15
                        },
                        new
                        {
                            ID = "P012",
                            CategoryID = "C005",
                            CreatedAt = new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8607),
                            LastModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Gym Hero",
                            Price = 75m,
                            Quantity = 20
                        });
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Staff", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("HiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Order", b =>
                {
                    b.HasOne("ResourceManagementSystem.Domain.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.OrderLine", b =>
                {
                    b.HasOne("ResourceManagementSystem.Domain.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceManagementSystem.Domain.Models.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Product", b =>
                {
                    b.HasOne("ResourceManagementSystem.Domain.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("ResourceManagementSystem.Domain.Models.Product", b =>
                {
                    b.Navigation("OrderLines");
                });
#pragma warning restore 612, 618
        }
    }
}
