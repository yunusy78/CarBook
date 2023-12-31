﻿using CarBook.Domain.DTOs;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Context;

public class CarBookDbContext : DbContext
{
    
    
    
    
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarBook;Trusted_Connection=True; TrustServerCertificate=True;MultipleActiveResultSets=true");
        
    }
   
   
   
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       base.OnModelCreating(modelBuilder);
       modelBuilder.Entity<ReservationCar>()
           .HasOne(x=>x.PickUpLocation)
           .WithMany(x=>x.PickUpRentACars)
           .HasForeignKey(x=>x.PickUpLocationId)
           .OnDelete(DeleteBehavior.ClientSetNull);
       modelBuilder.Entity<ReservationCar>()
           .HasOne(x=>x.DropOffLocation)
           .WithMany(x=>x.DropOffRentACars)
           .HasForeignKey(x=>x.DropOffLocationId)
           .OnDelete(DeleteBehavior.ClientSetNull);
        
   }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts{ get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SocialMedia> SocialMediae { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<Footer> Footers { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Blog> Blogs { get; set; }
    
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<BlogCategory> BlogCategories { get; set; }
    
    public DbSet<TagCloud> TagClouds { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    
    public DbSet<ReservationCar> ReservationCars { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
}