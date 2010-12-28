using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebApplication.Model
{
    public class Category
    {
        
        private Guid _categoryID;
        public Guid CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }


        
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private ICollection<Product>  _products;
        public ICollection<Product>  Products
        {
            get { return _products; }
            set { _products = value; }
        }
        
        
    }
}