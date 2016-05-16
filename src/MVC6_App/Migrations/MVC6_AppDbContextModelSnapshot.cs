using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MVC6_App.Models;

namespace MVC6_App.Migrations
{
    [DbContext(typeof(MVC6_AppDbContext))]
    partial class MVC6_AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC6_App.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName");

                    b.HasKey("CustomerId");
                });

            modelBuilder.Entity("MVC6_App.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("UserName");

                    b.Property<int>("UserNumber");

                    b.HasKey("UserId");
                });

            modelBuilder.Entity("MVC6_App.Models.User", b =>
                {
                    b.HasOne("MVC6_App.Models.Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
        }
    }
}
