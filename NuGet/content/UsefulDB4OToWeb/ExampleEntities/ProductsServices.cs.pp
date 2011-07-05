using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections.ObjectModel;

using Db4objects.Db4o;

using UsefulDB4O;
using UsefulDB4O.Web;


namespace UsefulDB4OToWeb.ExampleEntities
{
    public class ProductsServices
    {
        private IObjectContainer container = null;

        public ProductsServices()
        {
            /*USEFULDB4O STAFF*/
            container = DB4ODatabases.GetCurrentContextContainer("ExampleDatabaseProducts");
        }
        
        private const string TOTALCOUNT_PRODUCTSID   = "TotalCountProducts";
        private const string TOTALCOUNT_CATEGORIESID = "TotalCountCategories";

        public IList<Product> GetPagedProducts(string productName, Guid categoryID, string sortExpression, int maximumRows, int startRowIndex)
        {
            //BUILDING SODA QUERY
            var query = container.Query();
            query.Constrain(typeof(Product));

            if (!String.IsNullOrEmpty(productName))
                query.Descend("_name").Constrain(productName).Like();

             if(categoryID != null && !categoryID.Equals(Guid.Empty))
                 query.Descend("_productCategory").Descend("_id").Constrain(categoryID).Equal();

             if (!String.IsNullOrEmpty(sortExpression))
             {
                 var sortParts = sortExpression.Trim().Split(new[] { ' ' });

                 var privateField = String.Format("_{0}", sortParts[0][0].ToString().ToLower() + sortParts[0].Substring(1, sortParts[0].Length - 1)).Trim();

                 if (sortParts.Length == 1 || (sortParts.Length == 2 && sortParts[1].Equals("asc", StringComparison.OrdinalIgnoreCase)))
                     query.Descend(privateField).OrderAscending();
                 else
                     query.Descend(privateField).OrderDescending();
             }

            var totalCount = 0;

            /*START USEFULDBFO STAFF*/
            var products = query.Execute().ToPagedList<Product>(container, 2, maximumRows, startRowIndex, out totalCount); // ToPagedList, UsefulDBFO Staff
            /*START USEFULDBFO STAFF*/

            //Trick to avoid second call just for count
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Add(TOTALCOUNT_PRODUCTSID, totalCount);

            return products;
        }

        public int GetPagedProductsCount(string productName, Guid categoryID)
        {
            if (HttpContext.Current == null)
                return 0;
            //Trick to avoid second call just for count
            object totalCount = HttpContext.Current.Items[TOTALCOUNT_PRODUCTSID];

            if (totalCount == null)
                return 0;

            return Convert.ToInt32(totalCount);

        }

        public Product AddProduct(string name, decimal price, bool isEnabled, Guid categoryID)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            var product = new Product();
            product.ID = Guid.NewGuid();
            product.Name = name;
            product.Price = price;
            product.IsEnabled = isEnabled;

            Category activatedCategory = null;
            Guid tempGuid;

            if (!TryParseGuid(categoryID.ToString(), out tempGuid))
                throw new ArgumentException("The categoryID is not a valid Guid");

            activatedCategory = GetCategory(tempGuid);

            if (activatedCategory == null)
                throw new ArgumentException("The product not exists");

            product.ProductCategory = activatedCategory;

            container.Store(product);

            if (activatedCategory.CategoryProducts == null)
                activatedCategory.CategoryProducts = new Collection<Product>();

            activatedCategory.CategoryProducts.Add(product);

            container.Ext().Store(activatedCategory, 2);

            return product;
        }

        public Product GetProduct(Guid guid)
        {
            if (guid == null)
                return null;

            //BUILDING SODA QUERY
            var query = container.Query();
            query.Constrain(typeof(Product));
            query.Descend("_id").Constrain(guid).Equal();

            /*START USEFULDBFO STAFF*/
            return query.Execute().ToList<Product>(container, 2).FirstOrDefault();
            /*END USEFULDBFO STAFF*/
        }

        public Product UpdateProduct(object ID, string name, decimal price, bool isEnabled, Guid categoryID)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            Guid guid;

            if (!TryParseGuid(ID.ToString(), out guid))
                throw new ArgumentException("The ID is not a valid Guid");

            Category activatedCategory  = null;
            Product activatedProduct    = GetProduct(guid);

            if (activatedProduct == null)
                throw new Exception("The product not exists");

            activatedProduct.Name   = name;
            activatedProduct.Price  = price;
            activatedProduct.IsEnabled = isEnabled;

            if (categoryID!=null)
            {
                Guid tempGuid;

                if (!TryParseGuid(categoryID.ToString(), out tempGuid))
                    throw new ArgumentException("The categoryID is not a valid Guid");

                activatedCategory = GetCategory(tempGuid);

                if(activatedCategory == null)
                    throw new ArgumentException("The product not exists");

                activatedProduct.ProductCategory = activatedCategory;

                if (activatedCategory.CategoryProducts == null)
                    activatedCategory.CategoryProducts = new Collection<Product>();

                if (!activatedCategory.CategoryProducts.Any(product => product.ID == activatedProduct.ID))
                    activatedCategory.CategoryProducts.Add(activatedProduct);
            }

            container.Store(activatedProduct);

            if (activatedCategory != null)
                container.Store(activatedCategory);

            return activatedProduct;
        }

        public void DeleteProduct(Guid ID)
        {
            if (ID == null)
                return;

            //BUILDING SODA QUERY
            var query = container.Query();
            query.Constrain(typeof(Product));
            query.Descend("_id").Constrain(ID).Equal();

            /*START USEFULDBFO STAFF*/
            var product = query.Execute().ToList<Product>(container, 1).FirstOrDefault();
            /*END USEFULDBFO STAFF*/

            container.Ext().Delete(product);
        }

        //Categories staff
        public IList<Category> GetAllCategories()
        {
            var query = container.Query();
            query.Constrain(typeof(Category));

            /*START USEFULDBFO STAFF*/
            return query.Execute().ToList<Category>(container, 1);
            /*END USEFULDBFO STAFF*/
        }

        public Category AddCategory(string categoryName)
        {
            if (String.IsNullOrEmpty(categoryName))
                throw new ArgumentNullException(categoryName);

            var category = new Category();
            category.CategoryName = categoryName;
            category.ID = Guid.NewGuid();

            container.Store(category);

            return category;
        }

        public Category GetCategory(Guid guid)
        {
            if (guid == null)
                return null;

            //BUILDING SODA QUERY
            var query = container.Query();
            query.Constrain(typeof(Category));
            query.Descend("_id").Constrain(guid).Equal();

            /*START USEFULDBFO STAFF*/
            return query.Execute().ToList<Category>(container, 3).FirstOrDefault();
            /*END USEFULDBFO STAFF*/
        }

        public Category UpdateCategory(string categoryName, Guid ID)
        {
            if (String.IsNullOrEmpty(categoryName))
                throw new ArgumentNullException(categoryName);

            var activatedCategory = GetCategory(ID);

            if(activatedCategory == null)
                throw new Exception("The category not exists");

            activatedCategory.CategoryName = categoryName;

            container.Store(activatedCategory);

            return activatedCategory;
        }

        public void DeleteCategory(Guid ID)
        {
            if (ID == null)
                return;

            //BUILDING SODA QUERY
            var query = container.Query();
            query.Constrain(typeof(Category));
            query.Descend("_id").Constrain(ID).Equal();

            /*START USEFULDBFO STAFF*/
            var category = query.Execute().ToList<Category>(container, 2).FirstOrDefault();
            /*END USEFULDBFO STAFF*/

            if (category.CategoryProducts != null && category.CategoryProducts.Count > 0) 
            {
                foreach (var product in category.CategoryProducts.Where(prod => prod!= null))
                    container.Delete(product);

                container.Delete(category.CategoryProducts);
            }   

            container.Delete(category);
        }


        public IList<Category> GetPagedCategories(string categoryName, string sortExpression, int maximumRows, int startRowIndex)
        {
            //BUILDING SODA QUERY
            var query = container.Query();
            query.Constrain(typeof(Category));

            if (!String.IsNullOrEmpty(categoryName))
                query.Descend("_categoryName").Constrain(categoryName).Like();

            if (!String.IsNullOrEmpty(sortExpression))
            {
                var sortParts = sortExpression.Trim().Split(new[] { ' ' });

                var privateField = String.Format("_{0}", sortParts[0][0].ToString().ToLower() + sortParts[0].Substring(1, sortParts[0].Length -1)).Trim();

                if (sortParts.Length == 1 || (sortParts.Length == 2 && sortParts[1].Equals("asc", StringComparison.OrdinalIgnoreCase)))
                    query.Descend(privateField).OrderAscending();
                else
                    query.Descend(privateField).OrderDescending();
            }

            var totalCount = 0;

            /*START USEFULDBFO STAFF*/
            var categories = query.Execute().ToPagedList<Category>(container, 2, maximumRows, startRowIndex, out totalCount); // ToPagedList, UsefulDBFO Staff
            /*END USEFULDBFO STAFF*/

            //Trick to avoid second call just for count
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Add(TOTALCOUNT_CATEGORIESID, totalCount);

            return categories;
        }

        public int GetPagedCategoriesCount(string categoryName)
        {
            if (HttpContext.Current == null)
                return 0;

            //Trick to avoid second call just for items count
            object totalCount = HttpContext.Current.Items[TOTALCOUNT_CATEGORIESID];

            if (totalCount == null)
                return 0;

            return Convert.ToInt32(totalCount);

        }

        private bool TryParseGuid(string guidValue, out Guid generatedGuid)
        {
            generatedGuid = Guid.Empty;

            bool parsed = false;

            try
            {
                generatedGuid = new Guid(guidValue.Trim());
                parsed = true;
            }
            catch
            {
                generatedGuid = Guid.Empty;
                parsed = false;
            }

            return parsed;
        }
    }
}