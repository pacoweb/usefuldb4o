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
	[TableInformation(TableName = "Purchasing.PurchaseOrderHeader")]
	[Serializable]
	public partial class PurchaseOrderHeader: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _purchaseOrderID;

		[Required(ErrorMessage="PurchaseOrderID is required")]
		[ColumnInformation(ColumnName = "PurchaseOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 PurchaseOrderID
		{
			get{ return _purchaseOrderID; }
			set{ _purchaseOrderID = value; onPropertyChanged(this, "PurchaseOrderID");}
		}

		private Byte _revisionNumber;

		[Required(ErrorMessage="RevisionNumber is required")]
		[ColumnInformation(ColumnName = "RevisionNumber", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte RevisionNumber
		{
			get{ return _revisionNumber; }
			set{ _revisionNumber = value; onPropertyChanged(this, "RevisionNumber");}
		}

		private Byte _status;

		[Required(ErrorMessage="Status is required")]
		[ColumnInformation(ColumnName = "Status", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte Status
		{
			get{ return _status; }
			set{ _status = value; onPropertyChanged(this, "Status");}
		}

		[IndexedField]
		private Int32 _employeeID;

		[Required(ErrorMessage="EmployeeID is required")]
		[ColumnInformation(ColumnName = "EmployeeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 EmployeeID
		{
			get{ return _employeeID; }
			set{ _employeeID = value; onPropertyChanged(this, "EmployeeID");}
		}

		[IndexedField]
		private Int32 _vendorID;

		[Required(ErrorMessage="VendorID is required")]
		[ColumnInformation(ColumnName = "VendorID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 VendorID
		{
			get{ return _vendorID; }
			set{ _vendorID = value; onPropertyChanged(this, "VendorID");}
		}

		[IndexedField]
		private Int32 _shipMethodID;

		[Required(ErrorMessage="ShipMethodID is required")]
		[ColumnInformation(ColumnName = "ShipMethodID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ShipMethodID
		{
			get{ return _shipMethodID; }
			set{ _shipMethodID = value; onPropertyChanged(this, "ShipMethodID");}
		}

		private DateTime _orderDate;

		[Required(ErrorMessage="OrderDate is required")]
		[ColumnInformation(ColumnName = "OrderDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime OrderDate
		{
			get{ return _orderDate; }
			set{ _orderDate = value; onPropertyChanged(this, "OrderDate");}
		}

		private DateTime? _shipDate;

		[ColumnInformation(ColumnName = "ShipDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? ShipDate
		{
			get{ return _shipDate; }
			set{ _shipDate = value; onPropertyChanged(this, "ShipDate");}
		}

		private Decimal _subTotal;

		[Required(ErrorMessage="SubTotal is required")]
		[ColumnInformation(ColumnName = "SubTotal", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal SubTotal
		{
			get{ return _subTotal; }
			set{ _subTotal = value; onPropertyChanged(this, "SubTotal");}
		}

		private Decimal _taxAmt;

		[Required(ErrorMessage="TaxAmt is required")]
		[ColumnInformation(ColumnName = "TaxAmt", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal TaxAmt
		{
			get{ return _taxAmt; }
			set{ _taxAmt = value; onPropertyChanged(this, "TaxAmt");}
		}

		private Decimal _freight;

		[Required(ErrorMessage="Freight is required")]
		[ColumnInformation(ColumnName = "Freight", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal Freight
		{
			get{ return _freight; }
			set{ _freight = value; onPropertyChanged(this, "Freight");}
		}

		private Decimal _totalDue;

		[Required(ErrorMessage="TotalDue is required")]
		[ColumnInformation(ColumnName = "TotalDue", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal TotalDue
		{
			get{ return _totalDue; }
			set{ _totalDue = value; onPropertyChanged(this, "TotalDue");}
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

		private ObservableCollection<Example.Entities.Purchasing.PurchaseOrderDetail> _purchaseOrderDetailCollection = new ObservableCollection<Example.Entities.Purchasing.PurchaseOrderDetail>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.PurchaseOrderHeader", ChildTableName = "Purchasing.PurchaseOrderDetail", ParentColumnNames = new[]{ "PurchaseOrderID" }, ChildColumnNames =  new[]{ "PurchaseOrderID" } , PropertyNames = new[]{ "PurchaseOrderID" }, ForeignFieldNames =  new[]{ "_purchaseOrderID" }, PrivateCollectionFieldName = "_purchaseOrderDetailCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.PurchaseOrderDetail> PurchaseOrderDetailCollection
		{
			get{ return _purchaseOrderDetailCollection; }
			private set
			{
				if (PurchaseOrderDetailCollection == value)
					return;
				_purchaseOrderDetailCollection = value;
				onPropertyChanged(this, "PurchaseOrderDetailCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.HumanResources.Employee _employeeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Employee", ChildTableName = "Purchasing.PurchaseOrderHeader", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" } )]
		public Example.Entities.HumanResources.Employee EmployeeParent
		{
			get{ return _employeeParent; }
			set{ _employeeParent = value; onPropertyChanged(this, "EmployeeParent"); }
		}

		private Example.Entities.Purchasing.ShipMethod _shipMethodParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Purchasing.ShipMethod", ChildTableName = "Purchasing.PurchaseOrderHeader", ParentColumnNames = new[]{ "ShipMethodID" }, ChildColumnNames =  new[]{ "ShipMethodID" } , PropertyNames = new[]{ "ShipMethodID" }, ForeignFieldNames =  new[]{ "_shipMethodID" } )]
		public Example.Entities.Purchasing.ShipMethod ShipMethodParent
		{
			get{ return _shipMethodParent; }
			set{ _shipMethodParent = value; onPropertyChanged(this, "ShipMethodParent"); }
		}

		private Example.Entities.Purchasing.Vendor _vendorParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.PurchaseOrderHeader", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" } )]
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
