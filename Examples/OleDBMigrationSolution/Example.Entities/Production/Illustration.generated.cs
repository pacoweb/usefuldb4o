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
	[TableInformation(TableName = "Production.Illustration")]
	[Serializable]
	public partial class Illustration: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _illustrationID;

		[Required(ErrorMessage="IllustrationID is required")]
		[ColumnInformation(ColumnName = "IllustrationID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 IllustrationID
		{
			get{ return _illustrationID; }
			set{ _illustrationID = value; onPropertyChanged(this, "IllustrationID");}
		}

		private Object _diagram;

		[ColumnInformation(ColumnName = "Diagram", CodeType = typeof(Object), ColumnType = OleDbType.IUnknown, IsPrimaryKey=false)]
		public Object Diagram
		{
			get{ return _diagram; }
			set{ _diagram = value; onPropertyChanged(this, "Diagram");}
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

		private ObservableCollection<Example.Entities.Production.ProductModelIllustration> _productModelIllustrationCollection = new ObservableCollection<Example.Entities.Production.ProductModelIllustration>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Illustration", ChildTableName = "Production.ProductModelIllustration", ParentColumnNames = new[]{ "IllustrationID" }, ChildColumnNames =  new[]{ "IllustrationID" } , PropertyNames = new[]{ "IllustrationID" }, ForeignFieldNames =  new[]{ "_illustrationID" }, PrivateCollectionFieldName = "_productModelIllustrationCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductModelIllustration> ProductModelIllustrationCollection
		{
			get{ return _productModelIllustrationCollection; }
			private set
			{
				if (ProductModelIllustrationCollection == value)
					return;
				_productModelIllustrationCollection = value;
				onPropertyChanged(this, "ProductModelIllustrationCollection");
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
