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
	[TableInformation(TableName = "Sales.SalesTerritoryHistory")]
	[Serializable]
	public partial class SalesTerritoryHistory: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private Int32 _salesPersonID;

		[Required(ErrorMessage="SalesPersonID is required")]
		[ColumnInformation(ColumnName = "SalesPersonID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 SalesPersonID
		{
			get{ return _salesPersonID; }
			set{ _salesPersonID = value; onPropertyChanged(this, "SalesPersonID");}
		}

		[IndexedField]
		private Int32 _territoryID;

		[Required(ErrorMessage="TerritoryID is required")]
		[ColumnInformation(ColumnName = "TerritoryID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 TerritoryID
		{
			get{ return _territoryID; }
			set{ _territoryID = value; onPropertyChanged(this, "TerritoryID");}
		}

		[IndexedField]
		private DateTime _startDate;

		[Required(ErrorMessage="StartDate is required")]
		[ColumnInformation(ColumnName = "StartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=true)]
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

		private Example.Entities.Sales.SalesPerson _salesPersonParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesPerson", ChildTableName = "Sales.SalesTerritoryHistory", ParentColumnNames = new[]{ "SalesPersonID" }, ChildColumnNames =  new[]{ "SalesPersonID" } , PropertyNames = new[]{ "SalesPersonID" }, ForeignFieldNames =  new[]{ "_salesPersonID" } )]
		public Example.Entities.Sales.SalesPerson SalesPersonParent
		{
			get{ return _salesPersonParent; }
			set{ _salesPersonParent = value; onPropertyChanged(this, "SalesPersonParent"); }
		}

		private Example.Entities.Sales.SalesTerritory _salesTerritoryParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Sales.SalesTerritory", ChildTableName = "Sales.SalesTerritoryHistory", ParentColumnNames = new[]{ "TerritoryID" }, ChildColumnNames =  new[]{ "TerritoryID" } , PropertyNames = new[]{ "TerritoryID" }, ForeignFieldNames =  new[]{ "_territoryID" } )]
		public Example.Entities.Sales.SalesTerritory SalesTerritoryParent
		{
			get{ return _salesTerritoryParent; }
			set{ _salesTerritoryParent = value; onPropertyChanged(this, "SalesTerritoryParent"); }
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
