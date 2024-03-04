using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lasReader.Features.FeatureModels
{
    public class BaseData : IFeatureData
    {
        public string Mnemonic { get; set; }
        public string Unit { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return $"{Mnemonic} - {Unit} - {Data} - {Description}";
        }
    }
}
