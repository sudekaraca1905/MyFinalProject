﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ProductId=2,CategoryId=1, ProductName="Tabak", UnitPrice=25, UnitInStock=10},
                new Product{ProductId=3,CategoryId=2, ProductName="Kamera", UnitPrice=15000, UnitInStock=8},
                new Product{ProductId=4,CategoryId=2, ProductName="Telefon", UnitPrice=20000, UnitInStock=15},
                new Product{ProductId=5,CategoryId=2, ProductName="Tablet", UnitPrice=10000, UnitInStock=7},
               
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ= language ıntergrated query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUptdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUptdate.ProductName = product.ProductName;
            productToUptdate.CategoryId = product.CategoryId;
            productToUptdate.UnitPrice = product.UnitPrice;
            productToUptdate.UnitInStock = product.UnitInStock;

        }
    }
}
