﻿
using System;
using UML=TSF.UmlToolingFramework.UML;


namespace TSF.UmlToolingFramework.Wrappers.EA
{
	/// <summary>
	/// Description of UnlimitedNatural.
	/// </summary>
	public class UnlimitedNatural:UML.Classes.Kernel.UnlimitedNatural
	{
		public bool isUnlimited {get;private set;}
		public uint numericValue {get;private set;}
		public UnlimitedNatural(string valueString)
		{
			if (valueString == unlimited)
			{
				this.isUnlimited = true;
			}
			else
			{
				this.numericValue = uint.Parse(valueString);
				this.integerValue = (int)this.numericValue;
				this.isUnlimited = false;
			}
		}
		public const string unlimited = "*";
		public override string ToString()
		{
			if (isUnlimited)
			{
				return unlimited;
			}
			else
			{
				return numericValue.ToString();
			}
		}

	}
}
