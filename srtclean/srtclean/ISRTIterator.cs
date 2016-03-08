using System;
using System.Collections.Generic;
namespace srtclean
{
    interface ISRTIterator
    {
        SRTElement Next();
        bool hasNext();
        void Close();
    }
}
