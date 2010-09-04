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
	[TableInformation(TableName = "HumanResources.Department")]
	[Serializable]
	public partial class Department: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int16 _departmentID;

		[Required(ErrorMessage="DepartmentID is required")]
		[ColumnInformation(ColumnName = "DepartmentID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=true)]
		public Int16 DepartmentID
		{
			get{ return _departmentID; }
			set{ _departmentID = value; onPropertyChanged(this, "DepartmentID");}
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

		private String _groupName;

		[Required(ErrorMessage="GroupName is required")]
		[StringLength(50, ErrorMessage="GroupName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "GroupName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String GroupName
		{
			get{ return _groupName; }
			set{ _groupName = value; onPropertyChanged(this, "GroupName");}
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

		private ObservableCollection<Example.Entities.HumanResources.EmployeeDepartmentHistory> _employeeDepartmentHistoryCollection = new ObservableCollection<Example.Entities.HumanResources.EmployeeDepartmentHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Department", ChildTableName = "HumanResources.EmployeeDepartmentHistory", ParentColumnNames = new[]{ "DepartmentID" }, ChildColumnNames =  new[]{ "DepartmentID" } , PropertyNames = new[]{ "DepartmentID" }, ForeignFieldNames =  new[]{ "_departmentID" }, PrivateCollectionFieldName = "_employeeDepartmentHistoryCollection" )]
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
