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
	[TableInformation(TableName = "Production.WorkOrder")]
	[Serializable]
	public partial class WorkOrder: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
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
		[ColumnInformation(ColumnName = "ProductID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ProductID
		{
			get{ return _productID; }
			set{ _productID = value; onPropertyChanged(this, "ProductID");}
		}

		private Int32 _orderQty;

		[Required(ErrorMessage="OrderQty is required")]
		[ColumnInformation(ColumnName = "OrderQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 OrderQty
		{
			get{ return _orderQty; }
			set{ _orderQty = value; onPropertyChanged(this, "OrderQty");}
		}

		private Int32 _stockedQty;

		[Required(ErrorMessage="StockedQty is required")]
		[ColumnInformation(ColumnName = "StockedQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 StockedQty
		{
			get{ return _stockedQty; }
			set{ _stockedQty = value; onPropertyChanged(this, "StockedQty");}
		}

		private Int16 _scrappedQty;

		[Required(ErrorMessage="ScrappedQty is required")]
		[ColumnInformation(ColumnName = "ScrappedQty", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 ScrappedQty
		{
			get{ return _scrappedQty; }
			set{ _scrappedQty = value; onPropertyChanged(this, "ScrappedQty");}
		}

		private DateTime _startDate;

		[Required(ErrorMessage="StartDate is required")]
		[ColumnInformation(ColumnName = "StartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
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

		private DateTime _dueDate;

		[Required(ErrorMessage="DueDate is required")]
		[ColumnInformation(ColumnName = "DueDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime DueDate
		{
			get{ return _dueDate; }
			set{ _dueDate = value; onPropertyChanged(this, "DueDate");}
		}

		[IndexedField]
		private Int16? _scrapReasonID;

		[ColumnInformation(ColumnName = "ScrapReasonID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16? ScrapReasonID
		{
			get{ return _scrapReasonID; }
			set{ _scrapReasonID = value; onPropertyChanged(this, "ScrapReasonID");}
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

		private ObservableCollection<Example.Entities.Production.WorkOrderRouting> _workOrderRoutingCollection = new ObservableCollection<Example.Entities.Production.WorkOrderRouting>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.WorkOrder", ChildTableName = "Production.WorkOrderRouting", ParentColumnNames = new[]{ "WorkOrderID" }, ChildColumnNames =  new[]{ "WorkOrderID" } , PropertyNames = new[]{ "WorkOrderID" }, ForeignFieldNames =  new[]{ "_workOrderID" }, PrivateCollectionFieldName = "_workOrderRoutingCollection" )]
		public ObservableCollection<Example.Entities.Production.WorkOrderRouting> WorkOrderRoutingCollection
		{
			get{ return _workOrderRoutingCollection; }
			private set
			{
				if (WorkOrderRoutingCollection == value)
					return;
				_workOrderRoutingCollection = value;
				onPropertyChanged(this, "WorkOrderRoutingCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Production.Product _productParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.WorkOrder", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
		}

		private Example.Entities.Production.ScrapReason _scrapReasonParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ScrapReason", ChildTableName = "Production.WorkOrder", ParentColumnNames = new[]{ "ScrapReasonID" }, ChildColumnNames =  new[]{ "ScrapReasonID" } , PropertyNames = new[]{ "ScrapReasonID" }, ForeignFieldNames =  new[]{ "_scrapReasonID" } )]
		public Example.Entities.Production.ScrapReason ScrapReasonParent
		{
			get{ return _scrapReasonParent; }
			set{ _scrapReasonParent = value; onPropertyChanged(this, "ScrapReasonParent"); }
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
