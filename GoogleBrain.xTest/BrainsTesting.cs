using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using GoogleBrain.Brains;
using Moq;
using GoogleBrain.Models;

namespace GoogleBrain.xTest
{
    public class BrainsTesting
    {
        [Fact]
        public void SimplestBrainBadRequestThrowsException()
        {
            // SETUP
            SimpleResultsGBrain SmpBrain = new SimpleResultsGBrain();

            // EXERCISE & ASSERT
            Assert.Throws<BadRequestException>(() => SmpBrain.AnswerQuestion(@"""#$%&'()*+,-./:;<=>@[\]^_`{|}~"));
        }

        [Fact]
        public void SimplestBrainReturnsCorrectAnswerMockked()
        {
            // SETUP 
            Mock<IGbrainAPI> MockGoogleApi = new Mock<IGbrainAPI>();
            MockGoogleApi.CallBase = true;
            MockGoogleApi.Setup(x => x.GetNumerOfResults(It.IsAny<string>(), It.Is<string>(s => s == "Answer True"))).Returns(100);
            MockGoogleApi.Setup(x => x.GetNumerOfResults(It.IsAny<string>(), It.Is<string>(s => s == "Answer Second"))).Returns(50);
            MockGoogleApi.Setup(x => x.GetNumerOfResults(It.IsAny<string>(), It.Is<string>(s => s == "Answer Third Score"))).Returns(20);

            SimpleResultsGBrain SmpBrain = new SimpleResultsGBrain(MockGoogleApi.Object);

            // EXERCISE 
            IGAnswer res = SmpBrain.AnswerQuestion("Mockup Question", "Answer True", "Answer Third Score", "Answer Second");

            // ASSERT
            Assert.Equal("Answer True", res.CorrectAnswer);

        }

    }
}
