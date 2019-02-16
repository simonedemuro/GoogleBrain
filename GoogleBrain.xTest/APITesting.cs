
using System;
using Xunit;
using GoogleBrain;
using System.Reflection;
using Moq;

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
            // SETUP
            GbrainAPI b = new GbrainAPI();

            // EXERCISE
            long results = b.GetNumerOfResults("this", "is", "a", "test");

            //ASSERT
            Assert.True(results > 5000000000);
        }

        [Fact]
        public void GetNumberOfOccourrencesOfAnAnswerInGoogleSearch()
        {
            // SETUP
            GbrainAPI b = new GbrainAPI();
            string question = "chi ha vinto i mondiali del 2006?";
            string answer = "Italia";

            // EXERCISE
            long results = b.GetNumberOfOccourrences(question, answer);

            // ASSERT
            Assert.True(results > 5);
            //the assertion is that the number of result is greater than 5, as of now 
            //(2019-02-16) there are 25 matches of the Word Italia inside the page 
            //https://www.google.com/search?q=chi+ha+vinto+i+mondiali+del+2006
            //considering to mock the response of the method that gives the html back to make it deterministic
            //as of now it is not so due to its protection level
        }

    }
}
