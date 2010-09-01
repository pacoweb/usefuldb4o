#region usings

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data.OleDb;
using UsefulDB4O.DatabaseConfig;
using UsefulDB4O.OleDBMigration;

#endregion usings

namespace Example.Entities.Production
{
	[TableInformation(TableName = "Production.ProductCategory")]
	[Serializable]
	public partial class ProductCategory: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _productCategoryID;

		[Required(ErrorMessage="ProductCategoryID is required")]
		[ColumnInformation(ColumnName = "ProductCategoryID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductCategoryID
		{
			get{ return _productCategoryID; }
			set{ _productCategoryID = value; onPropertyChanged(this, "ProductCategoryID");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _name;

		[Required(ErrorMessage="Name is required")]
		[StringLength(50, ErrorMessage="Name cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Name", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Name
		{
			get{ return _name; }
			set{ _name = value; onPropertyChanged(this, "Name");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Guid _rowguid;

		[Required(ErrorMessage="Rowguid is required")]
		[ColumnInformation(ColumnName = "rowguid", CodeType = typeof(Guid), ColumnType = OleDbType.Guid, IsPrimaryKey=false)]
		public Guid Rowguid
		{
			get{ return _rowguid; }
			set{ _rowguid = value; onPropertyChanged(this, "Rowguid");}
		}

		private DateTime _modifiedDate;

		[Required(ErrorMessage="ModifiedDate is required")]
		[ColumnInformation(ColumnName = "ModifiedDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; onPropertyChanged(this, "ModifiedDate");}
		}

		#endregion PROPERTIES

		#region CHILD PROPERTIES

		private ObservableCollection<Example.Entities.Production.ProductSubcategory> _productSubcategoryCollection = new ObservableCollection<Example.Entities.Production.ProductSubcategory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ProductCategory", ChildTableName = "Production.ProductSubcategory", ParentColumnNames = new[]{ "ProductCategoryID" }, ChildColumnNames =  new[]{ "ProductCategoryID" } , PropertyNames = new[]{ "ProductCategoryID" }, ForeignFieldNames =  new[]{ "_productCategoryID" }, PrivateCollectionFieldName = "_productSubcategoryCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductSubcategory> ProductSubcategoryCollection
		{
			get{ return _productSubcategoryCollection; }
			private set
			{
				if (ProductSubcategoryCollection == value)
					return;
				_productSubcategoryCollection = value;
				onPropertyChanged(this, "ProductSubcategoryCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region INotifyPropertyChanged

		[TransientField]
		public event PropertyChangedEventHandler PropertyChanged;
	    
		private void onPropertyChanged(object sender, string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}	
}		
