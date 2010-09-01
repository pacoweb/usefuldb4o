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
	[TableInformation(TableName = "Person.Contact")]
	[Serializable]
	public partial class Contact: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _contactID;

		[Required(ErrorMessage="ContactID is required")]
		[ColumnInformation(ColumnName = "ContactID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; onPropertyChanged(this, "ContactID");}
		}

		private Boolean _nameStyle;

		[Required(ErrorMessage="NameStyle is required")]
		[ColumnInformation(ColumnName = "NameStyle", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean NameStyle
		{
			get{ return _nameStyle; }
			set{ _nameStyle = value; onPropertyChanged(this, "NameStyle");}
		}

		private String _title;

		[StringLength(8, ErrorMessage="Title cannot be longer than 8 characters")]
		[ColumnInformation(ColumnName = "Title", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Title
		{
			get{ return _title; }
			set{ _title = value; onPropertyChanged(this, "Title");}
		}

		private String _firstName;

		[Required(ErrorMessage="FirstName is required")]
		[StringLength(50, ErrorMessage="FirstName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "FirstName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String FirstName
		{
			get{ return _firstName; }
			set{ _firstName = value; onPropertyChanged(this, "FirstName");}
		}

		private String _middleName;

		[StringLength(50, ErrorMessage="MiddleName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "MiddleName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String MiddleName
		{
			get{ return _middleName; }
			set{ _middleName = value; onPropertyChanged(this, "MiddleName");}
		}

		private String _lastName;

		[Required(ErrorMessage="LastName is required")]
		[StringLength(50, ErrorMessage="LastName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "LastName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; onPropertyChanged(this, "LastName");}
		}

		private String _suffix;

		[StringLength(10, ErrorMessage="Suffix cannot be longer than 10 characters")]
		[ColumnInformation(ColumnName = "Suffix", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Suffix
		{
			get{ return _suffix; }
			set{ _suffix = value; onPropertyChanged(this, "Suffix");}
		}

		[IndexedField]
		private String _emailAddress;

		[StringLength(50, ErrorMessage="EmailAddress cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "EmailAddress", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String EmailAddress
		{
			get{ return _emailAddress; }
			set{ _emailAddress = value; onPropertyChanged(this, "EmailAddress");}
		}

		private Int32 _emailPromotion;

		[Required(ErrorMessage="EmailPromotion is required")]
		[ColumnInformation(ColumnName = "EmailPromotion", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 EmailPromotion
		{
			get{ return _emailPromotion; }
			set{ _emailPromotion = value; onPropertyChanged(this, "EmailPromotion");}
		}

		private String _phone;

		[StringLength(25, ErrorMessage="Phone cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "Phone", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Phone
		{
			get{ return _phone; }
			set{ _phone = value; onPropertyChanged(this, "Phone");}
		}

		private String _passwordHash;

		[Required(ErrorMessage="PasswordHash is required")]
		[StringLength(128, ErrorMessage="PasswordHash cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "PasswordHash", CodeType = typeof(String), ColumnType = OleDbType.Char, IsPrimaryKey=false)]
		public String PasswordHash
		{
			get{ return _passwordHash; }
			set{ _passwordHash = value; onPropertyChanged(this, "PasswordHash");}
		}

		private String _passwordSalt;

		[Required(ErrorMessage="PasswordSalt is required")]
		[StringLength(10, ErrorMessage="PasswordSalt cannot be longer than 10 characters")]
		[ColumnInformation(ColumnName = "PasswordSalt", CodeType = typeof(String), ColumnType = OleDbType.Char, IsPrimaryKey=false)]
		public String PasswordSalt
		{
			get{ return _passwordSalt; }
			set{ _passwordSalt = value; onPropertyChanged(this, "PasswordSalt");}
		}

		[IndexedField]
		private Object _additionalContactInfo;

		[ColumnInformation(ColumnName = "AdditionalContactInfo", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object AdditionalContactInfo
		{
			get{ return _additionalContactInfo; }
			set{ _additionalContactInfo = value; onPropertyChanged(this, "AdditionalContactInfo");}
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

		private ObservableCollection<Example.Entities.HumanResources.Employee> _employeeCollection = new ObservableCollection<Example.Entities.HumanResources.Employee>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Contact", ChildTableName = "HumanResources.Employee", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" }, PrivateCollectionFieldName = "_employeeCollection" )]
		public ObservableCollection<Example.Entities.HumanResources.Employee> EmployeeCollection
		{
			get{ return _employeeCollection; }
			private set
			{
				if (EmployeeCollection == value)
					return;
				_employeeCollection = value;
				onPropertyChanged(this, "EmployeeCollection");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.VendorContact> _vendorContactCollection = new ObservableCollection<Example.Entities.Purchasing.VendorContact>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Contact", ChildTableName = "Purchasing.VendorContact", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" }, PrivateCollectionFieldName = "_vendorContactCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.VendorContact> VendorContactCollection
		{
			get{ return _vendorContactCollection; }
			private set
			{
				if (VendorContactCollection == value)
					return;
				_vendorContactCollection = value;
				onPropertyChanged(this, "VendorContactCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.ContactCreditCard> _contactCreditCardCollection = new ObservableCollection<Example.Entities.Sales.ContactCreditCard>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Contact", ChildTableName = "Sales.ContactCreditCard", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" }, PrivateCollectionFieldName = "_contactCreditCardCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.Individual> _individualCollection = new ObservableCollection<Example.Entities.Sales.Individual>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Contact", ChildTableName = "Sales.Individual", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" }, PrivateCollectionFieldName = "_individualCollection" )]
		public ObservableCollection<Example.Entities.Sales.Individual> IndividualCollection
		{
			get{ return _individualCollection; }
			private set
			{
				if (IndividualCollection == value)
					return;
				_individualCollection = value;
				onPropertyChanged(this, "IndividualCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Contact", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
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

		private ObservableCollection<Example.Entities.Sales.StoreContact> _storeContactCollection = new ObservableCollection<Example.Entities.Sales.StoreContact>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.Contact", ChildTableName = "Sales.StoreContact", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" }, PrivateCollectionFieldName = "_storeContactCollection" )]
		public ObservableCollection<Example.Entities.Sales.StoreContact> StoreContactCollection
		{
			get{ return _storeContactCollection; }
			private set
			{
				if (StoreContactCollection == value)
					return;
				_storeContactCollection = value;
				onPropertyChanged(this, "StoreContactCollection");
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
