using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace srtclean
{
    // represents one subtitle chunk.  contains a count, a time slice, and arbitrary lines of text
    class SRTElement
    {
        // SRT time format is 12:34:56,789 --> 12:34:56,789
        public static String[] strSeparatorSRT = new string[] { " --> " };
        public static String[] strSeparatorTime = new string[] { ":", "," };

        private ArrayList lines;

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public SRTElement()
        {
            lines = new ArrayList();
        }

        public SRTElement(StreamReader sr)
        {
            lines = new ArrayList();
            Add(sr);
        }

        public SRTElement(int iCount,StreamReader sr)
        {
            lines = new ArrayList();
            count = iCount;
            Add(sr);
        }

        // reads in a subtitle from a SRT file stream
        public void Add(StreamReader sr)
        {
            String input;
            while ((input = sr.ReadLine()) != null)
            {
                lines.Add(input);
                if (input.Length == 0)
                {
                    break;
                }
            }
        }

        internal void Invalidate()
        {
            lines.Clear();
        }

        //consistency checking
        public bool Valid()
        {
            if (lines.Count > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // returns a string array containing the start and end time of the subtitle
        public String[] getTimes()
        {
            String[] result = null;
            if (Valid())
            {
                result = lines[1].ToString().Split(strSeparatorSRT, StringSplitOptions.None);
            }
            return result;
        }

        // rewrites the first line to containe the new start and end time of the subtitle
        public void setTimes(double beginTime, double endTime)
        {
            lines[1] = timeStringSRT(beginTime) + strSeparatorSRT[0] + timeStringSRT(endTime);
        }

        // rewrites the first line to containe the new start and end time of the subtitle
        public void setTimes(String beginTime, String endTime)
        {
            lines[1] = beginTime + strSeparatorSRT[0] + endTime;
        }

        // converts from seconds to SRT time string
        private string timeStringSRT(double time)
        {
            return "" + ((int)time / 3600).ToString("00") + ":"
                + (((int)time / 60) % 60).ToString("00") + ":"
                + ((int)time % 60).ToString("00") + ","
                + (((int)((time % 1 + 0.0005) * 1000)) % 1000).ToString("000");
        }

        // converts from SRT time string to seconds
        public static double getTimeSRT(String times)
        {
            double timeResult = 0;
            int hours, minutes, seconds, millis;
            String[] timePieces = times.ToString().Split(strSeparatorTime, StringSplitOptions.None);
            if (int.TryParse(timePieces[0], out hours) &&
                int.TryParse(timePieces[1], out minutes) &&
                int.TryParse(timePieces[2], out seconds) &&
                int.TryParse(timePieces[3], out millis))
            {
                timeResult = hours * 3600 + minutes * 60 + seconds + (millis * 0.001);
            }
            return timeResult;
        }

        // determines if CurrentSub text are substrings of NextSub text.
        public bool subsetOf(SRTElement superset)
        {
            bool match = true;
            if (superset == null)
            {
                match = false;
            }
            else if (superset.lines.Count < lines.Count || !superset.Valid())
            {
                match = false;
            }
            else
            {
                for (int i = 2; i < lines.Count; i++)
                {
                    if (!(superset.lines[i].ToString().StartsWith(lines[i].ToString())))
                    {
                        match = false;
                        break;
                    }
                }
            }
            return match;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (lines.Count > 1)
            {
                result.AppendLine(count.ToString());
                for (int i = 1; i < lines.Count; i++)
                {
                    result.AppendLine(lines[i].ToString());
                }
            }
            return result.ToString();
        }

    }
}
