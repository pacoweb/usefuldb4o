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
	[TableInformation(TableName = "Purchasing.VendorContact")]
	[Serializable]
	public partial class VendorContact: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _vendorID;

		[Required(ErrorMessage="VendorID is required")]
		[ColumnInformation(ColumnName = "VendorID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 VendorID
		{
			get{ return _vendorID; }
			set{ _vendorID = value; onPropertyChanged(this, "VendorID");}
		}

		[IndexedField]
		private Int32 _contactID;

		[Required(ErrorMessage="ContactID is required")]
		[ColumnInformation(ColumnName = "ContactID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; onPropertyChanged(this, "ContactID");}
		}

		[IndexedField]
		private Int32 _contactTypeID;

		[Required(ErrorMessage="ContactTypeID is required")]
		[ColumnInformation(ColumnName = "ContactTypeID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ContactTypeID
		{
			get{ return _contactTypeID; }
			set{ _contactTypeID = value; onPropertyChanged(this, "ContactTypeID");}
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

		private Example.Entities.Person.Contact _contactParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.Contact", ChildTableName = "Purchasing.VendorContact", ParentColumnNames = new[]{ "ContactID" }, ChildColumnNames =  new[]{ "ContactID" } , PropertyNames = new[]{ "ContactID" }, ForeignFieldNames =  new[]{ "_contactID" } )]
		public Example.Entities.Person.Contact ContactParent
		{
			get{ return _contactParent; }
			set{ _contactParent = value; onPropertyChanged(this, "ContactParent"); }
		}

		private Example.Entities.Person.ContactType _contactTypeParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.ContactType", ChildTableName = "Purchasing.VendorContact", ParentColumnNames = new[]{ "ContactTypeID" }, ChildColumnNames =  new[]{ "ContactTypeID" } , PropertyNames = new[]{ "ContactTypeID" }, ForeignFieldNames =  new[]{ "_contactTypeID" } )]
		public Example.Entities.Person.ContactType ContactTypeParent
		{
			get{ return _contactTypeParent; }
			set{ _contactTypeParent = value; onPropertyChanged(this, "ContactTypeParent"); }
		}

		private Example.Entities.Purchasing.Vendor _vendorParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.VendorContact", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" } )]
		public Example.Entities.Purchasing.Vendor VendorParent
		{
			get{ return _vendorParent; }
			set{ _vendorParent = value; onPropertyChanged(this, "VendorParent"); }
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
