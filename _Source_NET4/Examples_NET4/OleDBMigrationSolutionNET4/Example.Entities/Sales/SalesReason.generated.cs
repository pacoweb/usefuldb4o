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
	[TableInformation(TableName = "Sales.SalesReason")]
	[Serializable]
	public partial class SalesReason: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _salesReasonID;

		[Required(ErrorMessage="SalesReasonID is required")]
		[ColumnInformation(ColumnName = "SalesReasonID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesReasonID
		{
			get{ return _salesReasonID; }
			set{ _salesReasonID = value; onPropertyChanged(this, "SalesReasonID");}
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

		private String _reasonType;

		[Required(ErrorMessage="ReasonType is required")]
		[StringLength(50, ErrorMessage="ReasonType cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "ReasonType", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ReasonType
		{
			get{ return _reasonType; }
			set{ _reasonType = value; onPropertyChanged(this, "ReasonType");}
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

		private ObservableCollection<Example.Entities.Sales.SalesOrderHeaderSalesReason> _salesOrderHeaderSalesReasonCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderHeaderSalesReason>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SalesReason", ChildTableName = "Sales.SalesOrderHeaderSalesReason", ParentColumnNames = new[]{ "SalesReasonID" }, ChildColumnNames =  new[]{ "SalesReasonID" } , PropertyNames = new[]{ "SalesReasonID" }, ForeignFieldNames =  new[]{ "_salesReasonID" }, PrivateCollectionFieldName = "_salesOrderHeaderSalesReasonCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasonCollection
		{
			get{ return _salesOrderHeaderSalesReasonCollection; }
			private set
			{
				if (SalesOrderHeaderSalesReasonCollection == value)
					return;
				_salesOrderHeaderSalesReasonCollection = value;
				onPropertyChanged(this, "SalesOrderHeaderSalesReasonCollection");
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
