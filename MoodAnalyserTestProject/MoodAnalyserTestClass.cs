using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
using System;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestMethod]

        [DataRow("I am in a sad mood", "sad")] 
        [DataRow("I am in a happy mood", "happy")]
        public void Given_Message_Should_Return_UserMood(string message, string expected)
        {
            //AAA Methodology

            //Arrange
            //string message = "I am in sad mood";
            //string expected = "sad";
            MoodAnalyser mood = new MoodAnalyser(message);

            //Act
            string actual=mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //[DataRow(null, "Object reference not set to an instance of an object.")]
        //[DataRow(null, "happy")]
        public void Given_NullMessage_Should_Return_Exception()
        {
            string message = null;
            string expected = "Message is having null";
            //AAA Methodology
            try
            { 
                //Arrange
                MoodAnalyser mood = new MoodAnalyser(message);

                //Act
                //string actual = mood.AnalyseMood();
                string actual = mood.CustomAnalyseMood();

                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch(CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
