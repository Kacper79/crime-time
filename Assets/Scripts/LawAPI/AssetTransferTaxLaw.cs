using System;
using UnityEngine;
public class AssetTransferTaxLaw : Law
{

	public int percent;


    public int CalculateTaxes(Asset asset)
    {
        return (int)this.percent * asset.value;
    }
}
  

