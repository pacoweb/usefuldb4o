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
	[TableInformation(TableName = "Production.BillOfMaterials")]
	[Serializable]
	public partial class BillOfMaterials: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _billOfMaterialsID;

		[Required(ErrorMessage="BillOfMaterialsID is required")]
		[ColumnInformation(ColumnName = "BillOfMaterialsID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 BillOfMaterialsID
		{
			get{ return _billOfMaterialsID; }
			set{ _billOfMaterialsID = value; onPropertyChanged(this, "BillOfMaterialsID");}
		}

		[IndexedField]
		private Int32? _productAssemblyID;

		[ColumnInformation(ColumnName = "ProductAssemblyID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ProductAssemblyID
		{
			get{ return _productAssemblyID; }
			set{ _productAssemblyID = value; onPropertyChanged(this, "ProductAssemblyID");}
		}

		[IndexedField]
		private Int32 _componentID;

		[Required(ErrorMessage="ComponentID is required")]
		[ColumnInformation(ColumnName = "ComponentID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ComponentID
		{
			get{ return _componentID; }
			set{ _componentID = value; onPropertyChanged(this, "ComponentID");}
		}

		[IndexedField]
		private DateTime _startDate;

		[Required(ErrorMessage="StartDate is required")]
		[ColumnInformation(ColumnName = "StartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime StartDate
		{
			get{ return _startDate; }
			set{ _startDate = value; onPropertyChanged(this, "StartDate");}
		}

		private DateTime? _endDate;

		[ColumnInformation(ColumnName = "EndDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? EndDate
		{
			get{ return _endDate; }
			set{ _endDate = value; onPropertyChanged(this, "EndDate");}
		}

		[IndexedField]
		private String _unitMeasureCode;

		[Required(ErrorMessage="UnitMeasureCode is required")]
		[StringLength(3, ErrorMessage="UnitMeasureCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "UnitMeasureCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String UnitMeasureCode
		{
			get{ return _unitMeasureCode; }
			set{ _unitMeasureCode = value; onPropertyChanged(this, "UnitMeasureCode");}
		}

		private Int16 _bOMLevel;

		[Required(ErrorMessage="BOMLevel is required")]
		[ColumnInformation(ColumnName = "BOMLevel", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 BOMLevel
		{
			get{ return _bOMLevel; }
			set{ _bOMLevel = value; onPropertyChanged(this, "BOMLevel");}
		}

		private Decimal _perAssemblyQty;

		[Required(ErrorMessage="PerAssemblyQty is required")]
		[ColumnInformation(ColumnName = "PerAssemblyQty", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal PerAssemblyQty
		{
			get{ return _perAssemblyQty; }
			set{ _perAssemblyQty = value; onPropertyChanged(this, "PerAssemblyQty");}
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
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.BillOfMaterials", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductAssemblyID" } , PropertyNames = new[]{ "ProductAssemblyID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent
		{
			get{ return _productParent; }
			set{ _productParent = value; onPropertyChanged(this, "ProductParent"); }
		}

		private Example.Entities.Production.Product _productParent2;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.Product", ChildTableName = "Production.BillOfMaterials", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ComponentID" } , PropertyNames = new[]{ "ComponentID" }, ForeignFieldNames =  new[]{ "_productID" } )]
		public Example.Entities.Production.Product ProductParent2
		{
			get{ return _productParent2; }
			set{ _productParent2 = value; onPropertyChanged(this, "ProductParent2"); }
		}

		private Example.Entities.Production.UnitMeasure _unitMeasureParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.UnitMeasure", ChildTableName = "Production.BillOfMaterials", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "UnitMeasureCode" } , PropertyNames = new[]{ "UnitMeasureCode" }, ForeignFieldNames =  new[]{ "_unitMeasureCode" } )]
		public Example.Entities.Production.UnitMeasure UnitMeasureParent
		{
			get{ return _unitMeasureParent; }
			set{ _unitMeasureParent = value; onPropertyChanged(this, "UnitMeasureParent"); }
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
