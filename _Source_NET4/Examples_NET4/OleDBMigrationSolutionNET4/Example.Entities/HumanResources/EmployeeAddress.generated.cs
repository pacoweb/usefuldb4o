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
	[TableInformation(TableName = "HumanResources.EmployeeAddress")]
	[Serializable]
	public partial class EmployeeAddress: INotifyPropertyChanged
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
		private Int32 _addressID;

		[Required(ErrorMessage="AddressID is required")]
		[ColumnInformation(ColumnName = "AddressID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; onPropertyChanged(this, "AddressID");}
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

		private Example.Entities.HumanResources.Employee _employeeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "HumanResources.Employee", ChildTableName = "HumanResources.EmployeeAddress", ParentColumnNames = new[]{ "EmployeeID" }, ChildColumnNames =  new[]{ "EmployeeID" } , PropertyNames = new[]{ "EmployeeID" }, ForeignFieldNames =  new[]{ "_employeeID" } )]
		public Example.Entities.HumanResources.Employee EmployeeParent
		{
			get{ return _employeeParent; }
			set{ _employeeParent = value; onPropertyChanged(this, "EmployeeParent"); }
		}

		private Example.Entities.Person.Address _addressParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Address", ChildTableName = "HumanResources.EmployeeAddress", ParentColumnNames = new[]{ "AddressID" }, ChildColumnNames =  new[]{ "AddressID" } , PropertyNames = new[]{ "AddressID" }, ForeignFieldNames =  new[]{ "_addressID" } )]
		public Example.Entities.Person.Address AddressParent
		{
			get{ return _addressParent; }
			set{ _addressParent = value; onPropertyChanged(this, "AddressParent"); }
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
