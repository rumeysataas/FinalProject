﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ CategoryId=1, ProductId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ CategoryId=2, ProductId=1, ProductName="Kamera", UnitPrice=500, UnitInStock=3},
                new Product{ CategoryId=3, ProductId=2, ProductName="Telefon", UnitPrice=1500, UnitInStock=2},
                new Product{ CategoryId=4, ProductId=2, ProductName="Klavye", UnitPrice=150, UnitInStock=65},
                new Product{ CategoryId=5, ProductId=2, ProductName="Fare", UnitPrice=85, UnitInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - LAnguage Integrated Query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
