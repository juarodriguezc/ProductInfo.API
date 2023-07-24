using Microsoft.EntityFrameworkCore;
using ProductsInfo.Entities;

namespace ProductsInfo.DbContexts
{
    /// <summary>
    /// DbContext for the ProductInfoAPI
    /// </summary>
    public class ProductInfoContext : DbContext
    {
        /// <summary>
        /// DBSet for the Products
        /// </summary>
        public DbSet<Product> Products { get; set; } = null!;

        /// <summary>
        /// DbContext Constructor with the DB options
        /// </summary>
        /// <param name="options">Options of the db</param>
        public ProductInfoContext(DbContextOptions<ProductInfoContext> options) 
            : base(options) { }


        /// <summary>
        /// OnModelCreating Function to Seed the db
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Description = "Kia Sportage 2020",
                        Price = 95000000,
                        ProductType = ProductType.Vehiculos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 2019, month: 12, day: 20, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 2,
                        Description = "Apartamento Chicó",
                        Price = 450000000,
                        ProductType = ProductType.Apartamentos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 2010, month: 01, day: 15, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 3,
                        Description = "Chevrolet Tracker 2022",
                        Price = 125000000,
                        ProductType = ProductType.Vehiculos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 2021, month: 01, day: 20, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 4,
                        Description = "Casa Usaquen",
                        Price = 700000000,
                        ProductType = ProductType.Apartamentos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 2005, month: 01, day: 20, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 5,
                        Description = "Anillo Oro",
                        Price = 1500000,
                        ProductType = ProductType.Bienes,
                        State = ProductState.Inactive,
                        PurchaseDate = new DateTimeOffset(year: 2010, month: 01, day: 15, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 6,
                        Description = "Lote Sogamoso, Boyacá",
                        Price = 110000000,
                        ProductType = ProductType.Terrenos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 1998, month: 04, day: 15, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 7,
                        Description = "Lote Moniquira, Boyaca",
                        Price = 90000000,
                        ProductType = ProductType.Terrenos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 2013, month: 11, day: 18, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    },
                    new Product
                    {
                        Id = 8,
                        Description = "Reloj Rolex 1995",
                        Price = 12000000,
                        ProductType = ProductType.Bienes,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 1996, month: 08, day: 25, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    }, new Product
                    {
                        Id = 9,
                        Description = "Mazda 6 2008",
                        Price = 25000000,
                        ProductType = ProductType.Vehiculos,
                        State = ProductState.Active,
                        PurchaseDate = new DateTimeOffset(year: 2007, month: 01, day: 15, hour: 0, minute: 0, second: 0, offset: new TimeSpan(-5, 0, 0))
                    }
                );
            
            // Conversion Enum Type Product Type
            modelBuilder
                .Entity<Product>()
                .Property( e => e.ProductType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ProductType)Enum.Parse(typeof(ProductType), v));

            modelBuilder
                .Entity<Product>()
                .Property(e => e.State)
                .HasConversion(
                    v => v.ToString(),
                    v => (ProductState)Enum.Parse(typeof(ProductState), v));


            base.OnModelCreating(modelBuilder);
        }
    }
}
