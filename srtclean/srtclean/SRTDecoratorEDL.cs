using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace srtclean
{
    // cleans commercials detected in EDL from the timeline
    class SRTDecoratorEDL : ISRTIterator
    {
        // EDL lines are tab delimited
        public static Char[] charSeparatorEDL = new char[] { '\t' };

        ISRTIterator SRTBase;
        String strEDLFileName;
        ArrayList EDLArray;
        int count;

        public SRTDecoratorEDL(ISRTIterator enumBase, String filename)
        {
            SRTBase = enumBase;
            strEDLFileName = filename;
            EDLArray = getBasicEDL();
        }

        // reads and cleans until a non-empty subtitle or EOF
        public SRTElement Next()
        {
            SRTElement next = null;
            while (hasNext() && (next == null || !next.Valid()))
            {
                next = cleanSRTTime(SRTBase.Next());
            }
            if (next != null && next.Valid())
            {
                next.Count = ++count;
            }
            return next;
        }

        public bool hasNext()
        {
            return SRTBase.hasNext();
        }

        public void Close()
        {
            SRTBase.Close();
        }

        public ArrayList getBasicEDL()
        {
            ArrayList result = new ArrayList();
            if (!File.Exists(strEDLFileName))
            {
                Console.WriteLine("EDL does not exist.");
            }
            else
            {
                using (StreamReader sr = File.OpenText(strEDLFileName))
                {
                    String input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        result.Add(input);
                        Console.WriteLine(input);
                    }
                    Console.WriteLine("The end of the stream has been reached.");
                    sr.Close();
                }
            }
            return result;
        }

        //  removes commercials from timeline
        private SRTElement cleanSRTTime(SRTElement element)
        {
            if (element == null || EDLArray == null || !element.Valid())
            {
            }
            else
            {
                double beginTime, endTime;
                String[] times = element.getTimes();
                beginTime = normalizeTime(SRTElement.getTimeSRT(times[0]));
                endTime = normalizeTime(SRTElement.getTimeSRT(times[1]));
                if (beginTime != endTime)
                {
                    element.setTimes(beginTime, endTime);
                }
                else
                {
                    element = null;
                }
            }
            return element;
        }

        // subtracts all commercial durations before baseTime to calculate normalized time
        // TODO: should cache EDL doubles at some point
        private double normalizeTime(double baseTime)
        {
            //return baseTime;
            double beginSkip, endSkip;
            double newTime = baseTime;
            String[] times;
            foreach (String line in EDLArray)
            {
                times = line.Split(charSeparatorEDL);
                double.TryParse(times[0], out beginSkip);
                double.TryParse(times[1], out endSkip);
                if (beginSkip < baseTime && endSkip < baseTime)
                {
                    newTime = newTime - (endSkip - beginSkip);
                }
                else if (beginSkip < baseTime && endSkip >= baseTime)
                {
                    newTime = newTime - (baseTime - beginSkip);
                }
                else
                {
                    break;
                }
            }
            return newTime;
        }


    }
}
