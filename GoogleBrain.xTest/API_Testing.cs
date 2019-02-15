
using System;
using Xunit;
using GoogleBrain;
using System.Reflection;

namespace GoogleBrain.xTest
{
    public class UnitTest1
    {
        public object AccessGbrainAPIPrivateMethod(string methodName, object[] args)
        {
            GbrainAPI b = new GbrainAPI();

            var mi = b.GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (mi != null)
            {
                return mi.Invoke(b, args);
            }
            return null;
        }

        [Fact]
        public void RetrieveValidHTML()
        {
            // SETUP
            object[] args = new object[] { "http://www.gooogle.com" };

            // EXERCISE
            object myPage = AccessGbrainAPIPrivateMethod("GetPlainPage", args); //is equivalent to string myPage = b.GetPlainPage("http://www.gooogle.com");

            // ASSERT
            Assert.Contains("<html", myPage.ToString());
        }

        [Fact]
        public void ConcatPathCorrectly()
        {
            // SETUP
            string[] strs = new string[] { "this", "is", "a", "test" };
            object[] args = new object[] { strs };
            // EXERCISE
            object myURL = AccessGbrainAPIPrivateMethod("GenerateSearchURL", args); //equivalent to string myURL = b.GenerateSearchURL("this", "is", "a", "test");

            // ASSERT
            Assert.Equal("https://www.google.com/search?q=this+is+a+test", myURL.ToString());
        }

        [Fact]
        public void GetGoogleNumberOfResults()
        {
            GbrainAPI b = new GbrainAPI();

            long results = b.GetNumerOfResults("this", "is", "a", "test");

            Assert.True(results > 5000000000);
        }

    }
}
