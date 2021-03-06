﻿
using System;
using DB=DatabaseFramework;
using TSF.UmlToolingFramework.Wrappers.EA;
namespace EAAddinFramework.Databases
{
	/// <summary>
	/// Description of DataType.
	/// </summary>
	public class DataType:DB.DataType
	{
		public DataType(BaseDataType baseType, int length, int precision)
		{
			this.type = baseType;
			this.length = length;
			this.precision = precision;
		}

		#region DataType implementation

		public DB.BaseDataType type {get;set;}

		public void save()
		{
			throw new NotImplementedException();
		}
		public void delete()
		{
			throw new NotImplementedException();
		}

		public bool isValid 
		{
			get
			{
				//datatype is valid if it has a name
				return (! string.IsNullOrEmpty(this.name));
				
			}
		}
		public void Select()
		{
			//you cannot select a Datatype
		}
		public TSF.UmlToolingFramework.UML.Classes.Kernel.Element logicalElement {
			get 
			{
				// datatypes don't have logical elements
				return null;
			}
		}
		public void createAsNewItem(DB.Database existingDatabase)
		{
			throw new NotImplementedException();
		}
		public void update(DB.DatabaseItem newDatabaseItem, bool save = true)
		{
			//don't think we need it here
			throw new NotImplementedException();
		}
		public DB.DatabaseItem owner {
			get {
				//don't think we need it here
				throw new NotImplementedException();
			}
		}

		public DB.DataBaseFactory factory {
			get {
				//don't think we need that here
				throw new NotImplementedException();
			}
		}

		public string itemType {
			get {return "DataType";}
		}
		public string properties {
			get 
			{
				string _properties = this.type.properties;
				if (this.type.hasLength)
				{
					_properties += " (" + this.length;
					if (this.type.hasPrecision)
					{
						_properties += "," + this.precision;
					}
					_properties += ")";
				}
				return _properties;
			}
		}
		public string name {
			get {return this.type.name;}
			set {throw new NotImplementedException();}
		}
		public int length {get;set;}

		public int precision {get;set;}
		


		#endregion
		//datatype can't be overriden
		public bool isOverridden 
		{
			get 
			{
				return false;
			}
			set {
				//do nothing
			}
		}

	}
}
