using lasReader.Features;
using System;
using System.IO;
using System.Linq;

namespace lasReader.Catalog.Providers
{
    public class LasFileReader
    {
        private readonly StreamReader m_StreamReader;
        public LasFileReader(string laspath)
        {
            Stream fstream = new FileStream(laspath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            m_StreamReader = new StreamReader(fstream);
            ReadData();
        }

        #region Constants

        private const string CLAUSE_VERSION = "VERSION";
        private const string CLAUSE_VERSION_SHORT = "V";
        private const string CLAUSE_WELL = "WELL";
        private const string CLAUSE_WELL_SHORT = "W";
        private const string CLAUSE_CURVE = "CURVE";
        private const string CLAUSE_CURVE_SHORT = "C";
        private const string CLAUSE_PARAMETR = "PARAMETR";
        private const string CLAUSE_PARAMETER = "PARAMETER";
        private const string CLAUSE_PARAMETER_SHORT = "P";
        private const string CLAUSE_OTHER = "OTHER";
        private const string CLAUSE_OTHER_SHORT = "O";
        private const string CLAUSE_ASCII = "ASCII";
        private const string CLAUSE_ASCII_SHORT = "A";

        #endregion

        private void ReadData()
        {
            try
            {
                string clause = string.Empty;

                while (m_StreamReader.Peek() >= 0)
                {
                    var str = m_StreamReader.ReadLine();

                    if (str.StartsWith("~"))
                    {
                        clause = str.Substring(1).Split()[0];
                        str = m_StreamReader.ReadLine();
                    }

                    if (str.StartsWith("#")
                        || clause == CLAUSE_OTHER
                        || clause == CLAUSE_OTHER_SHORT
                        || clause == CLAUSE_ASCII
                        || clause == CLAUSE_ASCII_SHORT) continue;

                    switch (clause.ToUpper())
                    {
                        case CLAUSE_VERSION:
                        case CLAUSE_VERSION_SHORT:
                            var verarr = ReadProps(str);
                            if (Document.Feature is Well vw)
                                vw.AddVersion(verarr);
                            break;

                        case CLAUSE_WELL:
                        case CLAUSE_WELL_SHORT:
                            var wellearr = ReadProps(str);
                            if (Document.Feature is Well ww)
                                ww.AddWell(wellearr);
                            break;

                        case CLAUSE_CURVE:
                        case CLAUSE_CURVE_SHORT:
                            var curvearr = ReadProps(str);
                            if (Document.Feature is Well cw)
                                cw.AddCurve(curvearr);
                            break;

                        case CLAUSE_PARAMETER:
                        case CLAUSE_PARAMETR:
                        case CLAUSE_PARAMETER_SHORT:
                            var paramarr = ReadProps(str);
                            if (Document.Feature is Well pw)
                                pw.AddParameter(paramarr);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string[] ReadProps(string str)
        {
            try
            {
                string[] arrayProps = new string[4];
                int i = 0;

                foreach (char c in str)
                {
                    if ((i == 0 && c != '.')
                        || (i == 1 && c != ' ')
                        || (i == 2 && c != ':')
                        || (i == 3))
                    { 
                        arrayProps[i] += c;
                    }
                    else
                        i++;
                }

                return arrayProps.Select(s => string.IsNullOrWhiteSpace(s) ? string.Empty : s.Trim()).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
