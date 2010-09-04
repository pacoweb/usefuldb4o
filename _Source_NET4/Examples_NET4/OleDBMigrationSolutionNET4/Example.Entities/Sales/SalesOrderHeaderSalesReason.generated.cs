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

namespace Example.Entities.Sales
{
	[TableInformation(TableName = "Sales.SalesOrderHeaderSalesReason")]
	[Serializable]
	public partial class SalesOrderHeaderSalesReason: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _salesOrderID;

		[Required(ErrorMessage="SalesOrderID is required")]
		[ColumnInformation(ColumnName = "SalesOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesOrderID
		{
			get{ return _salesOrderID; }
			set{ _salesOrderID = value; onPropertyChanged(this, "SalesOrderID");}
		}

		[IndexedField]
		private Int32 _salesReasonID;

		[Required(ErrorMessage="SalesReasonID is required")]
		[ColumnInformation(ColumnName = "SalesReasonID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesReasonID
		{
			get{ return _salesReasonID; }
			set{ _salesReasonID = value; onPropertyChanged(this, "SalesReasonID");}
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

		private Example.Entities.Sales.SalesOrderHeader _salesOrderHeaderParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesOrderHeader", ChildTableName = "Sales.SalesOrderHeaderSalesReason", ParentColumnNames = new[]{ "SalesOrderID" }, ChildColumnNames =  new[]{ "SalesOrderID" } , PropertyNames = new[]{ "SalesOrderID" }, ForeignFieldNames =  new[]{ "_salesOrderID" } )]
		public Example.Entities.Sales.SalesOrderHeader SalesOrderHeaderParent
		{
			get{ return _salesOrderHeaderParent; }
			set{ _salesOrderHeaderParent = value; onPropertyChanged(this, "SalesOrderHeaderParent"); }
		}

		private Example.Entities.Sales.SalesReason _salesReasonParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesReason", ChildTableName = "Sales.SalesOrderHeaderSalesReason", ParentColumnNames = new[]{ "SalesReasonID" }, ChildColumnNames =  new[]{ "SalesReasonID" } , PropertyNames = new[]{ "SalesReasonID" }, ForeignFieldNames =  new[]{ "_salesReasonID" } )]
		public Example.Entities.Sales.SalesReason SalesReasonParent
		{
			get{ return _salesReasonParent; }
			set{ _salesReasonParent = value; onPropertyChanged(this, "SalesReasonParent"); }
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
