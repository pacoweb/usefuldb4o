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
	[TableInformation(TableName = "dbo.DatabaseLog")]
	[Serializable]
	public partial class DatabaseLog: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _databaseLogID;

		[Required(ErrorMessage="DatabaseLogID is required")]
		[ColumnInformation(ColumnName = "DatabaseLogID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 DatabaseLogID
		{
			get{ return _databaseLogID; }
			set{ _databaseLogID = value; onPropertyChanged(this, "DatabaseLogID");}
		}

		private DateTime _postTime;

		[Required(ErrorMessage="PostTime is required")]
		[ColumnInformation(ColumnName = "PostTime", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime PostTime
		{
			get{ return _postTime; }
			set{ _postTime = value; onPropertyChanged(this, "PostTime");}
		}

		private String _databaseUser;

		[Required(ErrorMessage="DatabaseUser is required")]
		[StringLength(128, ErrorMessage="DatabaseUser cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "DatabaseUser", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String DatabaseUser
		{
			get{ return _databaseUser; }
			set{ _databaseUser = value; onPropertyChanged(this, "DatabaseUser");}
		}

		private String _event;

		[Required(ErrorMessage="Event is required")]
		[StringLength(128, ErrorMessage="Event cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "Event", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Event
		{
			get{ return _event; }
			set{ _event = value; onPropertyChanged(this, "Event");}
		}

		private String _schema;

		[StringLength(128, ErrorMessage="Schema cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "Schema", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Schema
		{
			get{ return _schema; }
			set{ _schema = value; onPropertyChanged(this, "Schema");}
		}

		private String _object;

		[StringLength(128, ErrorMessage="Object cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "Object", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Object
		{
			get{ return _object; }
			set{ _object = value; onPropertyChanged(this, "Object");}
		}

		private String _tSQL;

		[Required(ErrorMessage="TSQL is required")]
		[ColumnInformation(ColumnName = "TSQL", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String TSQL
		{
			get{ return _tSQL; }
			set{ _tSQL = value; onPropertyChanged(this, "TSQL");}
		}

		private Object _xmlEvent;

		[Required(ErrorMessage="XmlEvent is required")]
		[ColumnInformation(ColumnName = "XmlEvent", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object XmlEvent
		{
			get{ return _xmlEvent; }
			set{ _xmlEvent = value; onPropertyChanged(this, "XmlEvent");}
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
