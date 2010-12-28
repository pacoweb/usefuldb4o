using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsefulDB4O.DatabaseConfig;

namespace Example.Entities.Products
{
    public class Product
    {
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [IndexedField]
        [UniqueFieldValueConstraint]
        private Guid _id;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [IndexedField]
        [UniqueFieldValueConstraint]
        private string _name;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private decimal _price;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }
        private bool _isEnabled;

        public Category ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; }
        }
        private Category _productCategory;
    }
}
