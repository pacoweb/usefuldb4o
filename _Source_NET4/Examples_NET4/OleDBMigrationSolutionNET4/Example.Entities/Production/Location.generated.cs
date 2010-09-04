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
	[TableInformation(TableName = "Production.Location")]
	[Serializable]
	public partial class Location: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int16 _locationID;

		[Required(ErrorMessage="LocationID is required")]
		[ColumnInformation(ColumnName = "LocationID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=true)]
		public Int16 LocationID
		{
			get{ return _locationID; }
			set{ _locationID = value; onPropertyChanged(this, "LocationID");}
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

		private Decimal _costRate;

		[Required(ErrorMessage="CostRate is required")]
		[ColumnInformation(ColumnName = "CostRate", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal CostRate
		{
			get{ return _costRate; }
			set{ _costRate = value; onPropertyChanged(this, "CostRate");}
		}

		private Decimal _availability;

		[Required(ErrorMessage="Availability is required")]
		[ColumnInformation(ColumnName = "Availability", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal Availability
		{
			get{ return _availability; }
			set{ _availability = value; onPropertyChanged(this, "Availability");}
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

		private ObservableCollection<Example.Entities.Production.ProductInventory> _productInventoryCollection = new ObservableCollection<Example.Entities.Production.ProductInventory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Location", ChildTableName = "Production.ProductInventory", ParentColumnNames = new[]{ "LocationID" }, ChildColumnNames =  new[]{ "LocationID" } , PropertyNames = new[]{ "LocationID" }, ForeignFieldNames =  new[]{ "_locationID" }, PrivateCollectionFieldName = "_productInventoryCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductInventory> ProductInventoryCollection
		{
			get{ return _productInventoryCollection; }
			private set
			{
				if (ProductInventoryCollection == value)
					return;
				_productInventoryCollection = value;
				onPropertyChanged(this, "ProductInventoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.WorkOrderRouting> _workOrderRoutingCollection = new ObservableCollection<Example.Entities.Production.WorkOrderRouting>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Location", ChildTableName = "Production.WorkOrderRouting", ParentColumnNames = new[]{ "LocationID" }, ChildColumnNames =  new[]{ "LocationID" } , PropertyNames = new[]{ "LocationID" }, ForeignFieldNames =  new[]{ "_locationID" }, PrivateCollectionFieldName = "_workOrderRoutingCollection" )]
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
