﻿
using System;
using EAAddinFramework.Utilities;
using DB=DatabaseFramework;
using TSF.UmlToolingFramework.Wrappers.EA;
namespace EAAddinFramework.Databases
{
	/// <summary>
	/// Description of BaseDataType.
	/// </summary>
	public class BaseDataType:DB.BaseDataType
	{
		public BaseDataType(string name, bool hasLength, bool hasPrecision)
		{
			this.name = name;
			this.hasLength = hasLength;
			this.hasPrecision = hasPrecision;
		}
		public BaseDataType(global::EA.Datatype eaDatatype)
		{
			this.name = eaDatatype.Name;
			this.hasLength = eaDatatype.Size > 0;
			this.hasPrecision = eaDatatype.Size == 2;
		}
		#region BaseDataType implementation
		public void save()
		{
			//do nothing. deleting or adding of base datatypes should happen manually in the EA GUI
		}
		public void delete()
		{
			//do nothing. deleting or adding of base datatypes should happen manually in the EA GUI
		}

		public void Select()
		{
			//you cannot select a Base Datatype
		}
		public TSF.UmlToolingFramework.UML.Classes.Kernel.Element logicalElement {
			get 
			{
				//base datatypes don't have logical elements
				return null;
			}
		}
		public bool isValid {
			get 
			{
				//base data type is valid if it has a name
				return ! string.IsNullOrEmpty(this.name);
			}
		}
		public void createAsNewItem(DB.Database existingDatabase)
		{
			//do nothing. deleting or adding of base datatypes should happen manually in the EA GUI
		}
		public void update(DB.DatabaseItem newDatabaseItem, bool save = true)
		{
			//don't think we ever need this one
			throw new NotImplementedException();
		}
		public DB.DatabaseItem owner {
			get {
				//don't think we ever need this one
				throw new NotImplementedException();
			}
		}
		public DB.DataBaseFactory factory {
			get {
				//TODO:figure out if we need it here
				throw new NotImplementedException();
			}
		}
		public string name {get;set;}

		public bool hasLength {get;set;}

		public bool hasPrecision {get;set;}

		public string itemType 
		{
			get {return "BaseDatatype";}
		}
		


		public string properties 
		{
			get { return this.name;}
		}

		#endregion
		//base datatypes can't be overriden
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
