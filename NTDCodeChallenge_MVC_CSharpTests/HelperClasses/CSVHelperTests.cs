using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTDCodeChallenge_MVC_CSharp.HelperClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCodeChallenge_MVC_CSharp.HelperClasses.Tests
{
    [TestClass()]
    public class CSVHelperTests
    {
        [TestMethod()]
        public void CSVParserTest()
        {
            string inputString = "4841189,\"\"\"Shut Up, Mom!\"\" Disrespectful Kids\",public,87,19542,28,Sun Oct 06 23:44:53 2015";
            CSVHelper csv = new CSVHelper();
            ArrayList arr = csv.CSVParser(inputString);
            Assert.AreEqual(arr[1], "\"Shut Up, Mom!\" Disrespectful Kids");
            Assert.AreEqual(arr[2], "public");
        }

        [TestMethod()]
        public void CSVParserTest1()
        {
            //4840998,"Do You Tell Your Kids to """"Shut Up?""""",public,37,12747,18,Sat Oct 05 21:40:30 2015
            string inputString = "4839301,Lower Your Baby's Risk of SIDS With a Fan,private,47,1239,21,Fri Oct 18 04:06:13 2015";
            CSVHelper csv = new CSVHelper();
            ArrayList arr = csv.CSVParser(inputString);
            Assert.AreEqual(arr[1], "Lower Your Baby's Risk of SIDS With a Fan");
            Assert.AreEqual(arr[6], "Fri Oct 18 04:06:13 2015");
        }

        [TestMethod()]
        public void formatStringTest()
        {
            //string message = "\"t,e,s,t,1\"";
            string message = "Say, \"Thank You.\" Teaching Kids the Power of Gratitude";
            CSVHelper csv = new CSVHelper();
            string result = csv.formatString(message);
        }
        
    }
}