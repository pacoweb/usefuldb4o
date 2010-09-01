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

namespace Example.Entities
{
	[TableInformation(TableName = "dbo.AWBuildVersion")]
	[Serializable]
	public partial class AWBuildVersion: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Byte _systemInformationID;

		[Required(ErrorMessage="SystemInformationID is required")]
		[ColumnInformation(ColumnName = "SystemInformationID", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=true)]
		public Byte SystemInformationID
		{
			get{ return _systemInformationID; }
			set{ _systemInformationID = value; onPropertyChanged(this, "SystemInformationID");}
		}

		private String _databaseVersion;

		[Required(ErrorMessage="DatabaseVersion is required")]
		[StringLength(25, ErrorMessage="DatabaseVersion cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "Database Version", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String DatabaseVersion
		{
			get{ return _databaseVersion; }
			set{ _databaseVersion = value; onPropertyChanged(this, "DatabaseVersion");}
		}

		private DateTime _versionDate;

		[Required(ErrorMessage="VersionDate is required")]
		[ColumnInformation(ColumnName = "Version-Date", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime VersionDate
		{
			get{ return _versionDate; }
			set{ _versionDate = value; onPropertyChanged(this, "VersionDate");}
		}

		private DateTime _modifiedDate;

		[Required(ErrorMessage="ModifiedDate is required")]
		[ColumnInformation(ColumnName = "Modified_Date", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; onPropertyChanged(this, "ModifiedDate");}
		}

		#endregion PROPERTIES

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
