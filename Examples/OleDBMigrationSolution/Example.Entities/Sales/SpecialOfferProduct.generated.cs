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
	[TableInformation(TableName = "Sales.SpecialOfferProduct")]
	[Serializable]
	public partial class SpecialOfferProduct: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _specialOfferID;

		[Required(ErrorMessage="SpecialOfferID is required")]
		[ColumnInformation(ColumnName = "SpecialOfferID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SpecialOfferID
		{
			get{ return _specialOfferID; }
			set{ _specialOfferID = value; onPropertyChanged(this, "SpecialOfferID");}
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

		private ObservableCollection<Example.Entities.Sales.SalesOrderDetail> _salesOrderDetailCollection = new ObservableCollection<Example.Entities.Sales.SalesOrderDetail>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SpecialOfferProduct", ChildTableName = "Sales.SalesOrderDetail", ParentColumnNames = new[]{ "SpecialOfferID","ProductID" }, ChildColumnNames =  new[]{ "SpecialOfferID","ProductID" } , PropertyNames = new[]{ "SpecialOfferID","ProductID" }, ForeignFieldNames =  new[]{ "_specialOfferID","_productID" }, PrivateCollectionFieldName = "_salesOrderDetailCollection" )]
		public ObservableCollection<Example.Entities.Sales.SalesOrderDetail> SalesOrderDetailCollection
		{
			get{ return _salesOrderDetailCollection; }
			private set
			{
				if (SalesOrderDetailCollection == value)
					return;
				_salesOrderDetailCollection = value;
				onPropertyChanged(this, "SalesOrderDetailCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Production.Product _productParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Sales.SpecialOfferProduct", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
		}

		private Example.Entities.Sales.SpecialOffer _specialOfferParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SpecialOffer", ChildTableName = "Sales.SpecialOfferProduct", ParentColumnNames = new[]{ "SpecialOfferID" }, ChildColumnNames =  new[]{ "SpecialOfferID" } , PropertyNames = new[]{ "SpecialOfferID" }, ForeignFieldNames =  new[]{ "_specialOfferID" } )]
		public Example.Entities.Sales.SpecialOffer SpecialOfferParent
		{
			get{ return _specialOfferParent; }
			set{ _specialOfferParent = value; onPropertyChanged(this, "SpecialOfferParent"); }
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
