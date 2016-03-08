using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace srtclean
{
    // handles basic file I/O and tokenization of subtitles
    class SRTIteratorImpl : ISRTIterator
    {
        String strFilename;
        StreamReader sr;
        int count = 0;

        public SRTIteratorImpl(String filename)
        {
            strFilename = filename;
            Reset();
        }

        public SRTElement Next()
        {
            SRTElement next = null;
            if (hasNext())
            {
                next = new SRTElement(++count,sr);
            }
            return next;
        }

        public void Reset()
        {
            if (!File.Exists(strFilename))
            {
                Console.WriteLine("SRT does not exist.");
            }
            else
            {
                sr = File.OpenText(strFilename);
            }
        }

        public bool hasNext()
        {
            return !((sr == null) || sr.EndOfStream);
        }

        public void Close()
        {
            if (sr != null)
            {
                sr.Close();
            }
        }

    }
}
