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
	[TableInformation(TableName = "Production.ProductModelIllustration")]
	[Serializable]
	public partial class ProductModelIllustration: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _productModelID;

		[Required(ErrorMessage="ProductModelID is required")]
		[ColumnInformation(ColumnName = "ProductModelID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductModelID
		{
			get{ return _productModelID; }
			set{ _productModelID = value; onPropertyChanged(this, "ProductModelID");}
		}

		[IndexedField]
		private Int32 _illustrationID;

		[Required(ErrorMessage="IllustrationID is required")]
		[ColumnInformation(ColumnName = "IllustrationID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 IllustrationID
		{
			get{ return _illustrationID; }
			set{ _illustrationID = value; onPropertyChanged(this, "IllustrationID");}
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

		private Example.Entities.Production.Illustration _illustrationParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Illustration", ChildTableName = "Production.ProductModelIllustration", ParentColumnNames = new[]{ "IllustrationID" }, ChildColumnNames =  new[]{ "IllustrationID" } , PropertyNames = new[]{ "IllustrationID" }, ForeignFieldNames =  new[]{ "_illustrationID" } )]
		public Example.Entities.Production.Illustration IllustrationParent
		{
			get{ return _illustrationParent; }
			set{ _illustrationParent = value; onPropertyChanged(this, "IllustrationParent"); }
		}

		private Example.Entities.Production.ProductModel _productModelParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ProductModel", ChildTableName = "Production.ProductModelIllustration", ParentColumnNames = new[]{ "ProductModelID" }, ChildColumnNames =  new[]{ "ProductModelID" } , PropertyNames = new[]{ "ProductModelID" }, ForeignFieldNames =  new[]{ "_productModelID" } )]
		public Example.Entities.Production.ProductModel ProductModelParent
		{
			get{ return _productModelParent; }
			set{ _productModelParent = value; onPropertyChanged(this, "ProductModelParent"); }
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
