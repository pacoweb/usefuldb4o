using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvancedWebApplication
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
                FormView1.DefaultMode = FormViewMode.Insert;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {

        }

        protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {

        }

        protected void FormView1_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {

        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {

        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {

        }

        protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {

        }

        protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            
        }

        protected void FormView1_ModeChanged(object sender, EventArgs e)
        {

        }

        protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
        {

        }

        protected void FormView1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void FormView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void FormView1_ItemCreated(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }

        protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {

        }

        protected void ObjectDataSource1_Filtering(object sender, ObjectDataSourceFilteringEventArgs e)
        {

        }

        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }

        protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //Fix the default Parameter name ProductCategory.ID
            var categoryId = e.InputParameters["ProductCategory.ID"];

            if (!categoryId.Equals(null))
            {
                e.InputParameters.Remove("ProductCategory.ID");
                e.InputParameters.Add("categoryID", categoryId);
            }
        }

        protected void ObjectDataSource1_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {

        }

        protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = new Services.ProductsServices();
        }

        protected void ObjectDataSource1_ObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
        {

        }

        protected void ObjectDataSource1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //Fix the default Parameter name ProductCategory.ID
            var categoryId = e.InputParameters["ProductCategory.ID"];

            if (!categoryId.Equals(null))
            {
                e.InputParameters.Remove("ProductCategory.ID");
                e.InputParameters.Add("categoryID", categoryId);
            }

        }
    }
}