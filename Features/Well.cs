using lasReader.Features.FeatureModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace lasReader.Features
{
    public class Well : IFeature, IWell
    {
        public IList<VersionData> VersionDatas { get; private set; }
        public IList<WellData> WellDatas { get; private set; }
        public IList<ParameterData> ParameterDatas { get; private set; }
        public IList<CurveData> CurveDatas { get; private set; }

        public Well()
        {
            VersionDatas = new List<VersionData>();
            WellDatas = new List<WellData>();
            ParameterDatas = new List<ParameterData>();
            CurveDatas = new List<CurveData>();
        }
        public void Clear()
        {
            VersionDatas.Clear();
            WellDatas.Clear();
            ParameterDatas.Clear();
            CurveDatas.Clear();
        }

        public void AddVersion(string[] data)
        {
            VersionDatas.Add(new VersionData
            {
                Mnemonic = data[0],
                Unit = data[1],
                Data = data[2],
                Description = data[3]
            });
        }

        public void AddWell(string[] data)
        {
            WellDatas.Add(new WellData
            {
                Mnemonic = data[0],
                Unit = data[1],
                Data = data[2],
                Description = data[3]
            });
        }

        public void AddParameter(string[] data)
        {
            ParameterDatas.Add(new ParameterData
            {
                Mnemonic = data[0],
                Unit = data[1],
                Data = data[2],
                Description = data[3]
            });
        }

        public void AddCurve(string[] data)
        {
            CurveDatas.Add(new CurveData
            {
                Mnemonic = data[0],
                Unit = data[1],
                Data = data[2],
                Description = data[3]
            });
        }
        
    }
}