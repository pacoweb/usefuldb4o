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
	[TableInformation(TableName = "Production.TransactionHistory")]
	[Serializable]
	public partial class TransactionHistory: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _transactionID;

		[Required(ErrorMessage="TransactionID is required")]
		[ColumnInformation(ColumnName = "TransactionID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; onPropertyChanged(this, "TransactionID");}
		}

		[IndexedField]
		private Int32 _productID;

		[Required(ErrorMessage="ProductID is required")]
		[ColumnInformation(ColumnName = "ProductID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ProductID
		{
			get{ return _productID; }
			set{ _productID = value; onPropertyChanged(this, "ProductID");}
		}

		[IndexedField]
		private Int32 _referenceOrderID;

		[Required(ErrorMessage="ReferenceOrderID is required")]
		[ColumnInformation(ColumnName = "ReferenceOrderID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ReferenceOrderID
		{
			get{ return _referenceOrderID; }
			set{ _referenceOrderID = value; onPropertyChanged(this, "ReferenceOrderID");}
		}

		[IndexedField]
		private Int32 _referenceOrderLineID;

		[Required(ErrorMessage="ReferenceOrderLineID is required")]
		[ColumnInformation(ColumnName = "ReferenceOrderLineID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ReferenceOrderLineID
		{
			get{ return _referenceOrderLineID; }
			set{ _referenceOrderLineID = value; onPropertyChanged(this, "ReferenceOrderLineID");}
		}

		private DateTime _transactionDate;

		[Required(ErrorMessage="TransactionDate is required")]
		[ColumnInformation(ColumnName = "TransactionDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime TransactionDate
		{
			get{ return _transactionDate; }
			set{ _transactionDate = value; onPropertyChanged(this, "TransactionDate");}
		}

		private String _transactionType;

		[Required(ErrorMessage="TransactionType is required")]
		[StringLength(1, ErrorMessage="TransactionType cannot be longer than 1 characters")]
		[ColumnInformation(ColumnName = "TransactionType", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String TransactionType
		{
			get{ return _transactionType; }
			set{ _transactionType = value; onPropertyChanged(this, "TransactionType");}
		}

		private Int32 _quantity;

		[Required(ErrorMessage="Quantity is required")]
		[ColumnInformation(ColumnName = "Quantity", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 Quantity
		{
			get{ return _quantity; }
			set{ _quantity = value; onPropertyChanged(this, "Quantity");}
		}

		private Decimal _actualCost;

		[Required(ErrorMessage="ActualCost is required")]
		[ColumnInformation(ColumnName = "ActualCost", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal ActualCost
		{
			get{ return _actualCost; }
			set{ _actualCost = value; onPropertyChanged(this, "ActualCost");}
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

		private Example.Entities.Production.Product _productParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.TransactionHistory", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
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
