﻿namespace PetStore.Data.Framewok.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DeliveryAddress = c.String(),
                        BillingInformation = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        Salary = c.Double(nullable: false),
                        Department = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Customer_Id = c.Guid(),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PromoCode = c.String(),
                        ShippingCost = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Brand = c.String(),
                        Category = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        PetType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Supplier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.CurrentStocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Amount = c.Int(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentStocks", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Shipments", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CurrentStocks", new[] { "Product_Id" });
            DropIndex("dbo.Shipments", new[] { "Supplier_Id" });
            DropIndex("dbo.Suppliers", new[] { "Product_Id" });
            DropIndex("dbo.Invoices", new[] { "Order_Id" });
            DropIndex("dbo.Invoices", new[] { "Customer_Id" });
            DropTable("dbo.CurrentStocks");
            DropTable("dbo.Shipments");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
