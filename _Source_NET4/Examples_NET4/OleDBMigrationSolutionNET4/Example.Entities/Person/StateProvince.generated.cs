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

namespace Example.Entities.Person
{
	[TableInformation(TableName = "Person.StateProvince")]
	[Serializable]
	public partial class StateProvince: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _stateProvinceID;

		[Required(ErrorMessage="StateProvinceID is required")]
		[ColumnInformation(ColumnName = "StateProvinceID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 StateProvinceID
		{
			get{ return _stateProvinceID; }
			set{ _stateProvinceID = value; onPropertyChanged(this, "StateProvinceID");}
		}

		[IndexedField]
		private String _stateProvinceCode;

		[Required(ErrorMessage="StateProvinceCode is required")]
		[StringLength(3, ErrorMessage="StateProvinceCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "StateProvinceCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String StateProvinceCode
		{
			get{ return _stateProvinceCode; }
			set{ _stateProvinceCode = value; onPropertyChanged(this, "StateProvinceCode");}
		}

		[IndexedField]
		private String _countryRegionCode;

		[Required(ErrorMessage="CountryRegionCode is required")]
		[StringLength(3, ErrorMessage="CountryRegionCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "CountryRegionCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String CountryRegionCode
		{
			get{ return _countryRegionCode; }
			set{ _countryRegionCode = value; onPropertyChanged(this, "CountryRegionCode");}
		}

		private Boolean _isOnlyStateProvinceFlag;

		[Required(ErrorMessage="IsOnlyStateProvinceFlag is required")]
		[ColumnInformation(ColumnName = "IsOnlyStateProvinceFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean IsOnlyStateProvinceFlag
		{
			get{ return _isOnlyStateProvinceFlag; }
			set{ _isOnlyStateProvinceFlag = value; onPropertyChanged(this, "IsOnlyStateProvinceFlag");}
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

		[IndexedField]
		private Int32 _territoryID;

		[Required(ErrorMessage="TerritoryID is required")]
		[ColumnInformation(ColumnName = "TerritoryID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 TerritoryID
		{
			get{ return _territoryID; }
			set{ _territoryID = value; onPropertyChanged(this, "TerritoryID");}
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

		private ObservableCollection<Example.Entities.Person.Address> _addressCollection = new ObservableCollection<Example.Entities.Person.Address>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.StateProvince", ChildTableName = "Person.Address", ParentColumnNames = new[]{ "StateProvinceID" }, ChildColumnNames =  new[]{ "StateProvinceID" } , PropertyNames = new[]{ "StateProvinceID" }, ForeignFieldNames =  new[]{ "_stateProvinceID" }, PrivateCollectionFieldName = "_addressCollection" )]
		public ObservableCollection<Example.Entities.Person.Address> AddressCollection
		{
			get{ return _addressCollection; }
			private set
			{
				if (AddressCollection == value)
					return;
				_addressCollection = value;
				onPropertyChanged(this, "AddressCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesTaxRate> _salesTaxRateCollection = new ObservableCollection<Example.Entities.Sales.SalesTaxRate>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.StateProvince", ChildTableName = "Sales.SalesTaxRate", ParentColumnNames = new[]{ "StateProvinceID" }, ChildColumnNames =  new[]{ "StateProvinceID" } , PropertyNames = new[]{ "StateProvinceID" }, ForeignFieldNames =  new[]{ "_stateProvinceID" }, PrivateCollectionFieldName = "_salesTaxRateCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesTaxRate> SalesTaxRateCollection
		{
			get{ return _salesTaxRateCollection; }
			private set
			{
				if (SalesTaxRateCollection == value)
					return;
				_salesTaxRateCollection = value;
				onPropertyChanged(this, "SalesTaxRateCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Person.CountryRegion _countryRegionParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.CountryRegion", ChildTableName = "Person.StateProvince", ParentColumnNames = new[]{ "CountryRegionCode" }, ChildColumnNames =  new[]{ "CountryRegionCode" } , PropertyNames = new[]{ "CountryRegionCode" }, ForeignFieldNames =  new[]{ "_countryRegionCode" } )]
		public Example.Entities.Person.CountryRegion CountryRegionParent
		{
			get{ return _countryRegionParent; }
			set{ _countryRegionParent = value; onPropertyChanged(this, "CountryRegionParent"); }
		}

		private Example.Entities.Sales.SalesTerritory _salesTerritoryParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Person.StateProvince", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" } )]
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
