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
	[TableInformation(TableName = "HumanResources.JobCandidate")]
	[Serializable]
	public partial class JobCandidate: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _jobCandidateID;

		[Required(ErrorMessage="JobCandidateID is required")]
		[ColumnInformation(ColumnName = "JobCandidateID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 JobCandidateID
		{
			get{ return _jobCandidateID; }
			set{ _jobCandidateID = value; onPropertyChanged(this, "JobCandidateID");}
		}

		[IndexedField]
		private Int32? _employeeID;

		[ColumnInformation(ColumnName = "EmployeeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? EmployeeID
		{
			get{ return _employeeID; }
			set{ _employeeID = value; onPropertyChanged(this, "EmployeeID");}
		}

		private Object _resume;

		[ColumnInformation(ColumnName = "Resume", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object Resume
		{
			get{ return _resume; }
			set{ _resume = value; onPropertyChanged(this, "Resume");}
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

		private Example.Entities.HumanResources.Employee _employeeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.JobCandidate", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" } )]
		public Example.Entities.HumanResources.Employee EmployeeParent
		{
			get{ return _employeeParent; }
			set{ _employeeParent = value; onPropertyChanged(this, "EmployeeParent"); }
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
