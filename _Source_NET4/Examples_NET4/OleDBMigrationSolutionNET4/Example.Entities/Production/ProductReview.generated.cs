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
	[TableInformation(TableName = "Production.ProductReview")]
	[Serializable]
	public partial class ProductReview: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _productReviewID;

		[Required(ErrorMessage="ProductReviewID is required")]
		[ColumnInformation(ColumnName = "ProductReviewID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductReviewID
		{
			get{ return _productReviewID; }
			set{ _productReviewID = value; onPropertyChanged(this, "ProductReviewID");}
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
		private String _reviewerName;

		[Required(ErrorMessage="ReviewerName is required")]
		[StringLength(50, ErrorMessage="ReviewerName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "ReviewerName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ReviewerName
		{
			get{ return _reviewerName; }
			set{ _reviewerName = value; onPropertyChanged(this, "ReviewerName");}
		}

		private DateTime _reviewDate;

		[Required(ErrorMessage="ReviewDate is required")]
		[ColumnInformation(ColumnName = "ReviewDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime ReviewDate
		{
			get{ return _reviewDate; }
			set{ _reviewDate = value; onPropertyChanged(this, "ReviewDate");}
		}

		private String _emailAddress;

		[Required(ErrorMessage="EmailAddress is required")]
		[StringLength(50, ErrorMessage="EmailAddress cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "EmailAddress", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String EmailAddress
		{
			get{ return _emailAddress; }
			set{ _emailAddress = value; onPropertyChanged(this, "EmailAddress");}
		}

		private Int32 _rating;

		[Required(ErrorMessage="Rating is required")]
		[ColumnInformation(ColumnName = "Rating", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 Rating
		{
			get{ return _rating; }
			set{ _rating = value; onPropertyChanged(this, "Rating");}
		}

		private String _comments;

		[StringLength(3850, ErrorMessage="Comments cannot be longer than 3850 characters")]
		[ColumnInformation(ColumnName = "Comments", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Comments
		{
			get{ return _comments; }
			set{ _comments = value; onPropertyChanged(this, "Comments");}
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
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.ProductReview", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
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
