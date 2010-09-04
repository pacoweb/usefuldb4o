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
	[TableInformation(TableName = "Purchasing.Vendor")]
	[Serializable]
	public partial class Vendor: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _vendorID;

		[Required(ErrorMessage="VendorID is required")]
		[ColumnInformation(ColumnName = "VendorID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 VendorID
		{
			get{ return _vendorID; }
			set{ _vendorID = value; onPropertyChanged(this, "VendorID");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _accountNumber;

		[Required(ErrorMessage="AccountNumber is required")]
		[StringLength(15, ErrorMessage="AccountNumber cannot be longer than 15 characters")]
		[ColumnInformation(ColumnName = "AccountNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String AccountNumber
		{
			get{ return _accountNumber; }
			set{ _accountNumber = value; onPropertyChanged(this, "AccountNumber");}
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

		private Byte _creditRating;

		[Required(ErrorMessage="CreditRating is required")]
		[ColumnInformation(ColumnName = "CreditRating", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte CreditRating
		{
			get{ return _creditRating; }
			set{ _creditRating = value; onPropertyChanged(this, "CreditRating");}
		}

		private Boolean _preferredVendorStatus;

		[Required(ErrorMessage="PreferredVendorStatus is required")]
		[ColumnInformation(ColumnName = "PreferredVendorStatus", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean PreferredVendorStatus
		{
			get{ return _preferredVendorStatus; }
			set{ _preferredVendorStatus = value; onPropertyChanged(this, "PreferredVendorStatus");}
		}

		private Boolean _activeFlag;

		[Required(ErrorMessage="ActiveFlag is required")]
		[ColumnInformation(ColumnName = "ActiveFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean ActiveFlag
		{
			get{ return _activeFlag; }
			set{ _activeFlag = value; onPropertyChanged(this, "ActiveFlag");}
		}

		private String _purchasingWebServiceURL;

		[StringLength(1024, ErrorMessage="PurchasingWebServiceURL cannot be longer than 1024 characters")]
		[ColumnInformation(ColumnName = "PurchasingWebServiceURL", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String PurchasingWebServiceURL
		{
			get{ return _purchasingWebServiceURL; }
			set{ _purchasingWebServiceURL = value; onPropertyChanged(this, "PurchasingWebServiceURL");}
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

		private ObservableCollection<Example.Entities.Purchasing.ProductVendor> _productVendorCollection = new ObservableCollection<Example.Entities.Purchasing.ProductVendor>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.ProductVendor", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" }, PrivateCollectionFieldName = "_productVendorCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.ProductVendor> ProductVendorCollection
		{
			get{ return _productVendorCollection; }
			private set
			{
				if (ProductVendorCollection == value)
					return;
				_productVendorCollection = value;
				onPropertyChanged(this, "ProductVendorCollection");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader> _purchaseOrderHeaderCollection = new ObservableCollection<Example.Entities.Purchasing.PurchaseOrderHeader>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.PurchaseOrderHeader", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" }, PrivateCollectionFieldName = "_purchaseOrderHeaderCollection" )]
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

		private ObservableCollection<Example.Entities.Purchasing.VendorAddress> _vendorAddressCollection = new ObservableCollection<Example.Entities.Purchasing.VendorAddress>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.VendorAddress", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" }, PrivateCollectionFieldName = "_vendorAddressCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.VendorAddress> VendorAddressCollection
		{
			get{ return _vendorAddressCollection; }
			private set
			{
				if (VendorAddressCollection == value)
					return;
				_vendorAddressCollection = value;
				onPropertyChanged(this, "VendorAddressCollection");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.VendorContact> _vendorContactCollection = new ObservableCollection<Example.Entities.Purchasing.VendorContact>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Purchasing.Vendor", ChildTableName = "Purchasing.VendorContact", ParentColumnNames = new[]{ "VendorID" }, ChildColumnNames =  new[]{ "VendorID" } , PropertyNames = new[]{ "VendorID" }, ForeignFieldNames =  new[]{ "_vendorID" }, PrivateCollectionFieldName = "_vendorContactCollection" )]
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
