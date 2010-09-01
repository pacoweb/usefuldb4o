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

namespace Example.Entities.Purchasing
{
	[TableInformation(TableName = "Purchasing.ShipMethod")]
	[Serializable]
	public partial class ShipMethod: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _shipMethodID;

		[Required(ErrorMessage="ShipMethodID is required")]
		[ColumnInformation(ColumnName = "ShipMethodID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ShipMethodID
		{
			get{ return _shipMethodID; }
			set{ _shipMethodID = value; onPropertyChanged(this, "ShipMethodID");}
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

		private Decimal _shipBase;

		[Required(ErrorMessage="ShipBase is required")]
		[ColumnInformation(ColumnName = "ShipBase", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal ShipBase
		{
			get{ return _shipBase; }
			set{ _shipBase = value; onPropertyChanged(this, "ShipBase");}
		}

		private Decimal _shipRate;

		[Required(ErrorMessage="ShipRate is required")]
		[ColumnInformation(ColumnName = "ShipRate", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal ShipRate
		{
			get{ return _shipRate; }
			set{ _shipRate = value; onPropertyChanged(this, "ShipRate");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
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

		#region CHILD PROPERTIES

		private ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader> _purchaseOrderHeaderCollection = new ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.ShipMethod", ChildTableName = "Purchasing.PurchaseOrderHeader", ParentColumnNames = new[]{ "ShipMethodID" }, ChildColumnNames =  new[]{ "ShipMethodID" } , PropertyNames = new[]{ "ShipMethodID" }, ForeignFieldNames =  new[]{ "_shipMethodID" }, PrivateCollectionFieldName = "_purchaseOrderHeaderCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader> PurchaseOrderHeaderCollection
		{
			get{ return _purchaseOrderHeaderCollection; }
			private set
			{
				if (PurchaseOrderHeaderCollection == value)
					return;
				_purchaseOrderHeaderCollection = value;
				onPropertyChanged(this, "PurchaseOrderHeaderCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeader> _salesOrderHeaderCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.ShipMethod", ChildTableName = "Sales.SalesOrderHeader", ParentColumnNames = new[]{ "ShipMethodID" }, ChildColumnNames =  new[]{ "ShipMethodID" } , PropertyNames = new[]{ "ShipMethodID" }, ForeignFieldNames =  new[]{ "_shipMethodID" }, PrivateCollectionFieldName = "_salesOrderHeaderCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderHeader> SalesOrderHeaderCollection
		{
			get{ return _salesOrderHeaderCollection; }
			private set
			{
				if (SalesOrderHeaderCollection == value)
					return;
				_salesOrderHeaderCollection = value;
				onPropertyChanged(this, "SalesOrderHeaderCollection");
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
