using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace NetCoreConcepts
{
    public class Category
    {
        private ICollection<Product> _products;

        public Category()
        {
        }

        private Category(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products
        {
            get => LazyLoader.Load(this, ref _products);
            set => _products = value;
        }
    }

    public class Product
    {
        private Category _category;
        public int Id { get; set; }
        public string Name { get; set; }
        public Product()
        {
        }

        private Product(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }
        public Category Category
        {
            get => LazyLoader.Load(this, ref _category);
            set => _category = value;
        }

    }
}
