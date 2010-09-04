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
	[TableInformation(TableName = "Production.Document")]
	[Serializable]
	public partial class Document: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _documentID;

		[Required(ErrorMessage="DocumentID is required")]
		[ColumnInformation(ColumnName = "DocumentID", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 DocumentID
		{
			get{ return _documentID; }
			set{ _documentID = value; onPropertyChanged(this, "DocumentID");}
		}

		private String _title;

		[Required(ErrorMessage="Title is required")]
		[StringLength(50, ErrorMessage="Title cannot be longer than 50 characters")]
		[ColumnInformation(ColumnName = "Title", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Title
		{
			get{ return _title; }
			set{ _title = value; onPropertyChanged(this, "Title");}
		}

		[IndexedField]
		private String _fileName;

		[Required(ErrorMessage="FileName is required")]
		[StringLength(400, ErrorMessage="FileName cannot be longer than 400 characters")]
		[ColumnInformation(ColumnName = "FileName", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String FileName
		{
			get{ return _fileName; }
			set{ _fileName = value; onPropertyChanged(this, "FileName");}
		}

		private String _fileExtension;

		[Required(ErrorMessage="FileExtension is required")]
		[StringLength(8, ErrorMessage="FileExtension cannot be longer than 8 characters")]
		[ColumnInformation(ColumnName = "FileExtension", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String FileExtension
		{
			get{ return _fileExtension; }
			set{ _fileExtension = value; onPropertyChanged(this, "FileExtension");}
		}

		[IndexedField]
		private String _revision;

		[Required(ErrorMessage="Revision is required")]
		[StringLength(5, ErrorMessage="Revision cannot be longer than 5 characters")]
		[ColumnInformation(ColumnName = "Revision", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Revision
		{
			get{ return _revision; }
			set{ _revision = value; onPropertyChanged(this, "Revision");}
		}

		private Int32 _changeNumber;

		[Required(ErrorMessage="ChangeNumber is required")]
		[ColumnInformation(ColumnName = "ChangeNumber", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 ChangeNumber
		{
			get{ return _changeNumber; }
			set{ _changeNumber = value; onPropertyChanged(this, "ChangeNumber");}
		}

		private Byte _status;

		[Required(ErrorMessage="Status is required")]
		[ColumnInformation(ColumnName = "Status", CodeType = typeof(Byte), ColumnType = OleDbType.UnsignedTinyInt, IsPrimaryKey=false)]
		public Byte Status
		{
			get{ return _status; }
			set{ _status = value; onPropertyChanged(this, "Status");}
		}

		private String _documentSummary;

		[ColumnInformation(ColumnName = "DocumentSummary", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String DocumentSummary
		{
			get{ return _documentSummary; }
			set{ _documentSummary = value; onPropertyChanged(this, "DocumentSummary");}
		}

		private Byte[] _documentProperty;

		[ColumnInformation(ColumnName = "Document", CodeType = typeof(Byte[]), ColumnType = OleDbType.Binary, IsPrimaryKey=false)]
		public Byte[] DocumentProperty
		{
			get{ return _documentProperty; }
			set{ _documentProperty = value; onPropertyChanged(this, "DocumentProperty");}
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

		private ObservableCollection<Example.Entities.Production.ProductDocument> _productDocumentCollection = new ObservableCollection<Example.Entities.Production.ProductDocument>();
		[RelationInformation(IsEntityParent=true, ParentTableName = "Production.Document", ChildTableName = "Production.ProductDocument", ParentColumnNames = new[]{ "DocumentID" }, ChildColumnNames =  new[]{ "DocumentID" } , PropertyNames = new[]{ "DocumentID" }, ForeignFieldNames =  new[]{ "_documentID" }, PrivateCollectionFieldName = "_productDocumentCollection" )]
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
