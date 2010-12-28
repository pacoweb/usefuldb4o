using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

using SimpleWebApplication.Model;

using Db4objects.Db4o;
using UsefulDB4O.Web;

namespace SimpleWebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        IObjectContainer productsContainer = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Usefuldb4o Method: DB4ODatabases.GetCurrentContextContainer
            productsContainer = DB4ODatabases.GetCurrentContextContainer("ProductsDatabase");

            //If no data, fill with example info
            if (productsContainer.Query<Category>().Count == 0)
                FillDatabase();

            //show data
            foreach (var categoryItem in productsContainer.Query<Category>())
            {
                Response.Write(String.Format("{0}; {1}; <br />"
                    , categoryItem.CategoryID
                    , categoryItem.Name));

                foreach (var productItem in productsContainer.Query<Product>())
                {
                    Response.Write(String.Format("--> {0}; {1}; {2}; {3}; <br />"
                        , productItem.ProductID
                        , productItem.Name
                        , productItem.Price
                        , productItem.CategoryOfProduct.Name));
                }
            }
        }

        private void FillDatabase()
        {
            var category = new Category
            {
                CategoryID = Guid.NewGuid(),
                Name = "Cars",
                Products = new Collection<Product>()
            };

            category.Products.Add(new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "BMV",
                CategoryOfProduct = category,
                Price = 2222.9M
            });

            category.Products.Add(new Product
            {
                ProductID = Guid.NewGuid(),
                Name = "Mercedes",
                CategoryOfProduct = category,
                Price = 1234.98M
            });

            productsContainer.Store(category);
        }
    }
}