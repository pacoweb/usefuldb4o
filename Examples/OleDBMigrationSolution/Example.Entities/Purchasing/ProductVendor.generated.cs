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

namespace Example.Entities.Purchasing
{
	[TableInformation(TableName = "Purchasing.ProductVendor")]
	[Serializable]
	public partial class ProductVendor: INotifyPropertyChanged
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
		private Int32 _vendorID;

		[Required(ErrorMessage="VendorID is required")]
		[ColumnInformation(ColumnName = "VendorID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 VendorID
		{
			get{ return _vendorID; }
			set{ _vendorID = value; onPropertyChanged(this, "VendorID");}
		}

		private Int32 _averageLeadTime;

		[Required(ErrorMessage="AverageLeadTime is required")]
		[ColumnInformation(ColumnName = "AverageLeadTime", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 AverageLeadTime
		{
			get{ return _averageLeadTime; }
			set{ _averageLeadTime = value; onPropertyChanged(this, "AverageLeadTime");}
		}

		private Decimal _standardPrice;

		[Required(ErrorMessage="StandardPrice is required")]
		[ColumnInformation(ColumnName = "StandardPrice", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal StandardPrice
		{
			get{ return _standardPrice; }
			set{ _standardPrice = value; onPropertyChanged(this, "StandardPrice");}
		}

		private Decimal? _lastReceiptCost;

		[ColumnInformation(ColumnName = "LastReceiptCost", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal? LastReceiptCost
		{
			get{ return _lastReceiptCost; }
			set{ _lastReceiptCost = value; onPropertyChanged(this, "LastReceiptCost");}
		}

		private DateTime? _lastReceiptDate;

		[ColumnInformation(ColumnName = "LastReceiptDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? LastReceiptDate
		{
			get{ return _lastReceiptDate; }
			set{ _lastReceiptDate = value; onPropertyChanged(this, "LastReceiptDate");}
		}

		private Int32 _minOrderQty;

		[Required(ErrorMessage="MinOrderQty is required")]
		[ColumnInformation(ColumnName = "MinOrderQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 MinOrderQty
		{
			get{ return _minOrderQty; }
			set{ _minOrderQty = value; onPropertyChanged(this, "MinOrderQty");}
		}

		private Int32 _maxOrderQty;

		[Required(ErrorMessage="MaxOrderQty is required")]
		[ColumnInformation(ColumnName = "MaxOrderQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 MaxOrderQty
		{
			get{ return _maxOrderQty; }
			set{ _maxOrderQty = value; onPropertyChanged(this, "MaxOrderQty");}
		}

		private Int32? _onOrderQty;

		[ColumnInformation(ColumnName = "OnOrderQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? OnOrderQty
		{
			get{ return _onOrderQty; }
			set{ _onOrderQty = value; onPropertyChanged(this, "OnOrderQty");}
		}

		[IndexedField]
		private String _unitMeasureCode;

		[Required(ErrorMessage="UnitMeasureCode is required")]
		[StringLength(3, ErrorMessage="UnitMeasureCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "UnitMeasureCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String UnitMeasureCode
		{
			get{ return _unitMeasureCode; }
			set{ _unitMeasureCode = value; onPropertyChanged(this, "UnitMeasureCode");}
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

		private Example.Entities.Production.Product _productParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Purchasing.ProductVendor", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
		}

		private Example.Entities.Production.UnitMeasure _unitMeasureParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.UnitMeasure", ChildTableName = "Purchasing.ProductVendor", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "UnitMeasureCode" } , PropertyNames = new[]{ "UnitMeasureCode" }, ForeignFieldNames =  new[]{ "_unitMeasureCode" } )]
		public Example.Entities.Production.UnitMeasure UnitMeasureParent
		{
			get{ return _unitMeasureParent; }
			set{ _unitMeasureParent = value; onPropertyChanged(this, "UnitMeasureParent"); }
		}

		private Example.Entities.Purchasing.Vendor _vendorParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.ProductVendor", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" } )]
		public Example.Entities.Purchasing.Vendor VendorParent
		{
			get{ return _vendorParent; }
			set{ _vendorParent = value; onPropertyChanged(this, "VendorParent"); }
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
