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
	[TableInformation(TableName = "Sales.Currency")]
	[Serializable]
	public partial class Currency: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _currencyCode;

		[Required(ErrorMessage="CurrencyCode is required")]
		[StringLength(3, ErrorMessage="CurrencyCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "CurrencyCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=true)]
		public String CurrencyCode
		{
			get{ return _currencyCode; }
			set{ _currencyCode = value; onPropertyChanged(this, "CurrencyCode");}
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

		private ObservableCollection<Example.Entities.Sales.CountryRegionCurrency> _countryRegionCurrencyCollection = new ObservableCollection<Example.Entities.Sales.CountryRegionCurrency>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Currency", ChildTableName = "Sales.CountryRegionCurrency", ParentColumnNames = new[]{ "CurrencyCode" }, ChildColumnNames =  new[]{ "CurrencyCode" } , PropertyNames = new[]{ "CurrencyCode" }, ForeignFieldNames =  new[]{ "_currencyCode" }, PrivateCollectionFieldName = "_countryRegionCurrencyCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.CurrencyRate> _currencyRateCollection = new ObservableCollection<Example.Entities.Sales.CurrencyRate>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Currency", ChildTableName = "Sales.CurrencyRate", ParentColumnNames = new[]{ "CurrencyCode" }, ChildColumnNames =  new[]{ "FromCurrencyCode" } , PropertyNames = new[]{ "CurrencyCode" }, ForeignFieldNames =  new[]{ "_fromCurrencyCode" }, PrivateCollectionFieldName = "_currencyRateCollection" )]
		public ObservableCollection<Example.Entities.Sales.CurrencyRate> CurrencyRateCollection
		{
			get{ return _currencyRateCollection; }
			private set
			{
				if (CurrencyRateCollection == value)
					return;
				_currencyRateCollection = value;
				onPropertyChanged(this, "CurrencyRateCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.CurrencyRate> _currencyRateCollection2 = new ObservableCollection<Example.Entities.Sales.CurrencyRate>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Currency", ChildTableName = "Sales.CurrencyRate", ParentColumnNames = new[]{ "CurrencyCode" }, ChildColumnNames =  new[]{ "ToCurrencyCode" } , PropertyNames = new[]{ "CurrencyCode" }, ForeignFieldNames =  new[]{ "_toCurrencyCode" }, PrivateCollectionFieldName = "_currencyRateCollection2" )]
		public ObservableCollection<Example.Entities.Sales.CurrencyRate> CurrencyRateCollection2
		{
			get{ return _currencyRateCollection2; }
			private set
			{
				if (CurrencyRateCollection2 == value)
					return;
				_currencyRateCollection2 = value;
				onPropertyChanged(this, "CurrencyRateCollection2");
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
