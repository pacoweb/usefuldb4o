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
	[TableInformation(TableName = "Sales.SalesOrderHeader")]
	[Serializable]
	public partial class SalesOrderHeader: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _salesOrderID;

		[Required(ErrorMessage="SalesOrderID is required")]
		[ColumnInformation(ColumnName = "SalesOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesOrderID
		{
			get{ return _salesOrderID; }
			set{ _salesOrderID = value; onPropertyChanged(this, "SalesOrderID");}
		}

		private Byte _revisionNumber;

		[Required(ErrorMessage="RevisionNumber is required")]
		[ColumnInformation(ColumnName = "RevisionNumber", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte RevisionNumber
		{
			get{ return _revisionNumber; }
			set{ _revisionNumber = value; onPropertyChanged(this, "RevisionNumber");}
		}

		private DateTime _orderDate;

		[Required(ErrorMessage="OrderDate is required")]
		[ColumnInformation(ColumnName = "OrderDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime OrderDate
		{
			get{ return _orderDate; }
			set{ _orderDate = value; onPropertyChanged(this, "OrderDate");}
		}

		private DateTime _dueDate;

		[Required(ErrorMessage="DueDate is required")]
		[ColumnInformation(ColumnName = "DueDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime DueDate
		{
			get{ return _dueDate; }
			set{ _dueDate = value; onPropertyChanged(this, "DueDate");}
		}

		private DateTime? _shipDate;

		[ColumnInformation(ColumnName = "ShipDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? ShipDate
		{
			get{ return _shipDate; }
			set{ _shipDate = value; onPropertyChanged(this, "ShipDate");}
		}

		private Byte _status;

		[Required(ErrorMessage="Status is required")]
		[ColumnInformation(ColumnName = "Status", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte Status
		{
			get{ return _status; }
			set{ _status = value; onPropertyChanged(this, "Status");}
		}

		private Boolean _onlineOrderFlag;

		[Required(ErrorMessage="OnlineOrderFlag is required")]
		[ColumnInformation(ColumnName = "OnlineOrderFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean OnlineOrderFlag
		{
			get{ return _onlineOrderFlag; }
			set{ _onlineOrderFlag = value; onPropertyChanged(this, "OnlineOrderFlag");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _salesOrderNumber;

		[Required(ErrorMessage="SalesOrderNumber is required")]
		[StringLength(25, ErrorMessage="SalesOrderNumber cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "SalesOrderNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String SalesOrderNumber
		{
			get{ return _salesOrderNumber; }
			set{ _salesOrderNumber = value; onPropertyChanged(this, "SalesOrderNumber");}
		}

		private String _purchaseOrderNumber;

		[StringLength(25, ErrorMessage="PurchaseOrderNumber cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "PurchaseOrderNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String PurchaseOrderNumber
		{
			get{ return _purchaseOrderNumber; }
			set{ _purchaseOrderNumber = value; onPropertyChanged(this, "PurchaseOrderNumber");}
		}

		private String _accountNumber;

		[StringLength(15, ErrorMessage="AccountNumber cannot be longer than 15 characters")]
		[ColumnInformation(ColumnName = "AccountNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String AccountNumber
		{
			get{ return _accountNumber; }
			set{ _accountNumber = value; onPropertyChanged(this, "AccountNumber");}
		}

		[IndexedField]
		private Int32 _customerID;

		[Required(ErrorMessage="CustomerID is required")]
		[ColumnInformation(ColumnName = "CustomerID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 CustomerID
		{
			get{ return _customerID; }
			set{ _customerID = value; onPropertyChanged(this, "CustomerID");}
		}

		[IndexedField]
		private Int32 _contactID;

		[Required(ErrorMessage="ContactID is required")]
		[ColumnInformation(ColumnName = "ContactID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; onPropertyChanged(this, "ContactID");}
		}

		[IndexedField]
		private Int32? _salesPersonID;

		[ColumnInformation(ColumnName = "SalesPersonID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? SalesPersonID
		{
			get{ return _salesPersonID; }
			set{ _salesPersonID = value; onPropertyChanged(this, "SalesPersonID");}
		}

		[IndexedField]
		private Int32? _territoryID;

		[ColumnInformation(ColumnName = "TerritoryID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? TerritoryID
		{
			get{ return _territoryID; }
			set{ _territoryID = value; onPropertyChanged(this, "TerritoryID");}
		}

		[IndexedField]
		private Int32 _billToAddressID;

		[Required(ErrorMessage="BillToAddressID is required")]
		[ColumnInformation(ColumnName = "BillToAddressID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 BillToAddressID
		{
			get{ return _billToAddressID; }
			set{ _billToAddressID = value; onPropertyChanged(this, "BillToAddressID");}
		}

		[IndexedField]
		private Int32 _shipToAddressID;

		[Required(ErrorMessage="ShipToAddressID is required")]
		[ColumnInformation(ColumnName = "ShipToAddressID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ShipToAddressID
		{
			get{ return _shipToAddressID; }
			set{ _shipToAddressID = value; onPropertyChanged(this, "ShipToAddressID");}
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

		[IndexedField]
		private Int32? _creditCardID;

		[ColumnInformation(ColumnName = "CreditCardID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? CreditCardID
		{
			get{ return _creditCardID; }
			set{ _creditCardID = value; onPropertyChanged(this, "CreditCardID");}
		}

		private String _creditCardApprovalCode;

		[StringLength(15, ErrorMessage="CreditCardApprovalCode cannot be longer than 15 characters")]
		[ColumnInformation(ColumnName = "CreditCardApprovalCode", CodeType = typeof(String), ColumnType = OleDbType.Char, IsPrimaryKey=false)]
		public String CreditCardApprovalCode
		{
			get{ return _creditCardApprovalCode; }
			set{ _creditCardApprovalCode = value; onPropertyChanged(this, "CreditCardApprovalCode");}
		}

		[IndexedField]
		private Int32? _currencyRateID;

		[ColumnInformation(ColumnName = "CurrencyRateID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? CurrencyRateID
		{
			get{ return _currencyRateID; }
			set{ _currencyRateID = value; onPropertyChanged(this, "CurrencyRateID");}
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

		private String _comment;

		[StringLength(128, ErrorMessage="Comment cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "Comment", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Comment
		{
			get{ return _comment; }
			set{ _comment = value; onPropertyChanged(this, "Comment");}
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

		private ObservableCollection<Example.Entities.Sales.SalesOrderDetail> _salesOrderDetailCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderDetail>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesOrderHeader", ChildTableName = "Sales.SalesOrderDetail", ParentColumnNames = new[]{ "SalesOrderID" }, ChildColumnNames =  new[]{ "SalesOrderID" } , PropertyNames = new[]{ "SalesOrderID" }, ForeignFieldNames =  new[]{ "_salesOrderID" }, PrivateCollectionFieldName = "_salesOrderDetailCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderDetail> SalesOrderDetailCollection
		{
			get{ return _salesOrderDetailCollection; }
			private set
			{
				if (SalesOrderDetailCollection == value)
					return;
				_salesOrderDetailCollection = value;
				onPropertyChanged(this, "SalesOrderDetailCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeaderSalesReason> _salesOrderHeaderSalesReasonCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeaderSalesReason>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesOrderHeader", ChildTableName = "Sales.SalesOrderHeaderSalesReason", ParentColumnNames = new[]{ "SalesOrderID" }, ChildColumnNames =  new[]{ "SalesOrderID" } , PropertyNames = new[]{ "SalesOrderID" }, ForeignFieldNames =  new[]{ "_salesOrderID" }, PrivateCollectionFieldName = "_salesOrderHeaderSalesReasonCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonCollection
		{
			get{ return _salesOrderHeaderSalesReasonCollection; }
			private set
			{
				if (SalesOrderHeaderSalesReasonCollection == value)
					return;
				_salesOrderHeaderSalesReasonCollection = value;
				onPropertyChanged(this, "SalesOrderHeaderSalesReasonCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Person.Address _addressParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Address", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "BillToAddressID" } , PropertyNames = new[]{ "BillToAddressID" }, ForeignFieldNames =  new[]{ "_addressID" } )]
		public Example.Entities.Person.Address AddressParent
		{
			get{ return _addressParent; }
			set{ _addressParent = value; onPropertyChanged(this, "AddressParent"); }
		}

		private Example.Entities.Person.Address _addressParent2;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Address", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "ShipToAddressID" } , PropertyNames = new[]{ "ShipToAddressID" }, ForeignFieldNames =  new[]{ "_addressID" } )]
		public Example.Entities.Person.Address AddressParent2
		{
			get{ return _addressParent2; }
			set{ _addressParent2 = value; onPropertyChanged(this, "AddressParent2"); }
		}

		private Example.Entities.Person.Contact _contactParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Contact", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" } )]
		public Example.Entities.Person.Contact ContactParent
		{
			get{ return _contactParent; }
			set{ _contactParent = value; onPropertyChanged(this, "ContactParent"); }
		}

		private Example.Entities.Purchasing.ShipMethod _shipMethodParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Purchasing.ShipMethod", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "ShipMethodID" }, ChildColumnNames =  new[]{ "ShipMethodID" } , PropertyNames = new[]{ "ShipMethodID" }, ForeignFieldNames =  new[]{ "_shipMethodID" } )]
		public Example.Entities.Purchasing.ShipMethod ShipMethodParent
		{
			get{ return _shipMethodParent; }
			set{ _shipMethodParent = value; onPropertyChanged(this, "ShipMethodParent"); }
		}

		private Example.Entities.Sales.CreditCard _creditCardParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.CreditCard", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "CreditCardID" }, ChildColumnNames =  new[]{ "CreditCardID" } , PropertyNames = new[]{ "CreditCardID" }, ForeignFieldNames =  new[]{ "_creditCardID" } )]
		public Example.Entities.Sales.CreditCard CreditCardParent
		{
			get{ return _creditCardParent; }
			set{ _creditCardParent = value; onPropertyChanged(this, "CreditCardParent"); }
		}

		private Example.Entities.Sales.CurrencyRate _currencyRateParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.CurrencyRate", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "CurrencyRateID" }, ChildColumnNames =  new[]{ "CurrencyRateID" } , PropertyNames = new[]{ "CurrencyRateID" }, ForeignFieldNames =  new[]{ "_currencyRateID" } )]
		public Example.Entities.Sales.CurrencyRate CurrencyRateParent
		{
			get{ return _currencyRateParent; }
			set{ _currencyRateParent = value; onPropertyChanged(this, "CurrencyRateParent"); }
		}

		private Example.Entities.Sales.Customer _customerParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Customer", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" } )]
		public Example.Entities.Sales.Customer CustomerParent
		{
			get{ return _customerParent; }
			set{ _customerParent = value; onPropertyChanged(this, "CustomerParent"); }
		}

		private Example.Entities.Sales.SalesPerson _salesPersonParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" } )]
		public Example.Entities.Sales.SalesPerson SalesPersonParent
		{
			get{ return _salesPersonParent; }
			set{ _salesPersonParent = value; onPropertyChanged(this, "SalesPersonParent"); }
		}

		private Example.Entities.Sales.SalesTerritory _salesTerritoryParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" } )]
		public Example.Entities.Sales.SalesTerritory SalesTerritoryParent
		{
			get{ return _salesTerritoryParent; }
			set{ _salesTerritoryParent = value; onPropertyChanged(this, "SalesTerritoryParent"); }
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
