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
	[TableInformation(TableName = "Production.ProductInventory")]
	[Serializable]
	public partial class ProductInventory: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _productID;

		[Required(ErrorMessage="ProductID is required")]
		[ColumnInformation(ColumnName = "ProductID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductID
		{
			get{ return _productID; }
			set{ _productID = value; onPropertyChanged(this, "ProductID");}
		}

		[IndexedField]
		private Int16 _locationID;

		[Required(ErrorMessage="LocationID is required")]
		[ColumnInformation(ColumnName = "LocationID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=true)]
		public Int16 LocationID
		{
			get{ return _locationID; }
			set{ _locationID = value; onPropertyChanged(this, "LocationID");}
		}

		private String _shelf;

		[Required(ErrorMessage="Shelf is required")]
		[StringLength(10, ErrorMessage="Shelf cannot be longer than 10 characters")]
		[ColumnInformation(ColumnName = "Shelf", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Shelf
		{
			get{ return _shelf; }
			set{ _shelf = value; onPropertyChanged(this, "Shelf");}
		}

		private Byte _bin;

		[Required(ErrorMessage="Bin is required")]
		[ColumnInformation(ColumnName = "Bin", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte Bin
		{
			get{ return _bin; }
			set{ _bin = value; onPropertyChanged(this, "Bin");}
		}

		private Int16 _quantity;

		[Required(ErrorMessage="Quantity is required")]
		[ColumnInformation(ColumnName = "Quantity", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 Quantity
		{
			get{ return _quantity; }
			set{ _quantity = value; onPropertyChanged(this, "Quantity");}
		}

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

		#region PARENT PROPERTIES

		private Example.Entities.Production.Location _locationParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Location", ChildTableName = "Production.ProductInventory", ParentColumnNames = new[]{ "LocationID" }, ChildColumnNames =  new[]{ "LocationID" } , PropertyNames = new[]{ "LocationID" }, ForeignFieldNames =  new[]{ "_locationID" } )]
		public Example.Entities.Production.Location LocationParent
		{
			get{ return _locationParent; }
			set{ _locationParent = value; onPropertyChanged(this, "LocationParent"); }
		}

		private Example.Entities.Production.Product _productParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.ProductInventory", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
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
