
using System;
using Xunit;
using GoogleBrain;

namespace GoogleBrain.xTest
{
    public class UnitTest1
    {
        [Fact]
        public void RetrieveValidHTML()
        {
            Gbrain b = new Gbrain();
            string myPage = b.GetPlainPage("http://www.gooogle.com");

            Assert.Contains("<html", myPage);
        }

        [Fact]
        public void ConcatPathCorrectly()
        {
            Gbrain b = new Gbrain();
            string myURL = b.GenerateSearchURL("this", "is", "a", "test");

            Assert.Equal("https://www.google.com/search?q=this+is+a+test", myURL);
        }

        [Fact]
        public void GetGoogleNumberOfResults()
        {
            Gbrain b = new Gbrain();

            long results = b.GetNumerOfResults("this", "is", "a", "test");

            Assert.True(results> 7000000000);
        }

    }
}
