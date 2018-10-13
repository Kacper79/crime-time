using System;
    public class AssetMaintainceTaxLaw : Law
    {
        public int percent;


        public int CalculateTaxes(int value)
        {
            return (int)this.percent * value;
        }
    }

