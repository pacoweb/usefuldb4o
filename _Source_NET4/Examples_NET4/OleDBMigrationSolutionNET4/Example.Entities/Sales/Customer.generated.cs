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
	[TableInformation(TableName = "Sales.Customer")]
	[Serializable]
	public partial class Customer: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _customerID;

		[Required(ErrorMessage="CustomerID is required")]
		[ColumnInformation(ColumnName = "CustomerID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 CustomerID
		{
			get{ return _customerID; }
			set{ _customerID = value; onPropertyChanged(this, "CustomerID");}
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
		[UniqueFieldValueConstraint]
		private String _accountNumber;

		[Required(ErrorMessage="AccountNumber is required")]
		[StringLength(10, ErrorMessage="AccountNumber cannot be longer than 10 characters")]
		[ColumnInformation(ColumnName = "AccountNumber", CodeType = typeof(String), ColumnType = OleDbType.Char, IsPrimaryKey=false)]
		public String AccountNumber
		{
			get{ return _accountNumber; }
			set{ _accountNumber = value; onPropertyChanged(this, "AccountNumber");}
		}

		private String _customerType;

		[Required(ErrorMessage="CustomerType is required")]
		[StringLength(1, ErrorMessage="CustomerType cannot be longer than 1 characters")]
		[ColumnInformation(ColumnName = "CustomerType", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String CustomerType
		{
			get{ return _customerType; }
			set{ _customerType = value; onPropertyChanged(this, "CustomerType");}
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

		private ObservableCollection<Example.Entities.Sales.CustomerAddress> _customerAddressCollection = new ObservableCollection<Example.Entities.Sales.CustomerAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Customer", ChildTableName = "Sales.CustomerAddress", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" }, PrivateCollectionFieldName = "_customerAddressCollection" )]
		public ObservableCollection<Example.Entities.Sales.CustomerAddress> CustomerAddressCollection
		{
			get{ return _customerAddressCollection; }
			private set
			{
				if (CustomerAddressCollection == value)
					return;
				_customerAddressCollection = value;
				onPropertyChanged(this, "CustomerAddressCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.Individual> _individualCollection = new ObservableCollection<Example.Entities.Sales.Individual>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Customer", ChildTableName = "Sales.Individual", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" }, PrivateCollectionFieldName = "_individualCollection" )]
		public ObservableCollection<Example.Entities.Sales.Individual> IndividualCollection
		{
			get{ return _individualCollection; }
			private set
			{
				if (IndividualCollection == value)
					return;
				_individualCollection = value;
				onPropertyChanged(this, "IndividualCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Customer", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderHeader> SalesOrderHeaderCollection
		{
			get{ return _salesOrderHeaderCollection; }
			private set
			{
				if (SalesOrderHeaderCollection == value)
					return;
				_salesOrderHeaderCollection = value;
				onPropertyChanged(this, "SalesOrderHeaderCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.Store> _storeCollection = new ObservableCollection<Example.Entities.Sales.Store>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Customer", ChildTableName = "Sales.Store", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" }, PrivateCollectionFieldName = "_storeCollection" )]
		public ObservableCollection<Example.Entities.Sales.Store> StoreCollection
		{
			get{ return _storeCollection; }
			private set
			{
				if (StoreCollection == value)
					return;
				_storeCollection = value;
				onPropertyChanged(this, "StoreCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Sales.SalesTerritory _salesTerritoryParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.Customer", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" } )]
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
