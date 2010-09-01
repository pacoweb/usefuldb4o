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
	[TableInformation(TableName = "Sales.ShoppingCartItem")]
	[Serializable]
	public partial class ShoppingCartItem: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _shoppingCartItemID;

		[Required(ErrorMessage="ShoppingCartItemID is required")]
		[ColumnInformation(ColumnName = "ShoppingCartItemID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ShoppingCartItemID
		{
			get{ return _shoppingCartItemID; }
			set{ _shoppingCartItemID = value; onPropertyChanged(this, "ShoppingCartItemID");}
		}

		[IndexedField]
		private String _shoppingCartID;

		[Required(ErrorMessage="ShoppingCartID is required")]
		[StringLength(50, ErrorMessage="ShoppingCartID cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "ShoppingCartID", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ShoppingCartID
		{
			get{ return _shoppingCartID; }
			set{ _shoppingCartID = value; onPropertyChanged(this, "ShoppingCartID");}
		}

		private Int32 _quantity;

		[Required(ErrorMessage="Quantity is required")]
		[ColumnInformation(ColumnName = "Quantity", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 Quantity
		{
			get{ return _quantity; }
			set{ _quantity = value; onPropertyChanged(this, "Quantity");}
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

		private DateTime _dateCreated;

		[Required(ErrorMessage="DateCreated is required")]
		[ColumnInformation(ColumnName = "DateCreated", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime DateCreated
		{
			get{ return _dateCreated; }
			set{ _dateCreated = value; onPropertyChanged(this, "DateCreated");}
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
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Sales.ShoppingCartItem", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
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
