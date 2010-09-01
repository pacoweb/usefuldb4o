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
	[TableInformation(TableName = "Sales.CurrencyRate")]
	[Serializable]
	public partial class CurrencyRate: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _currencyRateID;

		[Required(ErrorMessage="CurrencyRateID is required")]
		[ColumnInformation(ColumnName = "CurrencyRateID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 CurrencyRateID
		{
			get{ return _currencyRateID; }
			set{ _currencyRateID = value; onPropertyChanged(this, "CurrencyRateID");}
		}

		[IndexedField]
		private DateTime _currencyRateDate;

		[Required(ErrorMessage="CurrencyRateDate is required")]
		[ColumnInformation(ColumnName = "CurrencyRateDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime CurrencyRateDate
		{
			get{ return _currencyRateDate; }
			set{ _currencyRateDate = value; onPropertyChanged(this, "CurrencyRateDate");}
		}

		[IndexedField]
		private String _fromCurrencyCode;

		[Required(ErrorMessage="FromCurrencyCode is required")]
		[StringLength(3, ErrorMessage="FromCurrencyCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "FromCurrencyCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String FromCurrencyCode
		{
			get{ return _fromCurrencyCode; }
			set{ _fromCurrencyCode = value; onPropertyChanged(this, "FromCurrencyCode");}
		}

		[IndexedField]
		private String _toCurrencyCode;

		[Required(ErrorMessage="ToCurrencyCode is required")]
		[StringLength(3, ErrorMessage="ToCurrencyCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "ToCurrencyCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ToCurrencyCode
		{
			get{ return _toCurrencyCode; }
			set{ _toCurrencyCode = value; onPropertyChanged(this, "ToCurrencyCode");}
		}

		private Decimal _averageRate;

		[Required(ErrorMessage="AverageRate is required")]
		[ColumnInformation(ColumnName = "AverageRate", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal AverageRate
		{
			get{ return _averageRate; }
			set{ _averageRate = value; onPropertyChanged(this, "AverageRate");}
		}

		private Decimal _endOfDayRate;

		[Required(ErrorMessage="EndOfDayRate is required")]
		[ColumnInformation(ColumnName = "EndOfDayRate", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal EndOfDayRate
		{
			get{ return _endOfDayRate; }
			set{ _endOfDayRate = value; onPropertyChanged(this, "EndOfDayRate");}
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
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.CurrencyRate", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "CurrencyRateID" }, ChildColumnNames =  new[]{ "CurrencyRateID" } , PropertyNames = new[]{ "CurrencyRateID" }, ForeignFieldNames =  new[]{ "_currencyRateID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
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

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Sales.Currency _currencyParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Currency", ChildTableName = "Sales.CurrencyRate", ParentColumnNames = new[]{ "CurrencyCode" }, ChildColumnNames =  new[]{ "FromCurrencyCode" } , PropertyNames = new[]{ "FromCurrencyCode" }, ForeignFieldNames =  new[]{ "_currencyCode" } )]
		public Example.Entities.Sales.Currency CurrencyParent
		{
			get{ return _currencyParent; }
			set{ _currencyParent = value; onPropertyChanged(this, "CurrencyParent"); }
		}

		private Example.Entities.Sales.Currency _currencyParent2;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Currency", ChildTableName = "Sales.CurrencyRate", ParentColumnNames = new[]{ "CurrencyCode" }, ChildColumnNames =  new[]{ "ToCurrencyCode" } , PropertyNames = new[]{ "ToCurrencyCode" }, ForeignFieldNames =  new[]{ "_currencyCode" } )]
		public Example.Entities.Sales.Currency CurrencyParent2
		{
			get{ return _currencyParent2; }
			set{ _currencyParent2 = value; onPropertyChanged(this, "CurrencyParent2"); }
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
