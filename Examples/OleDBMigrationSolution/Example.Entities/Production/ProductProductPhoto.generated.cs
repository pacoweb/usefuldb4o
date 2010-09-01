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
	[TableInformation(TableName = "Production.ProductProductPhoto")]
	[Serializable]
	public partial class ProductProductPhoto: INotifyPropertyChanged
	{
	
		#region PROPERTIES

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
		private Int32 _productPhotoID;

		[Required(ErrorMessage="ProductPhotoID is required")]
		[ColumnInformation(ColumnName = "ProductPhotoID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductPhotoID
		{
			get{ return _productPhotoID; }
			set{ _productPhotoID = value; onPropertyChanged(this, "ProductPhotoID");}
		}

		private Boolean _primary;

		[Required(ErrorMessage="Primary is required")]
		[ColumnInformation(ColumnName = "Primary", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean Primary
		{
			get{ return _primary; }
			set{ _primary = value; onPropertyChanged(this, "Primary");}
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
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.ProductProductPhoto", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
		}

		private Example.Entities.Production.ProductPhoto _productPhotoParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ProductPhoto", ChildTableName = "Production.ProductProductPhoto", ParentColumnNames = new[]{ "ProductPhotoID" }, ChildColumnNames =  new[]{ "ProductPhotoID" } , PropertyNames = new[]{ "ProductPhotoID" }, ForeignFieldNames =  new[]{ "_productPhotoID" } )]
		public Example.Entities.Production.ProductPhoto ProductPhotoParent
		{
			get{ return _productPhotoParent; }
			set{ _productPhotoParent = value; onPropertyChanged(this, "ProductPhotoParent"); }
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
