using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lasReader.Features.FeatureModels
{
    public interface IFeatureData
    {
        string Mnemonic { get; set; }
        string Unit { get; set; }
        string Data { get; set; }
        string Description { get; set; }
    }
}
