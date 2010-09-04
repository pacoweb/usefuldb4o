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

namespace Example.Entities.Production
{
	[TableInformation(TableName = "Production.WorkOrderRouting")]
	[Serializable]
	public partial class WorkOrderRouting: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _workOrderID;

		[Required(ErrorMessage="WorkOrderID is required")]
		[ColumnInformation(ColumnName = "WorkOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 WorkOrderID
		{
			get{ return _workOrderID; }
			set{ _workOrderID = value; onPropertyChanged(this, "WorkOrderID");}
		}

		[IndexedField]
		private Int32 _productID;

		[Required(ErrorMessage="ProductID is required")]
		[ColumnInformation(ColumnName = "ProductID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductID
		{
			get{ return _productID; }
			set{ _productID = value; onPropertyChanged(this, "ProductID");}
		}

		[IndexedField]
		private Int16 _operationSequence;

		[Required(ErrorMessage="OperationSequence is required")]
		[ColumnInformation(ColumnName = "OperationSequence", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=true)]
		public Int16 OperationSequence
		{
			get{ return _operationSequence; }
			set{ _operationSequence = value; onPropertyChanged(this, "OperationSequence");}
		}

		[IndexedField]
		private Int16 _locationID;

		[Required(ErrorMessage="LocationID is required")]
		[ColumnInformation(ColumnName = "LocationID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 LocationID
		{
			get{ return _locationID; }
			set{ _locationID = value; onPropertyChanged(this, "LocationID");}
		}

		private DateTime _scheduledStartDate;

		[Required(ErrorMessage="ScheduledStartDate is required")]
		[ColumnInformation(ColumnName = "ScheduledStartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime ScheduledStartDate
		{
			get{ return _scheduledStartDate; }
			set{ _scheduledStartDate = value; onPropertyChanged(this, "ScheduledStartDate");}
		}

		private DateTime _scheduledEndDate;

		[Required(ErrorMessage="ScheduledEndDate is required")]
		[ColumnInformation(ColumnName = "ScheduledEndDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime ScheduledEndDate
		{
			get{ return _scheduledEndDate; }
			set{ _scheduledEndDate = value; onPropertyChanged(this, "ScheduledEndDate");}
		}

		private DateTime? _actualStartDate;

		[ColumnInformation(ColumnName = "ActualStartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? ActualStartDate
		{
			get{ return _actualStartDate; }
			set{ _actualStartDate = value; onPropertyChanged(this, "ActualStartDate");}
		}

		private DateTime? _actualEndDate;

		[ColumnInformation(ColumnName = "ActualEndDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? ActualEndDate
		{
			get{ return _actualEndDate; }
			set{ _actualEndDate = value; onPropertyChanged(this, "ActualEndDate");}
		}

		private Decimal? _actualResourceHrs;

		[ColumnInformation(ColumnName = "ActualResourceHrs", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal? ActualResourceHrs
		{
			get{ return _actualResourceHrs; }
			set{ _actualResourceHrs = value; onPropertyChanged(this, "ActualResourceHrs");}
		}

		private Decimal _plannedCost;

		[Required(ErrorMessage="PlannedCost is required")]
		[ColumnInformation(ColumnName = "PlannedCost", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal PlannedCost
		{
			get{ return _plannedCost; }
			set{ _plannedCost = value; onPropertyChanged(this, "PlannedCost");}
		}

		private Decimal? _actualCost;

		[ColumnInformation(ColumnName = "ActualCost", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal? ActualCost
		{
			get{ return _actualCost; }
			set{ _actualCost = value; onPropertyChanged(this, "ActualCost");}
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

		private Example.Entities.Production.Location _locationParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Location", ChildTableName = "Production.WorkOrderRouting", ParentColumnNames = new[]{ "LocationID" }, ChildColumnNames =  new[]{ "LocationID" } , PropertyNames = new[]{ "LocationID" }, ForeignFieldNames =  new[]{ "_locationID" } )]
		public Example.Entities.Production.Location LocationParent
		{
			get{ return _locationParent; }
			set{ _locationParent = value; onPropertyChanged(this, "LocationParent"); }
		}

		private Example.Entities.Production.WorkOrder _workOrderParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.WorkOrder", ChildTableName = "Production.WorkOrderRouting", ParentColumnNames = new[]{ "WorkOrderID" }, ChildColumnNames =  new[]{ "WorkOrderID" } , PropertyNames = new[]{ "WorkOrderID" }, ForeignFieldNames =  new[]{ "_workOrderID" } )]
		public Example.Entities.Production.WorkOrder WorkOrderParent
		{
			get{ return _workOrderParent; }
			set{ _workOrderParent = value; onPropertyChanged(this, "WorkOrderParent"); }
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
