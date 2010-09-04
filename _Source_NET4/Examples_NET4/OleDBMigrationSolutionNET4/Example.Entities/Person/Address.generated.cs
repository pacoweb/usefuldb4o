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
	[TableInformation(TableName = "Person.Address")]
	[Serializable]
	public partial class Address: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _addressID;

		[Required(ErrorMessage="AddressID is required")]
		[ColumnInformation(ColumnName = "AddressID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; onPropertyChanged(this, "AddressID");}
		}

		[IndexedField]
		private String _addressLine1;

		[Required(ErrorMessage="AddressLine1 is required")]
		[StringLength(60, ErrorMessage="AddressLine1 cannot be longer than 60 characters")]
		[ColumnInformation(ColumnName = "AddressLine1", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String AddressLine1
		{
			get{ return _addressLine1; }
			set{ _addressLine1 = value; onPropertyChanged(this, "AddressLine1");}
		}

		[IndexedField]
		private String _addressLine2;

		[StringLength(60, ErrorMessage="AddressLine2 cannot be longer than 60 characters")]
		[ColumnInformation(ColumnName = "AddressLine2", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String AddressLine2
		{
			get{ return _addressLine2; }
			set{ _addressLine2 = value; onPropertyChanged(this, "AddressLine2");}
		}

		[IndexedField]
		private String _city;

		[Required(ErrorMessage="City is required")]
		[StringLength(30, ErrorMessage="City cannot be longer than 30 characters")]
		[ColumnInformation(ColumnName = "City", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String City
		{
			get{ return _city; }
			set{ _city = value; onPropertyChanged(this, "City");}
		}

		[IndexedField]
		private Int32 _stateProvinceID;

		[Required(ErrorMessage="StateProvinceID is required")]
		[ColumnInformation(ColumnName = "StateProvinceID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 StateProvinceID
		{
			get{ return _stateProvinceID; }
			set{ _stateProvinceID = value; onPropertyChanged(this, "StateProvinceID");}
		}

		[IndexedField]
		private String _postalCode;

		[Required(ErrorMessage="PostalCode is required")]
		[StringLength(15, ErrorMessage="PostalCode cannot be longer than 15 characters")]
		[ColumnInformation(ColumnName = "PostalCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String PostalCode
		{
			get{ return _postalCode; }
			set{ _postalCode = value; onPropertyChanged(this, "PostalCode");}
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

		private ObservableCollection<Example.Entities.HumanResources.EmployeeAddress> _employeeAddressCollection = new ObservableCollection<Example.Entities.HumanResources.EmployeeAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Address", ChildTableName = "HumanResources.EmployeeAddress", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "AddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_addressID" }, PrivateCollectionFieldName = "_employeeAddressCollection" )]
		public ObservableCollection<Example.Entities.HumanResources.EmployeeAddress> EmployeeAddressCollection
		{
			get{ return _employeeAddressCollection; }
			private set
			{
				if (EmployeeAddressCollection == value)
					return;
				_employeeAddressCollection = value;
				onPropertyChanged(this, "EmployeeAddressCollection");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.VendorAddress> _vendorAddressCollection = new ObservableCollection<Example.Entities.Purchasing.VendorAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Address", ChildTableName = "Purchasing.VendorAddress", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "AddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_addressID" }, PrivateCollectionFieldName = "_vendorAddressCollection" )]
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
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Address", ChildTableName = "Sales.CustomerAddress", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "AddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_addressID" }, PrivateCollectionFieldName = "_customerAddressCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Address", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "BillToAddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_billToAddressID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection2 = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Address", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "ShipToAddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_shipToAddressID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection2" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderHeader> SalesOrderHeaderCollection2
		{
			get{ return _salesOrderHeaderCollection2; }
			private set
			{
				if (SalesOrderHeaderCollection2 == value)
					return;
				_salesOrderHeaderCollection2 = value;
				onPropertyChanged(this, "SalesOrderHeaderCollection2");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Person.StateProvince _stateProvinceParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.StateProvince", ChildTableName = "Person.Address", ParentColumnNames = new[]{ "StateProvinceID" }, ChildColumnNames =  new[]{ "StateProvinceID" } , PropertyNames = new[]{ "StateProvinceID" }, ForeignFieldNames =  new[]{ "_stateProvinceID" } )]
		public Example.Entities.Person.StateProvince StateProvinceParent
		{
			get{ return _stateProvinceParent; }
			set{ _stateProvinceParent = value; onPropertyChanged(this, "StateProvinceParent"); }
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
