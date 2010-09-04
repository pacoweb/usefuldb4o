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
	[TableInformation(TableName = "Sales.SalesPerson")]
	[Serializable]
	public partial class SalesPerson: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _salesPersonID;

		[Required(ErrorMessage="SalesPersonID is required")]
		[ColumnInformation(ColumnName = "SalesPersonID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesPersonID
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

		private Decimal? _salesQuota;

		[ColumnInformation(ColumnName = "SalesQuota", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal? SalesQuota
		{
			get{ return _salesQuota; }
			set{ _salesQuota = value; onPropertyChanged(this, "SalesQuota");}
		}

		private Decimal _bonus;

		[Required(ErrorMessage="Bonus is required")]
		[ColumnInformation(ColumnName = "Bonus", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal Bonus
		{
			get{ return _bonus; }
			set{ _bonus = value; onPropertyChanged(this, "Bonus");}
		}

		private Decimal _commissionPct;

		[Required(ErrorMessage="CommissionPct is required")]
		[ColumnInformation(ColumnName = "CommissionPct", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal CommissionPct
		{
			get{ return _commissionPct; }
			set{ _commissionPct = value; onPropertyChanged(this, "CommissionPct");}
		}

		private Decimal _salesYTD;

		[Required(ErrorMessage="SalesYTD is required")]
		[ColumnInformation(ColumnName = "SalesYTD", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal SalesYTD
		{
			get{ return _salesYTD; }
			set{ _salesYTD = value; onPropertyChanged(this, "SalesYTD");}
		}

		private Decimal _salesLastYear;

		[Required(ErrorMessage="SalesLastYear is required")]
		[ColumnInformation(ColumnName = "SalesLastYear", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal SalesLastYear
		{
			get{ return _salesLastYear; }
			set{ _salesLastYear = value; onPropertyChanged(this, "SalesLastYear");}
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

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.SalesPersonQuotaHistory> _salesPersonQuotaHistoryCollection = new ObservableCollection<Example.Entities.Sales.SalesPersonQuotaHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.SalesPersonQuotaHistory", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" }, PrivateCollectionFieldName = "_salesPersonQuotaHistoryCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesPersonQuotaHistory> SalesPersonQuotaHistoryCollection
		{
			get{ return _salesPersonQuotaHistoryCollection; }
			private set
			{
				if (SalesPersonQuotaHistoryCollection == value)
					return;
				_salesPersonQuotaHistoryCollection = value;
				onPropertyChanged(this, "SalesPersonQuotaHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesTerritoryHistory> _salesTerritoryHistoryCollection = new ObservableCollection<Example.Entities.Sales.SalesTerritoryHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.SalesTerritoryHistory", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" }, PrivateCollectionFieldName = "_salesTerritoryHistoryCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesTerritoryHistory> SalesTerritoryHistoryCollection
		{
			get{ return _salesTerritoryHistoryCollection; }
			private set
			{
				if (SalesTerritoryHistoryCollection == value)
					return;
				_salesTerritoryHistoryCollection = value;
				onPropertyChanged(this, "SalesTerritoryHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.Store> _storeCollection = new ObservableCollection<Example.Entities.Sales.Store>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.Store", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" }, PrivateCollectionFieldName = "_storeCollection" )]
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

		private Example.Entities.HumanResources.Employee _employeeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Employee", ChildTableName = "Sales.SalesPerson", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_employeeID" } )]
		public Example.Entities.HumanResources.Employee EmployeeParent
		{
			get{ return _employeeParent; }
			set{ _employeeParent = value; onPropertyChanged(this, "EmployeeParent"); }
		}

		private Example.Entities.Sales.SalesTerritory _salesTerritoryParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.SalesPerson", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" } )]
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
