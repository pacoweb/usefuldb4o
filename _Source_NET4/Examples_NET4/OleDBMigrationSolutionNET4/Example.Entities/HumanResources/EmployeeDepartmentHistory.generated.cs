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
	[TableInformation(TableName = "HumanResources.EmployeeDepartmentHistory")]
	[Serializable]
	public partial class EmployeeDepartmentHistory: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _employeeID;

		[Required(ErrorMessage="EmployeeID is required")]
		[ColumnInformation(ColumnName = "EmployeeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 EmployeeID
		{
			get{ return _employeeID; }
			set{ _employeeID = value; onPropertyChanged(this, "EmployeeID");}
		}

		[IndexedField]
		private Int16 _departmentID;

		[Required(ErrorMessage="DepartmentID is required")]
		[ColumnInformation(ColumnName = "DepartmentID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=true)]
		public Int16 DepartmentID
		{
			get{ return _departmentID; }
			set{ _departmentID = value; onPropertyChanged(this, "DepartmentID");}
		}

		[IndexedField]
		private Byte _shiftID;

		[Required(ErrorMessage="ShiftID is required")]
		[ColumnInformation(ColumnName = "ShiftID", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=true)]
		public Byte ShiftID
		{
			get{ return _shiftID; }
			set{ _shiftID = value; onPropertyChanged(this, "ShiftID");}
		}

		[IndexedField]
		private DateTime _startDate;

		[Required(ErrorMessage="StartDate is required")]
		[ColumnInformation(ColumnName = "StartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=true)]
		public DateTime StartDate
		{
			get{ return _startDate; }
			set{ _startDate = value; onPropertyChanged(this, "StartDate");}
		}

		private DateTime? _endDate;

		[ColumnInformation(ColumnName = "EndDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? EndDate
		{
			get{ return _endDate; }
			set{ _endDate = value; onPropertyChanged(this, "EndDate");}
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

		private Example.Entities.HumanResources.Department _departmentParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Department", ChildTableName = "HumanResources.EmployeeDepartmentHistory", ParentColumnNames = new[]{ "DepartmentID" }, ChildColumnNames =  new[]{ "DepartmentID" } , PropertyNames = new[]{ "DepartmentID" }, ForeignFieldNames =  new[]{ "_departmentID" } )]
		public Example.Entities.HumanResources.Department DepartmentParent
		{
			get{ return _departmentParent; }
			set{ _departmentParent = value; onPropertyChanged(this, "DepartmentParent"); }
		}

		private Example.Entities.HumanResources.Employee _employeeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.EmployeeDepartmentHistory", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" } )]
		public Example.Entities.HumanResources.Employee EmployeeParent
		{
			get{ return _employeeParent; }
			set{ _employeeParent = value; onPropertyChanged(this, "EmployeeParent"); }
		}

		private Example.Entities.HumanResources.Shift _shiftParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Shift", ChildTableName = "HumanResources.EmployeeDepartmentHistory", ParentColumnNames = new[]{ "ShiftID" }, ChildColumnNames =  new[]{ "ShiftID" } , PropertyNames = new[]{ "ShiftID" }, ForeignFieldNames =  new[]{ "_shiftID" } )]
		public Example.Entities.HumanResources.Shift ShiftParent
		{
			get{ return _shiftParent; }
			set{ _shiftParent = value; onPropertyChanged(this, "ShiftParent"); }
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
