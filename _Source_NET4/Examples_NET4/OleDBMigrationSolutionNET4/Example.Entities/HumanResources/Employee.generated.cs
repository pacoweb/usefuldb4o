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

namespace Example.Entities.HumanResources
{
	[TableInformation(TableName = "HumanResources.Employee")]
	[Serializable]
	public partial class Employee: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _employeeID;

		[Required(ErrorMessage="EmployeeID is required")]
		[ColumnInformation(ColumnName = "EmployeeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 EmployeeID
		{
			get{ return _employeeID; }
			set{ _employeeID = value; onPropertyChanged(this, "EmployeeID");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _nationalIDNumber;

		[Required(ErrorMessage="NationalIDNumber is required")]
		[StringLength(15, ErrorMessage="NationalIDNumber cannot be longer than 15 characters")]
		[ColumnInformation(ColumnName = "NationalIDNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String NationalIDNumber
		{
			get{ return _nationalIDNumber; }
			set{ _nationalIDNumber = value; onPropertyChanged(this, "NationalIDNumber");}
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
		[UniqueFieldValueConstraint]
		private String _loginID;

		[Required(ErrorMessage="LoginID is required")]
		[StringLength(256, ErrorMessage="LoginID cannot be longer than 256 characters")]
		[ColumnInformation(ColumnName = "LoginID", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String LoginID
		{
			get{ return _loginID; }
			set{ _loginID = value; onPropertyChanged(this, "LoginID");}
		}

		[IndexedField]
		private Int32? _managerID;

		[ColumnInformation(ColumnName = "ManagerID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ManagerID
		{
			get{ return _managerID; }
			set{ _managerID = value; onPropertyChanged(this, "ManagerID");}
		}

		private String _title;

		[Required(ErrorMessage="Title is required")]
		[StringLength(50, ErrorMessage="Title cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Title", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Title
		{
			get{ return _title; }
			set{ _title = value; onPropertyChanged(this, "Title");}
		}

		private DateTime _birthDate;

		[Required(ErrorMessage="BirthDate is required")]
		[ColumnInformation(ColumnName = "BirthDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime BirthDate
		{
			get{ return _birthDate; }
			set{ _birthDate = value; onPropertyChanged(this, "BirthDate");}
		}

		private String _maritalStatus;

		[Required(ErrorMessage="MaritalStatus is required")]
		[StringLength(1, ErrorMessage="MaritalStatus cannot be longer than 1 characters")]
		[ColumnInformation(ColumnName = "MaritalStatus", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String MaritalStatus
		{
			get{ return _maritalStatus; }
			set{ _maritalStatus = value; onPropertyChanged(this, "MaritalStatus");}
		}

		private String _gender;

		[Required(ErrorMessage="Gender is required")]
		[StringLength(1, ErrorMessage="Gender cannot be longer than 1 characters")]
		[ColumnInformation(ColumnName = "Gender", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Gender
		{
			get{ return _gender; }
			set{ _gender = value; onPropertyChanged(this, "Gender");}
		}

		private DateTime _hireDate;

		[Required(ErrorMessage="HireDate is required")]
		[ColumnInformation(ColumnName = "HireDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime HireDate
		{
			get{ return _hireDate; }
			set{ _hireDate = value; onPropertyChanged(this, "HireDate");}
		}

		private Boolean _salariedFlag;

		[Required(ErrorMessage="SalariedFlag is required")]
		[ColumnInformation(ColumnName = "SalariedFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean SalariedFlag
		{
			get{ return _salariedFlag; }
			set{ _salariedFlag = value; onPropertyChanged(this, "SalariedFlag");}
		}

		private Int16 _vacationHours;

		[Required(ErrorMessage="VacationHours is required")]
		[ColumnInformation(ColumnName = "VacationHours", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 VacationHours
		{
			get{ return _vacationHours; }
			set{ _vacationHours = value; onPropertyChanged(this, "VacationHours");}
		}

		private Int16 _sickLeaveHours;

		[Required(ErrorMessage="SickLeaveHours is required")]
		[ColumnInformation(ColumnName = "SickLeaveHours", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 SickLeaveHours
		{
			get{ return _sickLeaveHours; }
			set{ _sickLeaveHours = value; onPropertyChanged(this, "SickLeaveHours");}
		}

		private Boolean _currentFlag;

		[Required(ErrorMessage="CurrentFlag is required")]
		[ColumnInformation(ColumnName = "CurrentFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean CurrentFlag
		{
			get{ return _currentFlag; }
			set{ _currentFlag = value; onPropertyChanged(this, "CurrentFlag");}
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
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.Employee", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "ManagerID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_managerID" }, PrivateCollectionFieldName = "_employeeCollection" )]
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

		private ObservableCollection<Example.Entities.HumanResources.EmployeeAddress> _employeeAddressCollection = new ObservableCollection<Example.Entities.HumanResources.EmployeeAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.EmployeeAddress", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" }, PrivateCollectionFieldName = "_employeeAddressCollection" )]
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

		private ObservableCollection<Example.Entities.HumanResources.EmployeeDepartmentHistory> _employeeDepartmentHistoryCollection = new ObservableCollection<Example.Entities.HumanResources.EmployeeDepartmentHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.EmployeeDepartmentHistory", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" }, PrivateCollectionFieldName = "_employeeDepartmentHistoryCollection" )]
		public ObservableCollection<Example.Entities.HumanResources.EmployeeDepartmentHistory> EmployeeDepartmentHistoryCollection
		{
			get{ return _employeeDepartmentHistoryCollection; }
			private set
			{
				if (EmployeeDepartmentHistoryCollection == value)
					return;
				_employeeDepartmentHistoryCollection = value;
				onPropertyChanged(this, "EmployeeDepartmentHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.HumanResources.EmployeePayHistory> _employeePayHistoryCollection = new ObservableCollection<Example.Entities.HumanResources.EmployeePayHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.EmployeePayHistory", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" }, PrivateCollectionFieldName = "_employeePayHistoryCollection" )]
		public ObservableCollection<Example.Entities.HumanResources.EmployeePayHistory> EmployeePayHistoryCollection
		{
			get{ return _employeePayHistoryCollection; }
			private set
			{
				if (EmployeePayHistoryCollection == value)
					return;
				_employeePayHistoryCollection = value;
				onPropertyChanged(this, "EmployeePayHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.HumanResources.JobCandidate> _jobCandidateCollection = new ObservableCollection<Example.Entities.HumanResources.JobCandidate>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.JobCandidate", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" }, PrivateCollectionFieldName = "_jobCandidateCollection" )]
		public ObservableCollection<Example.Entities.HumanResources.JobCandidate> JobCandidateCollection
		{
			get{ return _jobCandidateCollection; }
			private set
			{
				if (JobCandidateCollection == value)
					return;
				_jobCandidateCollection = value;
				onPropertyChanged(this, "JobCandidateCollection");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader> _purchaseOrderHeaderCollection = new ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "Purchasing.PurchaseOrderHeader", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" }, PrivateCollectionFieldName = "_purchaseOrderHeaderCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader> PurchaseOrderHeaderCollection
		{
			get{ return _purchaseOrderHeaderCollection; }
			private set
			{
				if (PurchaseOrderHeaderCollection == value)
					return;
				_purchaseOrderHeaderCollection = value;
				onPropertyChanged(this, "PurchaseOrderHeaderCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesPerson> _salesPersonCollection = new ObservableCollection<Example.Entities.Sales.SalesPerson>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Employee", ChildTableName = "Sales.SalesPerson", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_salesPersonID" }, PrivateCollectionFieldName = "_salesPersonCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesPerson> SalesPersonCollection
		{
			get{ return _salesPersonCollection; }
			private set
			{
				if (SalesPersonCollection == value)
					return;
				_salesPersonCollection = value;
				onPropertyChanged(this, "SalesPersonCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.HumanResources.Employee _employeeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.Employee", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "ManagerID" } , PropertyNames = new[]{ "ManagerID" }, ForeignFieldNames =  new[]{ "_employeeID" } )]
		public Example.Entities.HumanResources.Employee EmployeeParent
		{
			get{ return _employeeParent; }
			set{ _employeeParent = value; onPropertyChanged(this, "EmployeeParent"); }
		}

		private Example.Entities.Person.Contact _contactParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Contact", ChildTableName = "HumanResources.Employee", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" } )]
		public Example.Entities.Person.Contact ContactParent
		{
			get{ return _contactParent; }
			set{ _contactParent = value; onPropertyChanged(this, "ContactParent"); }
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
