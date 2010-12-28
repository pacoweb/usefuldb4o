using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebApplication.Model
{
    public class Product
    {
        
        private Guid _productID;
        public Guid ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }


        private Category  _categoryOfProduct;
        public Category  CategoryOfProduct
        {
            get { return _categoryOfProduct; }
            set { _categoryOfProduct = value; }
        }
        

    }
}