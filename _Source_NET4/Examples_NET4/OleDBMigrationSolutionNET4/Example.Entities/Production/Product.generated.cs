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
	[TableInformation(TableName = "Production.Product")]
	[Serializable]
	public partial class Product: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _productID;

		[Required(ErrorMessage="ProductID is required")]
		[ColumnInformation(ColumnName = "ProductID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 ProductID
		{
			get{ return _productID; }
			set{ _productID = value; onPropertyChanged(this, "ProductID");}
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

		[IndexedField]
		[UniqueFieldValueConstraint]
		private String _productNumber;

		[Required(ErrorMessage="ProductNumber is required")]
		[StringLength(25, ErrorMessage="ProductNumber cannot be longer than 25 characters")]
		[ColumnInformation(ColumnName = "ProductNumber", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ProductNumber
		{
			get{ return _productNumber; }
			set{ _productNumber = value; onPropertyChanged(this, "ProductNumber");}
		}

		private Boolean _makeFlag;

		[Required(ErrorMessage="MakeFlag is required")]
		[ColumnInformation(ColumnName = "MakeFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean MakeFlag
		{
			get{ return _makeFlag; }
			set{ _makeFlag = value; onPropertyChanged(this, "MakeFlag");}
		}

		private Boolean _finishedGoodsFlag;

		[Required(ErrorMessage="FinishedGoodsFlag is required")]
		[ColumnInformation(ColumnName = "FinishedGoodsFlag", CodeType = typeof(Boolean), ColumnType = OleDbType.Boolean, IsPrimaryKey=false)]
		public Boolean FinishedGoodsFlag
		{
			get{ return _finishedGoodsFlag; }
			set{ _finishedGoodsFlag = value; onPropertyChanged(this, "FinishedGoodsFlag");}
		}

		private String _color;

		[StringLength(15, ErrorMessage="Color cannot be longer than 15 characters")]
		[ColumnInformation(ColumnName = "Color", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Color
		{
			get{ return _color; }
			set{ _color = value; onPropertyChanged(this, "Color");}
		}

		private Int16 _safetyStockLevel;

		[Required(ErrorMessage="SafetyStockLevel is required")]
		[ColumnInformation(ColumnName = "SafetyStockLevel", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 SafetyStockLevel
		{
			get{ return _safetyStockLevel; }
			set{ _safetyStockLevel = value; onPropertyChanged(this, "SafetyStockLevel");}
		}

		private Int16 _reorderPoint;

		[Required(ErrorMessage="ReorderPoint is required")]
		[ColumnInformation(ColumnName = "ReorderPoint", CodeType = typeof(Int16), ColumnType = OleDbType.SmallInt, IsPrimaryKey=false)]
		public Int16 ReorderPoint
		{
			get{ return _reorderPoint; }
			set{ _reorderPoint = value; onPropertyChanged(this, "ReorderPoint");}
		}

		private Decimal _standardCost;

		[Required(ErrorMessage="StandardCost is required")]
		[ColumnInformation(ColumnName = "StandardCost", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal StandardCost
		{
			get{ return _standardCost; }
			set{ _standardCost = value; onPropertyChanged(this, "StandardCost");}
		}

		private Decimal _listPrice;

		[Required(ErrorMessage="ListPrice is required")]
		[ColumnInformation(ColumnName = "ListPrice", CodeType = typeof(Decimal), ColumnType = OleDbType.Currency, IsPrimaryKey=false)]
		public Decimal ListPrice
		{
			get{ return _listPrice; }
			set{ _listPrice = value; onPropertyChanged(this, "ListPrice");}
		}

		private String _size;

		[StringLength(5, ErrorMessage="Size cannot be longer than 5 characters")]
		[ColumnInformation(ColumnName = "Size", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Size
		{
			get{ return _size; }
			set{ _size = value; onPropertyChanged(this, "Size");}
		}

		[IndexedField]
		private String _sizeUnitMeasureCode;

		[StringLength(3, ErrorMessage="SizeUnitMeasureCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "SizeUnitMeasureCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String SizeUnitMeasureCode
		{
			get{ return _sizeUnitMeasureCode; }
			set{ _sizeUnitMeasureCode = value; onPropertyChanged(this, "SizeUnitMeasureCode");}
		}

		[IndexedField]
		private String _weightUnitMeasureCode;

		[StringLength(3, ErrorMessage="WeightUnitMeasureCode cannot be longer than 3 characters")]
		[ColumnInformation(ColumnName = "WeightUnitMeasureCode", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String WeightUnitMeasureCode
		{
			get{ return _weightUnitMeasureCode; }
			set{ _weightUnitMeasureCode = value; onPropertyChanged(this, "WeightUnitMeasureCode");}
		}

		private Decimal? _weight;

		[ColumnInformation(ColumnName = "Weight", CodeType = typeof(Decimal), ColumnType = OleDbType.Numeric, IsPrimaryKey=false)]
		public Decimal? Weight
		{
			get{ return _weight; }
			set{ _weight = value; onPropertyChanged(this, "Weight");}
		}

		private Int32 _daysToManufacture;

		[Required(ErrorMessage="DaysToManufacture is required")]
		[ColumnInformation(ColumnName = "DaysToManufacture", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 DaysToManufacture
		{
			get{ return _daysToManufacture; }
			set{ _daysToManufacture = value; onPropertyChanged(this, "DaysToManufacture");}
		}

		private String _productLine;

		[StringLength(2, ErrorMessage="ProductLine cannot be longer than 2 characters")]
		[ColumnInformation(ColumnName = "ProductLine", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String ProductLine
		{
			get{ return _productLine; }
			set{ _productLine = value; onPropertyChanged(this, "ProductLine");}
		}

		private String _class;

		[StringLength(2, ErrorMessage="Class cannot be longer than 2 characters")]
		[ColumnInformation(ColumnName = "Class", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Class
		{
			get{ return _class; }
			set{ _class = value; onPropertyChanged(this, "Class");}
		}

		private String _style;

		[StringLength(2, ErrorMessage="Style cannot be longer than 2 characters")]
		[ColumnInformation(ColumnName = "Style", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Style
		{
			get{ return _style; }
			set{ _style = value; onPropertyChanged(this, "Style");}
		}

		[IndexedField]
		private Int32? _productSubcategoryID;

		[ColumnInformation(ColumnName = "ProductSubcategoryID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ProductSubcategoryID
		{
			get{ return _productSubcategoryID; }
			set{ _productSubcategoryID = value; onPropertyChanged(this, "ProductSubcategoryID");}
		}

		[IndexedField]
		private Int32? _productModelID;

		[ColumnInformation(ColumnName = "ProductModelID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? ProductModelID
		{
			get{ return _productModelID; }
			set{ _productModelID = value; onPropertyChanged(this, "ProductModelID");}
		}

		private DateTime _sellStartDate;

		[Required(ErrorMessage="SellStartDate is required")]
		[ColumnInformation(ColumnName = "SellStartDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime SellStartDate
		{
			get{ return _sellStartDate; }
			set{ _sellStartDate = value; onPropertyChanged(this, "SellStartDate");}
		}

		private DateTime? _sellEndDate;

		[ColumnInformation(ColumnName = "SellEndDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? SellEndDate
		{
			get{ return _sellEndDate; }
			set{ _sellEndDate = value; onPropertyChanged(this, "SellEndDate");}
		}

		private DateTime? _discontinuedDate;

		[ColumnInformation(ColumnName = "DiscontinuedDate", CodeType = typeof(DateTime), ColumnType = OleDbType.DBTimeStamp, IsPrimaryKey=false)]
		public DateTime? DiscontinuedDate
		{
			get{ return _discontinuedDate; }
			set{ _discontinuedDate = value; onPropertyChanged(this, "DiscontinuedDate");}
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

		#region CHILD PROPERTIES

		private ObservableCollection<Example.Entities.Production.BillOfMaterials> _billOfMaterialsCollection = new ObservableCollection<Example.Entities.Production.BillOfMaterials>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.BillOfMaterials", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductAssemblyID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productAssemblyID" }, PrivateCollectionFieldName = "_billOfMaterialsCollection" )]
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

		private ObservableCollection<Example.Entities.Production.BillOfMaterials> _billOfMaterialsCollection2 = new ObservableCollection<Example.Entities.Production.BillOfMaterials>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.BillOfMaterials", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ComponentID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_componentID" }, PrivateCollectionFieldName = "_billOfMaterialsCollection2" )]
		public ObservableCollection<Example.Entities.Production.BillOfMaterials> BillOfMaterialsCollection2
		{
			get{ return _billOfMaterialsCollection2; }
			private set
			{
				if (BillOfMaterialsCollection2 == value)
					return;
				_billOfMaterialsCollection2 = value;
				onPropertyChanged(this, "BillOfMaterialsCollection2");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductCostHistory> _productCostHistoryCollection = new ObservableCollection<Example.Entities.Production.ProductCostHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.ProductCostHistory", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productCostHistoryCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductCostHistory> ProductCostHistoryCollection
		{
			get{ return _productCostHistoryCollection; }
			private set
			{
				if (ProductCostHistoryCollection == value)
					return;
				_productCostHistoryCollection = value;
				onPropertyChanged(this, "ProductCostHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductDocument> _productDocumentCollection = new ObservableCollection<Example.Entities.Production.ProductDocument>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.ProductDocument", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productDocumentCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductDocument> ProductDocumentCollection
		{
			get{ return _productDocumentCollection; }
			private set
			{
				if (ProductDocumentCollection == value)
					return;
				_productDocumentCollection = value;
				onPropertyChanged(this, "ProductDocumentCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductInventory> _productInventoryCollection = new ObservableCollection<Example.Entities.Production.ProductInventory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.ProductInventory", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productInventoryCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductInventory> ProductInventoryCollection
		{
			get{ return _productInventoryCollection; }
			private set
			{
				if (ProductInventoryCollection == value)
					return;
				_productInventoryCollection = value;
				onPropertyChanged(this, "ProductInventoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductListPriceHistory> _productListPriceHistoryCollection = new ObservableCollection<Example.Entities.Production.ProductListPriceHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.ProductListPriceHistory", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productListPriceHistoryCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductListPriceHistory> ProductListPriceHistoryCollection
		{
			get{ return _productListPriceHistoryCollection; }
			private set
			{
				if (ProductListPriceHistoryCollection == value)
					return;
				_productListPriceHistoryCollection = value;
				onPropertyChanged(this, "ProductListPriceHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.ProductProductPhoto> _productProductPhotoCollection = new ObservableCollection<Example.Entities.Production.ProductProductPhoto>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.ProductProductPhoto", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productProductPhotoCollection" )]
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

		private ObservableCollection<Example.Entities.Production.ProductReview> _productReviewCollection = new ObservableCollection<Example.Entities.Production.ProductReview>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.ProductReview", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productReviewCollection" )]
		public ObservableCollection<Example.Entities.Production.ProductReview> ProductReviewCollection
		{
			get{ return _productReviewCollection; }
			private set
			{
				if (ProductReviewCollection == value)
					return;
				_productReviewCollection = value;
				onPropertyChanged(this, "ProductReviewCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.TransactionHistory> _transactionHistoryCollection = new ObservableCollection<Example.Entities.Production.TransactionHistory>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.TransactionHistory", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_transactionHistoryCollection" )]
		public ObservableCollection<Example.Entities.Production.TransactionHistory> TransactionHistoryCollection
		{
			get{ return _transactionHistoryCollection; }
			private set
			{
				if (TransactionHistoryCollection == value)
					return;
				_transactionHistoryCollection = value;
				onPropertyChanged(this, "TransactionHistoryCollection");
			}
		}

		private ObservableCollection<Example.Entities.Production.WorkOrder> _workOrderCollection = new ObservableCollection<Example.Entities.Production.WorkOrder>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Production.WorkOrder", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_workOrderCollection" )]
		public ObservableCollection<Example.Entities.Production.WorkOrder> WorkOrderCollection
		{
			get{ return _workOrderCollection; }
			private set
			{
				if (WorkOrderCollection == value)
					return;
				_workOrderCollection = value;
				onPropertyChanged(this, "WorkOrderCollection");
			}
		}

		private ObservableCollection<Example.Entities.Purchasing.ProductVendor> _productVendorCollection = new ObservableCollection<Example.Entities.Purchasing.ProductVendor>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Purchasing.ProductVendor", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_productVendorCollection" )]
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

		private ObservableCollection<Example.Entities.Purchasing.PurchaseOrderDetail> _purchaseOrderDetailCollection = new ObservableCollection<Example.Entities.Purchasing.PurchaseOrderDetail>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Purchasing.PurchaseOrderDetail", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_purchaseOrderDetailCollection" )]
		public ObservableCollection<Example.Entities.Purchasing.PurchaseOrderDetail> PurchaseOrderDetailCollection
		{
			get{ return _purchaseOrderDetailCollection; }
			private set
			{
				if (PurchaseOrderDetailCollection == value)
					return;
				_purchaseOrderDetailCollection = value;
				onPropertyChanged(this, "PurchaseOrderDetailCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.ShoppingCartItem> _shoppingCartItemCollection = new ObservableCollection<Example.Entities.Sales.ShoppingCartItem>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Sales.ShoppingCartItem", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_shoppingCartItemCollection" )]
		public ObservableCollection<Example.Entities.Sales.ShoppingCartItem> ShoppingCartItemCollection
		{
			get{ return _shoppingCartItemCollection; }
			private set
			{
				if (ShoppingCartItemCollection == value)
					return;
				_shoppingCartItemCollection = value;
				onPropertyChanged(this, "ShoppingCartItemCollection");
			}
		}

		private ObservableCollection<Example.Entities.Sales.SpecialOfferProduct> _specialOfferProductCollection = new ObservableCollection<Example.Entities.Sales.SpecialOfferProduct>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Product", ChildTableName = "Sales.SpecialOfferProduct", ParentColumnNames = new[]{ "ProductID" }, ChildColumnNames =  new[]{ "ProductID" } , PropertyNames = new[]{ "ProductID" }, ForeignFieldNames =  new[]{ "_productID" }, PrivateCollectionFieldName = "_specialOfferProductCollection" )]
		public ObservableCollection<Example.Entities.Sales.SpecialOfferProduct> SpecialOfferProductCollection
		{
			get{ return _specialOfferProductCollection; }
			private set
			{
				if (SpecialOfferProductCollection == value)
					return;
				_specialOfferProductCollection = value;
				onPropertyChanged(this, "SpecialOfferProductCollection");
			}
		}

		#endregion CHILD PROPERTIES

		#region PARENT PROPERTIES

		private Example.Entities.Production.ProductModel _productModelParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ProductModel", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "ProductModelID" }, ChildColumnNames =  new[]{ "ProductModelID" } , PropertyNames = new[]{ "ProductModelID" }, ForeignFieldNames =  new[]{ "_productModelID" } )]
		public Example.Entities.Production.ProductModel ProductModelParent
		{
			get{ return _productModelParent; }
			set{ _productModelParent = value; onPropertyChanged(this, "ProductModelParent"); }
		}

		private Example.Entities.Production.ProductSubcategory _productSubcategoryParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.ProductSubcategory", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "ProductSubcategoryID" }, ChildColumnNames =  new[]{ "ProductSubcategoryID" } , PropertyNames = new[]{ "ProductSubcategoryID" }, ForeignFieldNames =  new[]{ "_productSubcategoryID" } )]
		public Example.Entities.Production.ProductSubcategory ProductSubcategoryParent
		{
			get{ return _productSubcategoryParent; }
			set{ _productSubcategoryParent = value; onPropertyChanged(this, "ProductSubcategoryParent"); }
		}

		private Example.Entities.Production.UnitMeasure _unitMeasureParent;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.UnitMeasure", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "SizeUnitMeasureCode" } , PropertyNames = new[]{ "SizeUnitMeasureCode" }, ForeignFieldNames =  new[]{ "_unitMeasureCode" } )]
		public Example.Entities.Production.UnitMeasure UnitMeasureParent
		{
			get{ return _unitMeasureParent; }
			set{ _unitMeasureParent = value; onPropertyChanged(this, "UnitMeasureParent"); }
		}

		private Example.Entities.Production.UnitMeasure _unitMeasureParent2;
		[RelationInformation(IsEntityParent=false, ParentTableName = "Production.UnitMeasure", ChildTableName = "Production.Product", ParentColumnNames = new[]{ "UnitMeasureCode" }, ChildColumnNames =  new[]{ "WeightUnitMeasureCode" } , PropertyNames = new[]{ "WeightUnitMeasureCode" }, ForeignFieldNames =  new[]{ "_unitMeasureCode" } )]
		public Example.Entities.Production.UnitMeasure UnitMeasureParent2
		{
			get{ return _unitMeasureParent2; }
			set{ _unitMeasureParent2 = value; onPropertyChanged(this, "UnitMeasureParent2"); }
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
