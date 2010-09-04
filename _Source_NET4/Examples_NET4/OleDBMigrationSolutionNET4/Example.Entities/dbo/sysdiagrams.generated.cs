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

namespace Example.Entities
{
	[TableInformation(TableName = "dbo.sysdiagrams")]
	[Serializable]
	public partial class Sysdiagrams: INotifyPropertyChanged
	{
	
		#region PROPERTIES

		[IndexedField]
		private String _name;

		[Required(ErrorMessage="Name is required")]
		[StringLength(128, ErrorMessage="Name cannot be longer than 128 characters")]
		[ColumnInformation(ColumnName = "name", CodeType = typeof(String), ColumnType = OleDbType.WChar, IsPrimaryKey=false)]
		public String Name
		{
			get{ return _name; }
			set{ _name = value; onPropertyChanged(this, "Name");}
		}

		[IndexedField]
		private Int32 _principalId;

		[Required(ErrorMessage="PrincipalId is required")]
		[ColumnInformation(ColumnName = "principal_id", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32 PrincipalId
		{
			get{ return _principalId; }
			set{ _principalId = value; onPropertyChanged(this, "PrincipalId");}
		}

		[IndexedField]
		[UniqueFieldValueConstraint]
		private Int32 _diagramId;

		[Required(ErrorMessage="DiagramId is required")]
		[ColumnInformation(ColumnName = "diagram_id", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=true)]
		public Int32 DiagramId
		{
			get{ return _diagramId; }
			set{ _diagramId = value; onPropertyChanged(this, "DiagramId");}
		}

		private Int32? _version;

		[ColumnInformation(ColumnName = "version", CodeType = typeof(Int32), ColumnType = OleDbType.Integer, IsPrimaryKey=false)]
		public Int32? Version
		{
			get{ return _version; }
			set{ _version = value; onPropertyChanged(this, "Version");}
		}

		private Byte[] _definition;

		[ColumnInformation(ColumnName = "definition", CodeType = typeof(Byte[]), ColumnType = OleDbType.Binary, IsPrimaryKey=false)]
		public Byte[] Definition
		{
			get{ return _definition; }
			set{ _definition = value; onPropertyChanged(this, "Definition");}
		}

		#endregion PROPERTIES

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
