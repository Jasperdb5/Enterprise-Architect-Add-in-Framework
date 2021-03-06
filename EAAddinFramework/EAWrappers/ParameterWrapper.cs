﻿using System;
using System.Collections.Generic;

using UML=TSF.UmlToolingFramework.UML;

namespace TSF.UmlToolingFramework.Wrappers.EA {
  public class ParameterWrapper : Parameter {
    internal global::EA.Parameter wrappedParameter { get; set; }
    
    public ParameterWrapper(Model model, global::EA.Parameter parameter)
      : base(model) 
    {
      this.wrappedParameter = parameter;
    }
	/// <summary>
    /// return the unique ID of this element
    /// </summary>
	public override string uniqueID 
	{
		get 
		{
			return this.wrappedParameter.ParameterGUID;
		}
	}
	public override void save()
	{
		this.saveElement();
	}
    public override HashSet<UML.Classes.Kernel.Element> ownedElements {
      get { return new HashSet<UML.Classes.Kernel.Element>(); }
      set { /* do nothing */ }
    }
    
    
    public override UML.Classes.Kernel.Element owner {
    	get { return this.model.getOperationByID(this.wrappedParameter.OperationID); }
      	set { throw new NotImplementedException(); }
    }
    
    public override HashSet<UML.Profiles.Stereotype> stereotypes {
      get {
        return ((Factory)this.model.factory).createStereotypes
          ( this, this.wrappedParameter.StereotypeEx );
      }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.ParameterDirectionKind direction {
      get {
        return ParameterDirectionKind.getUMLParameterDirectionkind
          ( this.wrappedParameter.Kind );
      }
      set { throw new NotImplementedException(); }
    }
    
    public override String _default {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.ValueSpecification defaultValue {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
        
    public override bool isOrdered {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override bool isUnique {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.UnlimitedNatural upper {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override uint lower {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.ValueSpecification upperValue {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.ValueSpecification lowerValue {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.Type type {
      get {
        // for some strange reason the classifierid of the parameter is a 
        // string, where all other id the the EA API are integers.
        int ClassifierID;
        UML.Classes.Kernel.Type type = null;
        if (int.TryParse(this.wrappedParameter.ClassifierID,out ClassifierID))
        {
           	type = this.model.getElementWrapperByID(ClassifierID) as UML.Classes.Kernel.Type;
        }
        // check if the type is defined as an element in the model.
        if( type == null ) {
          // no element, create primitive type based on the name of the type
          type = this.model.factory.createPrimitiveType
            ( this.wrappedParameter.Type );
        }
        return type;
      }
      set 
      {
      	//check if the value is an element wrapper
      	var elementWrapperValue = value as ElementWrapper;
      	if (elementWrapperValue != null)
      	{
      		this.wrappedParameter.ClassifierID = elementWrapperValue.id.ToString();
      	}
		//set the name anyway
		this.wrappedParameter.Type = value.name;
	  }
    }
    
    public override string name {
      get { return this.wrappedParameter.Name; }
      set { throw new NotImplementedException(); }
    }

    public override UML.Classes.Kernel.VisibilityKind visibility {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override String qualifiedName {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    public override UML.Classes.Kernel.Namespace owningNamespace {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
    
    /// saves the parameter to the case tool.
    internal override void saveElement(){
      this.wrappedParameter.Update();
    }
    
    public override String notes {
      get { return this.wrappedParameter.Notes;  }
      set { this.wrappedParameter.Notes = value; }
    }
    internal string ID {
    	get{return this.wrappedParameter.ParameterGUID;}
    	set{this.wrappedParameter.ParameterGUID = value;}
    }
  	
	public override TSF.UmlToolingFramework.UML.Extended.UMLItem getItemFromRelativePath(List<string> relativePath)
	{
		return null;
	}
	public override HashSet<UML.Profiles.TaggedValue> taggedValues
	{
		get 
		{
			//make sure we have an up-to date collection
			this.wrappedParameter.TaggedValues.Refresh();			
			return new HashSet<UML.Profiles.TaggedValue>(this.model.factory.createTaggedValues(this.wrappedParameter.TaggedValues));
		}
		set { throw new NotImplementedException();}
	}
	public override HashSet<TSF.UmlToolingFramework.UML.Profiles.TaggedValue> getReferencingTaggedValues()
	{
		return this.model.getTaggedValuesWithValue(this.wrappedParameter.ParameterGUID);
	}
  	
	internal override global::EA.Collection eaTaggedValuesCollection {
		get {
			return this.wrappedParameter.TaggedValues;
		}
	}
  	
	public override string guid 
	{
		get 
		{
			return this.wrappedParameter.ParameterGUID;
		}
	}

		#region implemented abstract members of Element

	public override void deleteOwnedElement(Element ownedElement)
	{
		throw new NotImplementedException();
	}

	#endregion
  }
}
