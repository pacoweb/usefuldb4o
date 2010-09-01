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
	[TableInformation(TableName = "Production.ProductModelProductDescriptionCulture")]
	[Serializable]
	public partial class ProductModelProductDescriptionCulture: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _productModelID;

		[Required(ErrorMessage="ProductModelID is required")]
		[ColumnInformation(ColumnName = "ProductModelID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductModelID
		{
			get{ return _productModelID; }
			set{ _productModelID = value; onPropertyChanged(this, "ProductModelID");}
		}

		[IndexedField]
		private Int32 _productDescriptionID;

		[Required(ErrorMessage="ProductDescriptionID is required")]
		[ColumnInformation(ColumnName = "ProductDescriptionID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductDescriptionID
		{
			get{ return _productDescriptionID; }
			set{ _productDescriptionID = value; onPropertyChanged(this, "ProductDescriptionID");}
		}

		[IndexedField]
		private String _cultureID;

		[Required(ErrorMessage="CultureID is required")]
		[StringLength(6, ErrorMessage="CultureID cannot be longer than 6 characters")]
		[ColumnInformation(ColumnName = "CultureID", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=true)]
		public String CultureID
		{
			get{ return _cultureID; }
			set{ _cultureID = value; onPropertyChanged(this, "CultureID");}
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

		#region PARENT PROPERTIES

		private Example.Entities.Production.Culture _cultureParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Culture", ChildTableName = "Production.ProductModelProductDescriptionCulture", ParentColumnNames = new[]{ "CultureID" }, ChildColumnNames =  new[]{ "CultureID" } , PropertyNames = new[]{ "CultureID" }, ForeignFieldNames =  new[]{ "_cultureID" } )]
		public Example.Entities.Production.Culture CultureParent
		{
			get{ return _cultureParent; }
			set{ _cultureParent = value; onPropertyChanged(this, "CultureParent"); }
		}

		private Example.Entities.Production.ProductDescription _productDescriptionParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ProductDescription", ChildTableName = "Production.ProductModelProductDescriptionCulture", ParentColumnNames = new[]{ "ProductDescriptionID" }, ChildColumnNames =  new[]{ "ProductDescriptionID" } , PropertyNames = new[]{ "ProductDescriptionID" }, ForeignFieldNames =  new[]{ "_productDescriptionID" } )]
		public Example.Entities.Production.ProductDescription ProductDescriptionParent
		{
			get{ return _productDescriptionParent; }
			set{ _productDescriptionParent = value; onPropertyChanged(this, "ProductDescriptionParent"); }
		}

		private Example.Entities.Production.ProductModel _productModelParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ProductModel", ChildTableName = "Production.ProductModelProductDescriptionCulture", ParentColumnNames = new[]{ "ProductModelID" }, ChildColumnNames =  new[]{ "ProductModelID" } , PropertyNames = new[]{ "ProductModelID" }, ForeignFieldNames =  new[]{ "_productModelID" } )]
		public Example.Entities.Production.ProductModel ProductModelParent
		{
			get{ return _productModelParent; }
			set{ _productModelParent = value; onPropertyChanged(this, "ProductModelParent"); }
		}

		#endregion PARENT PROPERTIES

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
