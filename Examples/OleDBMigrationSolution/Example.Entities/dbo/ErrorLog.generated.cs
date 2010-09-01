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
	[TableInformation(TableName = "dbo.ErrorLog")]
	[Serializable]
	public partial class ErrorLog: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _errorLogID;

		[Required(ErrorMessage="ErrorLogID is required")]
		[ColumnInformation(ColumnName = "ErrorLogID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ErrorLogID
		{
			get{ return _errorLogID; }
			set{ _errorLogID = value; onPropertyChanged(this, "ErrorLogID");}
		}

		private DateTime _errorTime;

		[Required(ErrorMessage="ErrorTime is required")]
		[ColumnInformation(ColumnName = "ErrorTime", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime ErrorTime
		{
			get{ return _errorTime; }
			set{ _errorTime = value; onPropertyChanged(this, "ErrorTime");}
		}

		private String _userName;

		[Required(ErrorMessage="UserName is required")]
		[StringLength(128, ErrorMessage="UserName cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "UserName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String UserName
		{
			get{ return _userName; }
			set{ _userName = value; onPropertyChanged(this, "UserName");}
		}

		private Int32 _errorNumber;

		[Required(ErrorMessage="ErrorNumber is required")]
		[ColumnInformation(ColumnName = "ErrorNumber", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ErrorNumber
		{
			get{ return _errorNumber; }
			set{ _errorNumber = value; onPropertyChanged(this, "ErrorNumber");}
		}

		private Int32? _errorSeverity;

		[ColumnInformation(ColumnName = "ErrorSeverity", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ErrorSeverity
		{
			get{ return _errorSeverity; }
			set{ _errorSeverity = value; onPropertyChanged(this, "ErrorSeverity");}
		}

		private Int32? _errorState;

		[ColumnInformation(ColumnName = "ErrorState", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ErrorState
		{
			get{ return _errorState; }
			set{ _errorState = value; onPropertyChanged(this, "ErrorState");}
		}

		private String _errorProcedure;

		[StringLength(126, ErrorMessage="ErrorProcedure cannot be longer than 126 characters")]
		[ColumnInformation(ColumnName = "ErrorProcedure", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ErrorProcedure
		{
			get{ return _errorProcedure; }
			set{ _errorProcedure = value; onPropertyChanged(this, "ErrorProcedure");}
		}

		private Int32? _errorLine;

		[ColumnInformation(ColumnName = "ErrorLine", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ErrorLine
		{
			get{ return _errorLine; }
			set{ _errorLine = value; onPropertyChanged(this, "ErrorLine");}
		}

		private String _errorMessage;

		[Required(ErrorMessage="ErrorMessage is required")]
		[StringLength(4000, ErrorMessage="ErrorMessage cannot be longer than 4000 characters")]
		[ColumnInformation(ColumnName = "ErrorMessage", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ErrorMessage
		{
			get{ return _errorMessage; }
			set{ _errorMessage = value; onPropertyChanged(this, "ErrorMessage");}
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
