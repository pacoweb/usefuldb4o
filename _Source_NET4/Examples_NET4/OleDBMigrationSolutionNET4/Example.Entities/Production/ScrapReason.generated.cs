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
	[TableInformation(TableName = "Production.ScrapReason")]
	[Serializable]
	public partial class ScrapReason: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int16 _scrapReasonID;

		[Required(ErrorMessage="ScrapReasonID is required")]
		[ColumnInformation(ColumnName = "ScrapReasonID", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=true)]
		public Int16 ScrapReasonID
		{
			get{ return _scrapReasonID; }
			set{ _scrapReasonID = value; onPropertyChanged(this, "ScrapReasonID");}
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

		private ObservableCollection<Example.Entities.Production.WorkOrder> _workOrderCollection = new ObservableCollection<Example.Entities.Production.WorkOrder>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ScrapReason", ChildTableName = "Production.WorkOrder", ParentColumnNames = new[]{ "ScrapReasonID" }, ChildColumnNames =  new[]{ "ScrapReasonID" } , PropertyNames = new[]{ "ScrapReasonID" }, ForeignFieldNames =  new[]{ "_scrapReasonID" }, PrivateCollectionFieldName = "_workOrderCollection" )]
		public ObservableCollection<Example.Entities.Production.WorkOrder> WorkOrderCollection
		{
			get{ return _workOrderCollection; }
			private set
			{
				if (WorkOrderCollection == value)
					return;
				_workOrderCollection = value;
				onPropertyChanged(this, "WorkOrderCollection");
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
