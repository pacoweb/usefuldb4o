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
	[TableInformation(TableName = "Production.ProductModel")]
	[Serializable]
	public partial class ProductModel: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _productModelID;

		[Required(ErrorMessage="ProductModelID is required")]
		[ColumnInformation(ColumnName = "ProductModelID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductModelID
		{
			get{ return _productModelID; }
			set{ _productModelID = value; onPropertyChanged(this, "ProductModelID");}
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
		private Object _catalogDescription;

		[ColumnInformation(ColumnName = "CatalogDescription", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object CatalogDescription
		{
			get{ return _catalogDescription; }
			set{ _catalogDescription = value; onPropertyChanged(this, "CatalogDescription");}
		}

		[IndexedField]
		private Object _instructions;

		[ColumnInformation(ColumnName = "Instructions", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object Instructions
		{
			get{ return _instructions; }
			set{ _instructions = value; onPropertyChanged(this, "Instructions");}
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

		private ObservableCollection<Example.Entities.Production.Product> _productCollection = new ObservableCollection<Example.Entities.Production.Product>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ProductModel", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "ProductModelID" }, ChildColumnNames =  new[]{ "ProductModelID" } , PropertyNames = new[]{ "ProductModelID" }, ForeignFieldNames =  new[]{ "_productModelID" }, PrivateCollectionFieldName = "_productCollection" )]
		public ObservableCollection<Example.Entities.Production.Product> ProductCollection
		{
			get{ return _productCollection; }
			private set
			{
				if (ProductCollection == value)
					return;
				_productCollection = value;
				onPropertyChanged(this, "ProductCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductModelIllustration> _productModelIllustrationCollection = new ObservableCollection<Example.Entities.Production.ProductModelIllustration>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ProductModel", ChildTableName = "Production.ProductModelIllustration", ParentColumnNames = new[]{ "ProductModelID" }, ChildColumnNames =  new[]{ "ProductModelID" } , PropertyNames = new[]{ "ProductModelID" }, ForeignFieldNames =  new[]{ "_productModelID" }, PrivateCollectionFieldName = "_productModelIllustrationCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductModelIllustration> ProductModelIllustrationCollection
		{
			get{ return _productModelIllustrationCollection; }
			private set
			{
				if (ProductModelIllustrationCollection == value)
					return;
				_productModelIllustrationCollection = value;
				onPropertyChanged(this, "ProductModelIllustrationCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture> _productModelProductDescriptionCultureCollection = new ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ProductModel", ChildTableName = "Production.ProductModelProductDescriptionCulture", ParentColumnNames = new[]{ "ProductModelID" }, ChildColumnNames =  new[]{ "ProductModelID" } , PropertyNames = new[]{ "ProductModelID" }, ForeignFieldNames =  new[]{ "_productModelID" }, PrivateCollectionFieldName = "_productModelProductDescriptionCultureCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureCollection
		{
			get{ return _productModelProductDescriptionCultureCollection; }
			private set
			{
				if (ProductModelProductDescriptionCultureCollection == value)
					return;
				_productModelProductDescriptionCultureCollection = value;
				onPropertyChanged(this, "ProductModelProductDescriptionCultureCollection");
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
