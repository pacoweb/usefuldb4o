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
	[TableInformation(TableName = "Sales.ContactCreditCard")]
	[Serializable]
	public partial class ContactCreditCard: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _contactID;

		[Required(ErrorMessage="ContactID is required")]
		[ColumnInformation(ColumnName = "ContactID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; onPropertyChanged(this, "ContactID");}
		}

		[IndexedField]
		private Int32 _creditCardID;

		[Required(ErrorMessage="CreditCardID is required")]
		[ColumnInformation(ColumnName = "CreditCardID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 CreditCardID
		{
			get{ return _creditCardID; }
			set{ _creditCardID = value; onPropertyChanged(this, "CreditCardID");}
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

		private Example.Entities.Person.Contact _contactParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Contact", ChildTableName = "Sales.ContactCreditCard", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" } )]
		public Example.Entities.Person.Contact ContactParent
		{
			get{ return _contactParent; }
			set{ _contactParent = value; onPropertyChanged(this, "ContactParent"); }
		}

		private Example.Entities.Sales.CreditCard _creditCardParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.CreditCard", ChildTableName = "Sales.ContactCreditCard", ParentColumnNames = new[]{ "CreditCardID" }, ChildColumnNames =  new[]{ "CreditCardID" } , PropertyNames = new[]{ "CreditCardID" }, ForeignFieldNames =  new[]{ "_creditCardID" } )]
		public Example.Entities.Sales.CreditCard CreditCardParent
		{
			get{ return _creditCardParent; }
			set{ _creditCardParent = value; onPropertyChanged(this, "CreditCardParent"); }
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
