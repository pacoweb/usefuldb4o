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
	[TableInformation(TableName = "Person.AddressType")]
	[Serializable]
	public partial class AddressType: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _addressTypeID;

		[Required(ErrorMessage="AddressTypeID is required")]
		[ColumnInformation(ColumnName = "AddressTypeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 AddressTypeID
		{
			get{ return _addressTypeID; }
			set{ _addressTypeID = value; onPropertyChanged(this, "AddressTypeID");}
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

		private ObservableCollection<Example.Entities.Purchasing.VendorAddress> _vendorAddressCollection = new ObservableCollection<Example.Entities.Purchasing.VendorAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.AddressType", ChildTableName = "Purchasing.VendorAddress", ParentColumnNames = new[]{ "AddressTypeID" }, ChildColumnNames =  new[]{ "AddressTypeID" } , PropertyNames = new[]{ "AddressTypeID" }, ForeignFieldNames =  new[]{ "_addressTypeID" }, PrivateCollectionFieldName = "_vendorAddressCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.VendorAddress> VendorAddressCollection
		{
			get{ return _vendorAddressCollection; }
			private set
			{
				if (VendorAddressCollection == value)
					return;
				_vendorAddressCollection = value;
				onPropertyChanged(this, "VendorAddressCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.CustomerAddress> _customerAddressCollection = new ObservableCollection<Example.Entities.Sales.CustomerAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.AddressType", ChildTableName = "Sales.CustomerAddress", ParentColumnNames = new[]{ "AddressTypeID" }, ChildColumnNames =  new[]{ "AddressTypeID" } , PropertyNames = new[]{ "AddressTypeID" }, ForeignFieldNames =  new[]{ "_addressTypeID" }, PrivateCollectionFieldName = "_customerAddressCollection" )]
		public ObservableCollection<Example.Entities.Sales.CustomerAddress> CustomerAddressCollection
		{
			get{ return _customerAddressCollection; }
			private set
			{
				if (CustomerAddressCollection == value)
					return;
				_customerAddressCollection = value;
				onPropertyChanged(this, "CustomerAddressCollection");
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
