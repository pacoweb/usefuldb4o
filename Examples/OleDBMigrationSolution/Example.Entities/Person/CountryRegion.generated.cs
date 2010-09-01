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
	[TableInformation(TableName = "Person.CountryRegion")]
	[Serializable]
	public partial class CountryRegion: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _countryRegionCode;

		[Required(ErrorMessage="CountryRegionCode is required")]
		[StringLength(3, ErrorMessage="CountryRegionCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "CountryRegionCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=true)]
		public String CountryRegionCode
		{
			get{ return _countryRegionCode; }
			set{ _countryRegionCode = value; onPropertyChanged(this, "CountryRegionCode");}
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
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.CountryRegion", ChildTableName = "Person.StateProvince", ParentColumnNames = new[]{ "CountryRegionCode" }, ChildColumnNames =  new[]{ "CountryRegionCode" } , PropertyNames = new[]{ "CountryRegionCode" }, ForeignFieldNames =  new[]{ "_countryRegionCode" }, PrivateCollectionFieldName = "_stateProvinceCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.CountryRegionCurrency> _countryRegionCurrencyCollection = new ObservableCollection<Example.Entities.Sales.CountryRegionCurrency>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.CountryRegion", ChildTableName = "Sales.CountryRegionCurrency", ParentColumnNames = new[]{ "CountryRegionCode" }, ChildColumnNames =  new[]{ "CountryRegionCode" } , PropertyNames = new[]{ "CountryRegionCode" }, ForeignFieldNames =  new[]{ "_countryRegionCode" }, PrivateCollectionFieldName = "_countryRegionCurrencyCollection" )]
		public ObservableCollection<Example.Entities.Sales.CountryRegionCurrency> CountryRegionCurrencyCollection
		{
			get{ return _countryRegionCurrencyCollection; }
			private set
			{
				if (CountryRegionCurrencyCollection == value)
					return;
				_countryRegionCurrencyCollection = value;
				onPropertyChanged(this, "CountryRegionCurrencyCollection");
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
