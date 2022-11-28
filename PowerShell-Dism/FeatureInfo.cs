using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShell_Dism
{
    public class FeatureInfo : IComparable<FeatureInfo>
    {
        public string FeatureName { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty ;

        public int CompareTo(FeatureInfo? other)
        {
            if (other == null)
                return -1;

            if (this.FeatureName == other.FeatureName)
                return 0;
            else if (String.Compare(this.FeatureName, other.FeatureName) > 0)
                return 1;
            else
                return -1;
        }
    }
}
