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

namespace Example.Entities.Sales
{
	[TableInformation(TableName = "Sales.SalesOrderDetail")]
	[Serializable]
	public partial class SalesOrderDetail: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _salesOrderID;

		[Required(ErrorMessage="SalesOrderID is required")]
		[ColumnInformation(ColumnName = "SalesOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesOrderID
		{
			get{ return _salesOrderID; }
			set{ _salesOrderID = value; onPropertyChanged(this, "SalesOrderID");}
		}

		[IndexedField]
		private Int32 _salesOrderDetailID;

		[Required(ErrorMessage="SalesOrderDetailID is required")]
		[ColumnInformation(ColumnName = "SalesOrderDetailID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesOrderDetailID
		{
			get{ return _salesOrderDetailID; }
			set{ _salesOrderDetailID = value; onPropertyChanged(this, "SalesOrderDetailID");}
		}

		private String _carrierTrackingNumber;

		[StringLength(25, ErrorMessage="CarrierTrackingNumber cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "CarrierTrackingNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String CarrierTrackingNumber
		{
			get{ return _carrierTrackingNumber; }
			set{ _carrierTrackingNumber = value; onPropertyChanged(this, "CarrierTrackingNumber");}
		}

		private Int16 _orderQty;

		[Required(ErrorMessage="OrderQty is required")]
		[ColumnInformation(ColumnName = "OrderQty", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 OrderQty
		{
			get{ return _orderQty; }
			set{ _orderQty = value; onPropertyChanged(this, "OrderQty");}
		}

		[IndexedField]
		private Int32 _productID;

		[Required(ErrorMessage="ProductID is required")]
		[ColumnInformation(ColumnName = "ProductID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ProductID
		{
			get{ return _productID; }
			set{ _productID = value; onPropertyChanged(this, "ProductID");}
		}

		[IndexedField]
		private Int32 _specialOfferID;

		[Required(ErrorMessage="SpecialOfferID is required")]
		[ColumnInformation(ColumnName = "SpecialOfferID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 SpecialOfferID
		{
			get{ return _specialOfferID; }
			set{ _specialOfferID = value; onPropertyChanged(this, "SpecialOfferID");}
		}

		private Decimal _unitPrice;

		[Required(ErrorMessage="UnitPrice is required")]
		[ColumnInformation(ColumnName = "UnitPrice", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal UnitPrice
		{
			get{ return _unitPrice; }
			set{ _unitPrice = value; onPropertyChanged(this, "UnitPrice");}
		}

		private Decimal _unitPriceDiscount;

		[Required(ErrorMessage="UnitPriceDiscount is required")]
		[ColumnInformation(ColumnName = "UnitPriceDiscount", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal UnitPriceDiscount
		{
			get{ return _unitPriceDiscount; }
			set{ _unitPriceDiscount = value; onPropertyChanged(this, "UnitPriceDiscount");}
		}

		private Decimal _lineTotal;

		[Required(ErrorMessage="LineTotal is required")]
		[ColumnInformation(ColumnName = "LineTotal", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal LineTotal
		{
			get{ return _lineTotal; }
			set{ _lineTotal = value; onPropertyChanged(this, "LineTotal");}
		}

		[IndexedField]
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

		private Example.Entities.Sales.SalesOrderHeader _salesOrderHeaderParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesOrderHeader", ChildTableName = "Sales.SalesOrderDetail", ParentColumnNames = new[]{ "SalesOrderID" }, ChildColumnNames =  new[]{ "SalesOrderID" } , PropertyNames = new[]{ "SalesOrderID" }, ForeignFieldNames =  new[]{ "_salesOrderID" } )]
		public Example.Entities.Sales.SalesOrderHeader SalesOrderHeaderParent
		{
			get{ return _salesOrderHeaderParent; }
			set{ _salesOrderHeaderParent = value; onPropertyChanged(this, "SalesOrderHeaderParent"); }
		}

		private Example.Entities.Sales.SpecialOfferProduct _specialOfferProductParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SpecialOfferProduct", ChildTableName = "Sales.SalesOrderDetail", ParentColumnNames = new[]{ "SpecialOfferID","ProductID" }, ChildColumnNames =  new[]{ "SpecialOfferID","ProductID" } , PropertyNames = new[]{ "SpecialOfferID","ProductID" }, ForeignFieldNames =  new[]{ "_specialOfferID","_productID" } )]
		public Example.Entities.Sales.SpecialOfferProduct SpecialOfferProductParent
		{
			get{ return _specialOfferProductParent; }
			set{ _specialOfferProductParent = value; onPropertyChanged(this, "SpecialOfferProductParent"); }
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
