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
	[TableInformation(TableName = "Sales.CreditCard")]
	[Serializable]
	public partial class CreditCard: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _creditCardID;

		[Required(ErrorMessage="CreditCardID is required")]
		[ColumnInformation(ColumnName = "CreditCardID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 CreditCardID
		{
			get{ return _creditCardID; }
			set{ _creditCardID = value; onPropertyChanged(this, "CreditCardID");}
		}

		private String _cardType;

		[Required(ErrorMessage="CardType is required")]
		[StringLength(50, ErrorMessage="CardType cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "CardType", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String CardType
		{
			get{ return _cardType; }
			set{ _cardType = value; onPropertyChanged(this, "CardType");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _cardNumber;

		[Required(ErrorMessage="CardNumber is required")]
		[StringLength(25, ErrorMessage="CardNumber cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "CardNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String CardNumber
		{
			get{ return _cardNumber; }
			set{ _cardNumber = value; onPropertyChanged(this, "CardNumber");}
		}

		private Byte _expMonth;

		[Required(ErrorMessage="ExpMonth is required")]
		[ColumnInformation(ColumnName = "ExpMonth", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte ExpMonth
		{
			get{ return _expMonth; }
			set{ _expMonth = value; onPropertyChanged(this, "ExpMonth");}
		}

		private Int16 _expYear;

		[Required(ErrorMessage="ExpYear is required")]
		[ColumnInformation(ColumnName = "ExpYear", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 ExpYear
		{
			get{ return _expYear; }
			set{ _expYear = value; onPropertyChanged(this, "ExpYear");}
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

		private ObservableCollection<Example.Entities.Sales.ContactCreditCard> _contactCreditCardCollection = new ObservableCollection<Example.Entities.Sales.ContactCreditCard>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.CreditCard", ChildTableName = "Sales.ContactCreditCard", ParentColumnNames = new[]{ "CreditCardID" }, ChildColumnNames =  new[]{ "CreditCardID" } , PropertyNames = new[]{ "CreditCardID" }, ForeignFieldNames =  new[]{ "_creditCardID" }, PrivateCollectionFieldName = "_contactCreditCardCollection" )]
		public ObservableCollection<Example.Entities.Sales.ContactCreditCard> ContactCreditCardCollection
		{
			get{ return _contactCreditCardCollection; }
			private set
			{
				if (ContactCreditCardCollection == value)
					return;
				_contactCreditCardCollection = value;
				onPropertyChanged(this, "ContactCreditCardCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.CreditCard", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "CreditCardID" }, ChildColumnNames =  new[]{ "CreditCardID" } , PropertyNames = new[]{ "CreditCardID" }, ForeignFieldNames =  new[]{ "_creditCardID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
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
