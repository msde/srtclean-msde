using System;
using System.Collections.Generic;
using System.Text;

namespace srtclean
{
    using NUnit.Framework;
    using System.IO;

    [TestFixture]
    public class TestSRTClean
    {
        //
        // Summary:
        //     Loads test result from file for string comparison
        //
        // Returns:
        //     A string whose value is the contents of the specified file
        public String LoadResult(String strFileName)
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader sr = File.OpenText(strFileName))
            {
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    result.AppendLine(input);
                }
            }
            return result.ToString();
        }

        [Test]
        public void NewTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            Assert.IsNotNull(cleaner);
        }

        [Test]
        public void NullTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            Assert.AreEqual("", cleaner.cleanSRT());
        }

        [Test]
        public void EmptyTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\empty.srt";
            Assert.AreEqual("", cleaner.cleanSRT());
        }

        [Test]
        public void EmptyEDLTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\empty.srt";
            cleaner.EDLFileName = "..\\..\\data\\empty.edl";
            Assert.AreEqual("", cleaner.cleanSRT());
        }

        [Test]
        public void ProsTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\Pros.srt";
            cleaner.EDLFileName = "..\\..\\data\\Pros.edl";
            String result = LoadResult("..\\..\\data\\Pros.result.txt");
            Assert.AreEqual(result, cleaner.cleanSRT());
        }

        [Test]
        public void ProsNoEDLTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\Pros.srt";
            String result = LoadResult("..\\..\\data\\Pros.noedl.txt");
            Assert.AreEqual(result, cleaner.cleanSRT());
        }

        [Test]
        public void SamuraiTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\Samurai.srt";
            cleaner.EDLFileName = "..\\..\\data\\Samurai.edl";
            String result = LoadResult("..\\..\\data\\Samurai.result.txt");
            Assert.AreEqual(result, cleaner.cleanSRT());
        }

        [Test]
        public void SamuraiNoEDLTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\Samurai.srt";
            String result = LoadResult("..\\..\\data\\Samurai.noedl.txt");
            Assert.AreEqual(result, cleaner.cleanSRT());
        }

        [Test]
        public void UFCTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\UFC.srt";
            cleaner.EDLFileName = "..\\..\\data\\UFC.edl";
            String result = LoadResult("..\\..\\data\\UFC.result.txt");
            Assert.AreEqual(result, cleaner.cleanSRT());
        }

        [Test]
        public void UFCNoEDLTest()
        {
            SRTCleaner cleaner = new SRTCleaner();
            cleaner.SRTFileName = "..\\..\\data\\UFC.srt";
            String result = LoadResult("..\\..\\data\\UFC.noedl.txt");
            Assert.AreEqual(result, cleaner.cleanSRT());
        }

    }
}
