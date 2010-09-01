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
	[TableInformation(TableName = "Production.UnitMeasure")]
	[Serializable]
	public partial class UnitMeasure: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _unitMeasureCode;

		[Required(ErrorMessage="UnitMeasureCode is required")]
		[StringLength(3, ErrorMessage="UnitMeasureCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "UnitMeasureCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=true)]
		public String UnitMeasureCode
		{
			get{ return _unitMeasureCode; }
			set{ _unitMeasureCode = value; onPropertyChanged(this, "UnitMeasureCode");}
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

		private ObservableCollection<Example.Entities.Production.BillOfMaterials> _billOfMaterialsCollection = new ObservableCollection<Example.Entities.Production.BillOfMaterials>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.UnitMeasure", ChildTableName = "Production.BillOfMaterials", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "UnitMeasureCode" } , PropertyNames = new[]{ "UnitMeasureCode" }, ForeignFieldNames =  new[]{ "_unitMeasureCode" }, PrivateCollectionFieldName = "_billOfMaterialsCollection" )]
		public ObservableCollection<Example.Entities.Production.BillOfMaterials> BillOfMaterialsCollection
		{
			get{ return _billOfMaterialsCollection; }
			private set
			{
				if (BillOfMaterialsCollection == value)
					return;
				_billOfMaterialsCollection = value;
				onPropertyChanged(this, "BillOfMaterialsCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.Product> _productCollection = new ObservableCollection<Example.Entities.Production.Product>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.UnitMeasure", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "SizeUnitMeasureCode" } , PropertyNames = new[]{ "UnitMeasureCode" }, ForeignFieldNames =  new[]{ "_sizeUnitMeasureCode" }, PrivateCollectionFieldName = "_productCollection" )]
		public ObservableCollection<Example.Entities.Production.Product> ProductCollection
		{
			get{ return _productCollection; }
			private set
			{
				if (ProductCollection == value)
					return;
				_productCollection = value;
				onPropertyChanged(this, "ProductCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.Product> _productCollection2 = new ObservableCollection<Example.Entities.Production.Product>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.UnitMeasure", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "WeightUnitMeasureCode" } , PropertyNames = new[]{ "UnitMeasureCode" }, ForeignFieldNames =  new[]{ "_weightUnitMeasureCode" }, PrivateCollectionFieldName = "_productCollection2" )]
		public ObservableCollection<Example.Entities.Production.Product> ProductCollection2
		{
			get{ return _productCollection2; }
			private set
			{
				if (ProductCollection2 == value)
					return;
				_productCollection2 = value;
				onPropertyChanged(this, "ProductCollection2");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.ProductVendor> _productVendorCollection = new ObservableCollection<Example.Entities.Purchasing.ProductVendor>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.UnitMeasure", ChildTableName = "Purchasing.ProductVendor", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "UnitMeasureCode" } , PropertyNames = new[]{ "UnitMeasureCode" }, ForeignFieldNames =  new[]{ "_unitMeasureCode" }, PrivateCollectionFieldName = "_productVendorCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.ProductVendor> ProductVendorCollection
		{
			get{ return _productVendorCollection; }
			private set
			{
				if (ProductVendorCollection == value)
					return;
				_productVendorCollection = value;
				onPropertyChanged(this, "ProductVendorCollection");
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
