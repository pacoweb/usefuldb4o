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
	[TableInformation(TableName = "Production.ProductPhoto")]
	[Serializable]
	public partial class ProductPhoto: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _productPhotoID;

		[Required(ErrorMessage="ProductPhotoID is required")]
		[ColumnInformation(ColumnName = "ProductPhotoID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductPhotoID
		{
			get{ return _productPhotoID; }
			set{ _productPhotoID = value; onPropertyChanged(this, "ProductPhotoID");}
		}

		private Byte[] _thumbNailPhoto;

		[ColumnInformation(ColumnName = "ThumbNailPhoto", CodeType = typeof(Byte[]), ColumnType = OleDbType.Binary, IsPrimaryKey=false)]
		public Byte[] ThumbNailPhoto
		{
			get{ return _thumbNailPhoto; }
			set{ _thumbNailPhoto = value; onPropertyChanged(this, "ThumbNailPhoto");}
		}

		private String _thumbnailPhotoFileName;

		[StringLength(50, ErrorMessage="ThumbnailPhotoFileName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "ThumbnailPhotoFileName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ThumbnailPhotoFileName
		{
			get{ return _thumbnailPhotoFileName; }
			set{ _thumbnailPhotoFileName = value; onPropertyChanged(this, "ThumbnailPhotoFileName");}
		}

		private Byte[] _largePhoto;

		[ColumnInformation(ColumnName = "LargePhoto", CodeType = typeof(Byte[]), ColumnType = OleDbType.Binary, IsPrimaryKey=false)]
		public Byte[] LargePhoto
		{
			get{ return _largePhoto; }
			set{ _largePhoto = value; onPropertyChanged(this, "LargePhoto");}
		}

		private String _largePhotoFileName;

		[StringLength(50, ErrorMessage="LargePhotoFileName cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "LargePhotoFileName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String LargePhotoFileName
		{
			get{ return _largePhotoFileName; }
			set{ _largePhotoFileName = value; onPropertyChanged(this, "LargePhotoFileName");}
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

		private ObservableCollection<Example.Entities.Production.ProductProductPhoto> _productProductPhotoCollection = new ObservableCollection<Example.Entities.Production.ProductProductPhoto>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.ProductPhoto", ChildTableName = "Production.ProductProductPhoto", ParentColumnNames = new[]{ "ProductPhotoID" }, ChildColumnNames =  new[]{ "ProductPhotoID" } , PropertyNames = new[]{ "ProductPhotoID" }, ForeignFieldNames =  new[]{ "_productPhotoID" }, PrivateCollectionFieldName = "_productProductPhotoCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductProductPhoto> ProductProductPhotoCollection
		{
			get{ return _productProductPhotoCollection; }
			private set
			{
				if (ProductProductPhotoCollection == value)
					return;
				_productProductPhotoCollection = value;
				onPropertyChanged(this, "ProductProductPhotoCollection");
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
