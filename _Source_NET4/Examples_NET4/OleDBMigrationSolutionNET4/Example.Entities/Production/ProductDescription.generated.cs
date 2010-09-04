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
	[TableInformation(TableName = "Production.ProductDescription")]
	[Serializable]
	public partial class ProductDescription: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _productDescriptionID;

		[Required(ErrorMessage="ProductDescriptionID is required")]
		[ColumnInformation(ColumnName = "ProductDescriptionID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductDescriptionID
		{
			get{ return _productDescriptionID; }
			set{ _productDescriptionID = value; onPropertyChanged(this, "ProductDescriptionID");}
		}

		private String _description;

		[Required(ErrorMessage="Description is required")]
		[StringLength(400, ErrorMessage="Description cannot be longer than 400 characters")]
		[ColumnInformation(ColumnName = "Description", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Description
		{
			get{ return _description; }
			set{ _description = value; onPropertyChanged(this, "Description");}
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

		private ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture> _productModelProductDescriptionCultureCollection = new ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ProductDescription", ChildTableName = "Production.ProductModelProductDescriptionCulture", ParentColumnNames = new[]{ "ProductDescriptionID" }, ChildColumnNames =  new[]{ "ProductDescriptionID" } , PropertyNames = new[]{ "ProductDescriptionID" }, ForeignFieldNames =  new[]{ "_productDescriptionID" }, PrivateCollectionFieldName = "_productModelProductDescriptionCultureCollection" )]
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
