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
	[TableInformation(TableName = "Sales.SalesTaxRate")]
	[Serializable]
	public partial class SalesTaxRate: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _salesTaxRateID;

		[Required(ErrorMessage="SalesTaxRateID is required")]
		[ColumnInformation(ColumnName = "SalesTaxRateID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesTaxRateID
		{
			get{ return _salesTaxRateID; }
			set{ _salesTaxRateID = value; onPropertyChanged(this, "SalesTaxRateID");}
		}

		[IndexedField]
		private Int32 _stateProvinceID;

		[Required(ErrorMessage="StateProvinceID is required")]
		[ColumnInformation(ColumnName = "StateProvinceID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 StateProvinceID
		{
			get{ return _stateProvinceID; }
			set{ _stateProvinceID = value; onPropertyChanged(this, "StateProvinceID");}
		}

		[IndexedField]
		private Byte _taxType;

		[Required(ErrorMessage="TaxType is required")]
		[ColumnInformation(ColumnName = "TaxType", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte TaxType
		{
			get{ return _taxType; }
			set{ _taxType = value; onPropertyChanged(this, "TaxType");}
		}

		private Decimal _taxRate;

		[Required(ErrorMessage="TaxRate is required")]
		[ColumnInformation(ColumnName = "TaxRate", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal TaxRate
		{
			get{ return _taxRate; }
			set{ _taxRate = value; onPropertyChanged(this, "TaxRate");}
		}

		private String _name;

		[Required(ErrorMessage="Name is required")]
		[StringLength(50, ErrorMessage="Name cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Name", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Name
		{
			get{ return _name; }
			set{ _name = value; onPropertyChanged(this, "Name");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Guid _rowguid;

		[Required(ErrorMessage="Rowguid is required")]
		[ColumnInformation(ColumnName = "rowguid", CodeType = typeof(Guid), ColumnType = OleDbType.Guid, IsPrimaryKey=false)]
		public Guid Rowguid
		{
			get{ return _rowguid; }
			set{ _rowguid = value; onPropertyChanged(this, "Rowguid");}
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

		private Example.Entities.Person.StateProvince _stateProvinceParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Person.StateProvince", ChildTableName = "Sales.SalesTaxRate", ParentColumnNames = new[]{ "StateProvinceID" }, ChildColumnNames =  new[]{ "StateProvinceID" } , PropertyNames = new[]{ "StateProvinceID" }, ForeignFieldNames =  new[]{ "_stateProvinceID" } )]
		public Example.Entities.Person.StateProvince StateProvinceParent
		{
			get{ return _stateProvinceParent; }
			set{ _stateProvinceParent = value; onPropertyChanged(this, "StateProvinceParent"); }
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
