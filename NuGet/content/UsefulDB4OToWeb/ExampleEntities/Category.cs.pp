using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsefulDB4O.DatabaseConfig;

namespace UsefulDB4OToWeb.ExampleEntities
{
    public class Category
    {
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [IndexedField]
        [UniqueFieldValueConstraint]
        private Guid _id;

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        [IndexedField]
        [UniqueFieldValueConstraint]
        private string _categoryName;

        public ICollection<Product> CategoryProducts
        {
            get { return _categoryProducts; }
            set { _categoryProducts = value; }
        }
        private ICollection<Product> _categoryProducts;
    }
}
