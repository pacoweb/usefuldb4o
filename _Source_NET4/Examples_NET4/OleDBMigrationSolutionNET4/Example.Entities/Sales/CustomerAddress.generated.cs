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
	[TableInformation(TableName = "Sales.CustomerAddress")]
	[Serializable]
	public partial class CustomerAddress: INotifyPropertyChanged
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
		private Int32 _addressID;

		[Required(ErrorMessage="AddressID is required")]
		[ColumnInformation(ColumnName = "AddressID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; onPropertyChanged(this, "AddressID");}
		}

		[IndexedField]
		private Int32 _addressTypeID;

		[Required(ErrorMessage="AddressTypeID is required")]
		[ColumnInformation(ColumnName = "AddressTypeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 AddressTypeID
		{
			get{ return _addressTypeID; }
			set{ _addressTypeID = value; onPropertyChanged(this, "AddressTypeID");}
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

		private Example.Entities.Person.Address _addressParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Address", ChildTableName = "Sales.CustomerAddress", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "AddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_addressID" } )]
		public Example.Entities.Person.Address AddressParent
		{
			get{ return _addressParent; }
			set{ _addressParent = value; onPropertyChanged(this, "AddressParent"); }
		}

		private Example.Entities.Person.AddressType _addressTypeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.AddressType", ChildTableName = "Sales.CustomerAddress", ParentColumnNames = new[]{ "AddressTypeID" }, ChildColumnNames =  new[]{ "AddressTypeID" } , PropertyNames = new[]{ "AddressTypeID" }, ForeignFieldNames =  new[]{ "_addressTypeID" } )]
		public Example.Entities.Person.AddressType AddressTypeParent
		{
			get{ return _addressTypeParent; }
			set{ _addressTypeParent = value; onPropertyChanged(this, "AddressTypeParent"); }
		}

		private Example.Entities.Sales.Customer _customerParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Customer", ChildTableName = "Sales.CustomerAddress", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" } )]
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
