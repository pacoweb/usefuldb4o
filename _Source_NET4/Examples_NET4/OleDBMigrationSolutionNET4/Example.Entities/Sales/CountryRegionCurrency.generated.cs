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
	[TableInformation(TableName = "Sales.CountryRegionCurrency")]
	[Serializable]
	public partial class CountryRegionCurrency: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
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
		private String _currencyCode;

		[Required(ErrorMessage="CurrencyCode is required")]
		[StringLength(3, ErrorMessage="CurrencyCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "CurrencyCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=true)]
		public String CurrencyCode
		{
			get{ return _currencyCode; }
			set{ _currencyCode = value; onPropertyChanged(this, "CurrencyCode");}
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

		private Example.Entities.Person.CountryRegion _countryRegionParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.CountryRegion", ChildTableName = "Sales.CountryRegionCurrency", ParentColumnNames = new[]{ "CountryRegionCode" }, ChildColumnNames =  new[]{ "CountryRegionCode" } , PropertyNames = new[]{ "CountryRegionCode" }, ForeignFieldNames =  new[]{ "_countryRegionCode" } )]
		public Example.Entities.Person.CountryRegion CountryRegionParent
		{
			get{ return _countryRegionParent; }
			set{ _countryRegionParent = value; onPropertyChanged(this, "CountryRegionParent"); }
		}

		private Example.Entities.Sales.Currency _currencyParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Currency", ChildTableName = "Sales.CountryRegionCurrency", ParentColumnNames = new[]{ "CurrencyCode" }, ChildColumnNames =  new[]{ "CurrencyCode" } , PropertyNames = new[]{ "CurrencyCode" }, ForeignFieldNames =  new[]{ "_currencyCode" } )]
		public Example.Entities.Sales.Currency CurrencyParent
		{
			get{ return _currencyParent; }
			set{ _currencyParent = value; onPropertyChanged(this, "CurrencyParent"); }
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
