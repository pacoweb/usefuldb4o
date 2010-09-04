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
	[TableInformation(TableName = "Production.Culture")]
	[Serializable]
	public partial class Culture: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _cultureID;

		[Required(ErrorMessage="CultureID is required")]
		[StringLength(6, ErrorMessage="CultureID cannot be longer than 6 characters")]
		[ColumnInformation(ColumnName = "CultureID", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=true)]
		public String CultureID
		{
			get{ return _cultureID; }
			set{ _cultureID = value; onPropertyChanged(this, "CultureID");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _name;

		[Required(ErrorMessage="Name is required")]
		[StringLength(50, ErrorMessage="Name cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Name", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Name
		{
			get{ return _name; }
			set{ _name = value; onPropertyChanged(this, "Name");}
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

		private ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture> _productModelProductDescriptionCultureCollection = new ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Culture", ChildTableName = "Production.ProductModelProductDescriptionCulture", ParentColumnNames = new[]{ "CultureID" }, ChildColumnNames =  new[]{ "CultureID" } , PropertyNames = new[]{ "CultureID" }, ForeignFieldNames =  new[]{ "_cultureID" }, PrivateCollectionFieldName = "_productModelProductDescriptionCultureCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultureCollection
		{
			get{ return _productModelProductDescriptionCultureCollection; }
			private set
			{
				if (ProductModelProductDescriptionCultureCollection == value)
					return;
				_productModelProductDescriptionCultureCollection = value;
				onPropertyChanged(this, "ProductModelProductDescriptionCultureCollection");
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
