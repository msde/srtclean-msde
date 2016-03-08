using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace srtclean
{
    // Enhances an SRTEnumerator by joining progressive subtitles together
    // requires caching of one subtitle for joining
    class SRTDecoratorDupe : ISRTIterator
    {
        ISRTIterator SRTBase;
        SRTElement SRTcache;
        int count = 0;

        public SRTDecoratorDupe(ISRTIterator enumBase)
        {
            SRTBase = enumBase;
            SRTcache = SRTBase.Next();
        }

        // attempts to join progressive subtitles together until EOF or new subtitle is detected
        public SRTElement Next()
        {
            SRTElement result;
            if (SRTBase.hasNext())
            {
                SRTElement next = SRTcache;
                SRTcache = null;
                while (SRTcache == null && SRTBase.hasNext())
                {
                    SRTcache = next;
                    next = SRTBase.Next();
                    joinSRT(SRTcache, next);
                }
                result = SRTcache;
                SRTcache = next;
                next = null;
            }
            else
            {
                result = SRTcache;
                SRTcache = null;
            }
            if (result != null && result.Valid())
            {
                result.Count = ++count;
            }
            return result;
        }

        public bool hasNext()
        {
            return SRTBase.hasNext() || (SRTcache != null);
        }

        public void Close()
        {
            SRTBase.Close();
        }

        // merges the timeline of two SRTs
        public static void joinSRT(SRTElement CurrentSub, SRTElement NextSub)
        {
            if (CurrentSub != null && NextSub != null && CurrentSub.subsetOf(NextSub))
            {
                try
                {
                    String[] curTimes = CurrentSub.getTimes();
                    String[] nextTimes = NextSub.getTimes();

                    NextSub.setTimes(curTimes[0], nextTimes[1]);
                    CurrentSub.Invalidate();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error parsing timeline:");
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
