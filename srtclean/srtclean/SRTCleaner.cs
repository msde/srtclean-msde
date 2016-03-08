using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace srtclean
{
    class SRTCleaner
    {
        private String strEDLFileName;

        public String EDLFileName
        {
            get { return strEDLFileName; }
            set { strEDLFileName = value; }
        }
        private String strSRTFileName;

        public String SRTFileName
        {
            get { return strSRTFileName; }
            set { strSRTFileName = value; }
        }

        public SRTCleaner()
        {
        }

        // writes to filename_clean.srt
        // returns string with results
        public String cleanSRT()
        {
            StringBuilder result = new StringBuilder();
            SRTElement NextSub = null;
            ISRTIterator srtenum;
            srtenum = new SRTIteratorImpl(strSRTFileName);
            if (strEDLFileName != null)
            {
                srtenum = new SRTDecoratorEDL(srtenum, strEDLFileName);
            }
            srtenum = new SRTDecoratorDupe(srtenum);
            if (outputFileName() != null)
            {
                StreamWriter sw = new StreamWriter(outputFileName());
                while (srtenum.hasNext())
                {
                    NextSub = srtenum.Next();
                    if (NextSub != null && NextSub.Valid())
                    {
                        sw.Write(NextSub.ToString());
                        result.Append(NextSub.ToString());
                    }
                }
                Console.WriteLine("The end of the stream has been reached.");
                sw.Close();
            }
            srtenum.Close();
            return result.ToString();
        }

        // appends _clean to the filename to generate output filename.  assumes .srt extension
        private String outputFileName()
        {
            if (strSRTFileName != null)
            {
                return strSRTFileName.Substring(0, strSRTFileName.Length - 4) + "_clean.srt";
            }
            return null;
        }
    }
}
