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
	[TableInformation(TableName = "Purchasing.PurchaseOrderDetail")]
	[Serializable]
	public partial class PurchaseOrderDetail: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _purchaseOrderID;

		[Required(ErrorMessage="PurchaseOrderID is required")]
		[ColumnInformation(ColumnName = "PurchaseOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 PurchaseOrderID
		{
			get{ return _purchaseOrderID; }
			set{ _purchaseOrderID = value; onPropertyChanged(this, "PurchaseOrderID");}
		}

		[IndexedField]
		private Int32 _purchaseOrderDetailID;

		[Required(ErrorMessage="PurchaseOrderDetailID is required")]
		[ColumnInformation(ColumnName = "PurchaseOrderDetailID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 PurchaseOrderDetailID
		{
			get{ return _purchaseOrderDetailID; }
			set{ _purchaseOrderDetailID = value; onPropertyChanged(this, "PurchaseOrderDetailID");}
		}

		private DateTime _dueDate;

		[Required(ErrorMessage="DueDate is required")]
		[ColumnInformation(ColumnName = "DueDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime DueDate
		{
			get{ return _dueDate; }
			set{ _dueDate = value; onPropertyChanged(this, "DueDate");}
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

		private Decimal _unitPrice;

		[Required(ErrorMessage="UnitPrice is required")]
		[ColumnInformation(ColumnName = "UnitPrice", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal UnitPrice
		{
			get{ return _unitPrice; }
			set{ _unitPrice = value; onPropertyChanged(this, "UnitPrice");}
		}

		private Decimal _lineTotal;

		[Required(ErrorMessage="LineTotal is required")]
		[ColumnInformation(ColumnName = "LineTotal", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal LineTotal
		{
			get{ return _lineTotal; }
			set{ _lineTotal = value; onPropertyChanged(this, "LineTotal");}
		}

		private Decimal _receivedQty;

		[Required(ErrorMessage="ReceivedQty is required")]
		[ColumnInformation(ColumnName = "ReceivedQty", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal ReceivedQty
		{
			get{ return _receivedQty; }
			set{ _receivedQty = value; onPropertyChanged(this, "ReceivedQty");}
		}

		private Decimal _rejectedQty;

		[Required(ErrorMessage="RejectedQty is required")]
		[ColumnInformation(ColumnName = "RejectedQty", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal RejectedQty
		{
			get{ return _rejectedQty; }
			set{ _rejectedQty = value; onPropertyChanged(this, "RejectedQty");}
		}

		private Decimal _stockedQty;

		[Required(ErrorMessage="StockedQty is required")]
		[ColumnInformation(ColumnName = "StockedQty", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal StockedQty
		{
			get{ return _stockedQty; }
			set{ _stockedQty = value; onPropertyChanged(this, "StockedQty");}
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
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Purchasing.PurchaseOrderDetail", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
		}

		private Example.Entities.Purchasing.PurchaseOrderHeader _purchaseOrderHeaderParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Purchasing.PurchaseOrderHeader", ChildTableName = "Purchasing.PurchaseOrderDetail", ParentColumnNames = new[]{ "PurchaseOrderID" }, ChildColumnNames =  new[]{ "PurchaseOrderID" } , PropertyNames = new[]{ "PurchaseOrderID" }, ForeignFieldNames =  new[]{ "_purchaseOrderID" } )]
		public Example.Entities.Purchasing.PurchaseOrderHeader PurchaseOrderHeaderParent
		{
			get{ return _purchaseOrderHeaderParent; }
			set{ _purchaseOrderHeaderParent = value; onPropertyChanged(this, "PurchaseOrderHeaderParent"); }
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
