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
	[TableInformation(TableName = "Sales.Individual")]
	[Serializable]
	public partial class Individual: INotifyPropertyChanged
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
		private Int32 _contactID;

		[Required(ErrorMessage="ContactID is required")]
		[ColumnInformation(ColumnName = "ContactID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; onPropertyChanged(this, "ContactID");}
		}

		[IndexedField]
		private Object _demographics;

		[ColumnInformation(ColumnName = "Demographics", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object Demographics
		{
			get{ return _demographics; }
			set{ _demographics = value; onPropertyChanged(this, "Demographics");}
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
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Contact", ChildTableName = "Sales.Individual", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" } )]
		public Example.Entities.Person.Contact ContactParent
		{
			get{ return _contactParent; }
			set{ _contactParent = value; onPropertyChanged(this, "ContactParent"); }
		}

		private Example.Entities.Sales.Customer _customerParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Customer", ChildTableName = "Sales.Individual", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" } )]
		public Example.Entities.Sales.Customer CustomerParent
		{
			get{ return _customerParent; }
			set{ _customerParent = value; onPropertyChanged(this, "CustomerParent"); }
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
