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
	[TableInformation(TableName = "Sales.SalesTerritory")]
	[Serializable]
	public partial class SalesTerritory: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _territoryID;

		[Required(ErrorMessage="TerritoryID is required")]
		[ColumnInformation(ColumnName = "TerritoryID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 TerritoryID
		{
			get{ return _territoryID; }
			set{ _territoryID = value; onPropertyChanged(this, "TerritoryID");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _name;

		[Required(ErrorMessage="Name is required")]
		[StringLength(50, ErrorMessage="Name cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Name", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Name
		{
			get{ return _name; }
			set{ _name = value; onPropertyChanged(this, "Name");}
		}

		private String _countryRegionCode;

		[Required(ErrorMessage="CountryRegionCode is required")]
		[StringLength(3, ErrorMessage="CountryRegionCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "CountryRegionCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String CountryRegionCode
		{
			get{ return _countryRegionCode; }
			set{ _countryRegionCode = value; onPropertyChanged(this, "CountryRegionCode");}
		}

		private String _group;

		[Required(ErrorMessage="Group is required")]
		[StringLength(50, ErrorMessage="Group cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Group", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Group
		{
			get{ return _group; }
			set{ _group = value; onPropertyChanged(this, "Group");}
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

		private Decimal _costYTD;

		[Required(ErrorMessage="CostYTD is required")]
		[ColumnInformation(ColumnName = "CostYTD", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal CostYTD
		{
			get{ return _costYTD; }
			set{ _costYTD = value; onPropertyChanged(this, "CostYTD");}
		}

		private Decimal _costLastYear;

		[Required(ErrorMessage="CostLastYear is required")]
		[ColumnInformation(ColumnName = "CostLastYear", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal CostLastYear
		{
			get{ return _costLastYear; }
			set{ _costLastYear = value; onPropertyChanged(this, "CostLastYear");}
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

		private ObservableCollection<Example.Entities.Person.StateProvince> _stateProvinceCollection = new ObservableCollection<Example.Entities.Person.StateProvince>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Person.StateProvince", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" }, PrivateCollectionFieldName = "_stateProvinceCollection" )]
		public ObservableCollection<Example.Entities.Person.StateProvince> StateProvinceCollection
		{
			get{ return _stateProvinceCollection; }
			private set
			{
				if (StateProvinceCollection == value)
					return;
				_stateProvinceCollection = value;
				onPropertyChanged(this, "StateProvinceCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.Customer> _customerCollection = new ObservableCollection<Example.Entities.Sales.Customer>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.Customer", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" }, PrivateCollectionFieldName = "_customerCollection" )]
		public ObservableCollection<Example.Entities.Sales.Customer> CustomerCollection
		{
			get{ return _customerCollection; }
			private set
			{
				if (CustomerCollection == value)
					return;
				_customerCollection = value;
				onPropertyChanged(this, "CustomerCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.SalesPerson> _salesPersonCollection = new ObservableCollection<Example.Entities.Sales.SalesPerson>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.SalesPerson", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" }, PrivateCollectionFieldName = "_salesPersonCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesPerson> SalesPersonCollection
		{
			get{ return _salesPersonCollection; }
			private set
			{
				if (SalesPersonCollection == value)
					return;
				_salesPersonCollection = value;
				onPropertyChanged(this, "SalesPersonCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesTerritoryHistory> _salesTerritoryHistoryCollection = new ObservableCollection<Example.Entities.Sales.SalesTerritoryHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.SalesTerritoryHistory", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" }, PrivateCollectionFieldName = "_salesTerritoryHistoryCollection" )]
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
