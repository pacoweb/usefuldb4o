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

namespace Example.Entities.Person
{
	[TableInformation(TableName = "Person.ContactType")]
	[Serializable]
	public partial class ContactType: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _contactTypeID;

		[Required(ErrorMessage="ContactTypeID is required")]
		[ColumnInformation(ColumnName = "ContactTypeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ContactTypeID
		{
			get{ return _contactTypeID; }
			set{ _contactTypeID = value; onPropertyChanged(this, "ContactTypeID");}
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

		private ObservableCollection<Example.Entities.Purchasing.VendorContact> _vendorContactCollection = new ObservableCollection<Example.Entities.Purchasing.VendorContact>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.ContactType", ChildTableName = "Purchasing.VendorContact", ParentColumnNames = new[]{ "ContactTypeID" }, ChildColumnNames =  new[]{ "ContactTypeID" } , PropertyNames = new[]{ "ContactTypeID" }, ForeignFieldNames =  new[]{ "_contactTypeID" }, PrivateCollectionFieldName = "_vendorContactCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.VendorContact> VendorContactCollection
		{
			get{ return _vendorContactCollection; }
			private set
			{
				if (VendorContactCollection == value)
					return;
				_vendorContactCollection = value;
				onPropertyChanged(this, "VendorContactCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.StoreContact> _storeContactCollection = new ObservableCollection<Example.Entities.Sales.StoreContact>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Person.ContactType", ChildTableName = "Sales.StoreContact", ParentColumnNames = new[]{ "ContactTypeID" }, ChildColumnNames =  new[]{ "ContactTypeID" } , PropertyNames = new[]{ "ContactTypeID" }, ForeignFieldNames =  new[]{ "_contactTypeID" }, PrivateCollectionFieldName = "_storeContactCollection" )]
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
