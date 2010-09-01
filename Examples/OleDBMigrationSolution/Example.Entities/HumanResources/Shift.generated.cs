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
	[TableInformation(TableName = "HumanResources.Shift")]
	[Serializable]
	public partial class Shift: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Byte _shiftID;

		[Required(ErrorMessage="ShiftID is required")]
		[ColumnInformation(ColumnName = "ShiftID", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=true)]
		public Byte ShiftID
		{
			get{ return _shiftID; }
			set{ _shiftID = value; onPropertyChanged(this, "ShiftID");}
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
		private DateTime _startTime;

		[Required(ErrorMessage="StartTime is required")]
		[ColumnInformation(ColumnName = "StartTime", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime StartTime
		{
			get{ return _startTime; }
			set{ _startTime = value; onPropertyChanged(this, "StartTime");}
		}

		[IndexedField]
		private DateTime _endTime;

		[Required(ErrorMessage="EndTime is required")]
		[ColumnInformation(ColumnName = "EndTime", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime EndTime
		{
			get{ return _endTime; }
			set{ _endTime = value; onPropertyChanged(this, "EndTime");}
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
		[RelationInformation(IsEntityParent=true, ParentTableName = "HumanResources.Shift", ChildTableName = "HumanResources.EmployeeDepartmentHistory", ParentColumnNames = new[]{ "ShiftID" }, ChildColumnNames =  new[]{ "ShiftID" } , PropertyNames = new[]{ "ShiftID" }, ForeignFieldNames =  new[]{ "_shiftID" }, PrivateCollectionFieldName = "_employeeDepartmentHistoryCollection" )]
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
