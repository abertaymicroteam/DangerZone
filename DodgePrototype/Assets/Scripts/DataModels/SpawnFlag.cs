using System.Collections;
using System.Collections.Generic;
using System;
using Unity3dAzure.AppServices;

public class SpawnFlag : DataModel 
{
	//public string id { get; set; } // id property is provided when subclassing the DataModel

	public string name { get; set; }

	public bool flag { get; set; }

	public override string ToString()
	{
		return string.Format("name: {0} flag: {1} system properties: {2}", name, flag, base.ToString() );
	}
}
