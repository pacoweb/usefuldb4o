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
	[TableInformation(TableName = "Sales.SpecialOffer")]
	[Serializable]
	public partial class SpecialOffer: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _specialOfferID;

		[Required(ErrorMessage="SpecialOfferID is required")]
		[ColumnInformation(ColumnName = "SpecialOfferID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SpecialOfferID
		{
			get{ return _specialOfferID; }
			set{ _specialOfferID = value; onPropertyChanged(this, "SpecialOfferID");}
		}

		private String _description;

		[Required(ErrorMessage="Description is required")]
		[StringLength(255, ErrorMessage="Description cannot be longer than 255 characters")]
		[ColumnInformation(ColumnName = "Description", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Description
		{
			get{ return _description; }
			set{ _description = value; onPropertyChanged(this, "Description");}
		}

		private Decimal _discountPct;

		[Required(ErrorMessage="DiscountPct is required")]
		[ColumnInformation(ColumnName = "DiscountPct", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal DiscountPct
		{
			get{ return _discountPct; }
			set{ _discountPct = value; onPropertyChanged(this, "DiscountPct");}
		}

		private String _type;

		[Required(ErrorMessage="Type is required")]
		[StringLength(50, ErrorMessage="Type cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Type", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Type
		{
			get{ return _type; }
			set{ _type = value; onPropertyChanged(this, "Type");}
		}

		private String _category;

		[Required(ErrorMessage="Category is required")]
		[StringLength(50, ErrorMessage="Category cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Category", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Category
		{
			get{ return _category; }
			set{ _category = value; onPropertyChanged(this, "Category");}
		}

		private DateTime _startDate;

		[Required(ErrorMessage="StartDate is required")]
		[ColumnInformation(ColumnName = "StartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime StartDate
		{
			get{ return _startDate; }
			set{ _startDate = value; onPropertyChanged(this, "StartDate");}
		}

		private DateTime _endDate;

		[Required(ErrorMessage="EndDate is required")]
		[ColumnInformation(ColumnName = "EndDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime EndDate
		{
			get{ return _endDate; }
			set{ _endDate = value; onPropertyChanged(this, "EndDate");}
		}

		private Int32 _minQty;

		[Required(ErrorMessage="MinQty is required")]
		[ColumnInformation(ColumnName = "MinQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 MinQty
		{
			get{ return _minQty; }
			set{ _minQty = value; onPropertyChanged(this, "MinQty");}
		}

		private Int32? _maxQty;

		[ColumnInformation(ColumnName = "MaxQty", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? MaxQty
		{
			get{ return _maxQty; }
			set{ _maxQty = value; onPropertyChanged(this, "MaxQty");}
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

		private ObservableCollection<Example.Entities.Sales.SpecialOfferProduct> _specialOfferProductCollection = new ObservableCollection<Example.Entities.Sales.SpecialOfferProduct>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Sales.SpecialOffer", ChildTableName = "Sales.SpecialOfferProduct", ParentColumnNames = new[]{ "SpecialOfferID" }, ChildColumnNames =  new[]{ "SpecialOfferID" } , PropertyNames = new[]{ "SpecialOfferID" }, ForeignFieldNames =  new[]{ "_specialOfferID" }, PrivateCollectionFieldName = "_specialOfferProductCollection" )]
		public ObservableCollection<Example.Entities.Sales.SpecialOfferProduct> SpecialOfferProductCollection
		{
			get{ return _specialOfferProductCollection; }
			private set
			{
				if (SpecialOfferProductCollection == value)
					return;
				_specialOfferProductCollection = value;
				onPropertyChanged(this, "SpecialOfferProductCollection");
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
