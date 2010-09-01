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
	[TableInformation(TableName = "Sales.Store")]
	[Serializable]
	public partial class Store: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _customerID;

		[Required(ErrorMessage="CustomerID is required")]
		[ColumnInformation(ColumnName = "CustomerID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 CustomerID
		{
			get{ return _customerID; }
			set{ _customerID = value; onPropertyChanged(this, "CustomerID");}
		}

		private String _name;

		[Required(ErrorMessage="Name is required")]
		[StringLength(50, ErrorMessage="Name cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Name", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Name
		{
			get{ return _name; }
			set{ _name = value; onPropertyChanged(this, "Name");}
		}

		[IndexedField]
		private Int32? _salesPersonID;

		[ColumnInformation(ColumnName = "SalesPersonID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? SalesPersonID
		{
			get{ return _salesPersonID; }
			set{ _salesPersonID = value; onPropertyChanged(this, "SalesPersonID");}
		}

		[IndexedField]
		private Object _demographics;

		[ColumnInformation(ColumnName = "Demographics", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object Demographics
		{
			get{ return _demographics; }
			set{ _demographics = value; onPropertyChanged(this, "Demographics");}
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

		private ObservableCollection<Example.Entities.Sales.StoreContact> _storeContactCollection = new ObservableCollection<Example.Entities.Sales.StoreContact>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.Store", ChildTableName = "Sales.StoreContact", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" }, PrivateCollectionFieldName = "_storeContactCollection" )]
		public ObservableCollection<Example.Entities.Sales.StoreContact> StoreContactCollection
		{
			get{ return _storeContactCollection; }
			private set
			{
				if (StoreContactCollection == value)
					return;
				_storeContactCollection = value;
				onPropertyChanged(this, "StoreContactCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Sales.Customer _customerParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.Customer", ChildTableName = "Sales.Store", ParentColumnNames = new[]{ "CustomerID" }, ChildColumnNames =  new[]{ "CustomerID" } , PropertyNames = new[]{ "CustomerID" }, ForeignFieldNames =  new[]{ "_customerID" } )]
		public Example.Entities.Sales.Customer CustomerParent
		{
			get{ return _customerParent; }
			set{ _customerParent = value; onPropertyChanged(this, "CustomerParent"); }
		}

		private Example.Entities.Sales.SalesPerson _salesPersonParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.Store", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" } )]
		public Example.Entities.Sales.SalesPerson SalesPersonParent
		{
			get{ return _salesPersonParent; }
			set{ _salesPersonParent = value; onPropertyChanged(this, "SalesPersonParent"); }
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
