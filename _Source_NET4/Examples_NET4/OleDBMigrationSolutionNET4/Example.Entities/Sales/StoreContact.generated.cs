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
	[TableInformation(TableName = "Sales.StoreContact")]
	[Serializable]
	public partial class StoreContact: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
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
		[ColumnInformation(ColumnName = "ContactID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; onPropertyChanged(this, "ContactID");}
		}

		[IndexedField]
		private Int32 _contactTypeID;

		[Required(ErrorMessage="ContactTypeID is required")]
		[ColumnInformation(ColumnName = "ContactTypeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ContactTypeID
		{
			get{ return _contactTypeID; }
			set{ _contactTypeID = value; onPropertyChanged(this, "ContactTypeID");}
		}

		[IndexedField]
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

		#region PARENT PROPERTIES

		private Example.Entities.Person.Contact _contactParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Contact", ChildTableName = "Sales.StoreContact", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" } )]
		public Example.Entities.Person.Contact ContactParent
		{
			get{ return _contactParent; }
			set{ _contactParent = value; onPropertyChanged(this, "ContactParent"); }
		}

		private Example.Entities.Person.ContactType _contactTypeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.ContactType", ChildTableName = "Sales.StoreContact", ParentColumnNames = new[]{ "ContactTypeID" }, ChildColumnNames =  new[]{ "ContactTypeID" } , PropertyNames = new[]{ "ContactTypeID" }, ForeignFieldNames =  new[]{ "_contactTypeID" } )]
		public Example.Entities.Person.ContactType ContactTypeParent
		{
			get{ return _contactTypeParent; }
			set{ _contactTypeParent = value; onPropertyChanged(this, "ContactTypeParent"); }
		}

		private Example.Entities.Sales.Store _storeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Store", ChildTableName = "Sales.StoreContact", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" } )]
		public Example.Entities.Sales.Store StoreParent
		{
			get{ return _storeParent; }
			set{ _storeParent = value; onPropertyChanged(this, "StoreParent"); }
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
