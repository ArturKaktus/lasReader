using lasReader.Features.FeatureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lasReader.Features
{
    internal interface IWell
    {
        IList<VersionData> VersionDatas { get; }
        IList<WellData> WellDatas { get; }
        IList<ParameterData> ParameterDatas { get; }
        IList<CurveData> CurveDatas { get; }
        void AddVersion(string[] data);
        void AddWell(string[] data);
        void AddParameter(string[] data);
        void AddCurve(string[] data);
    }
}
