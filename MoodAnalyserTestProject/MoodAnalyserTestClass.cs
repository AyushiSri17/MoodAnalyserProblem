using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
using MoodAnalyserProblem.Reflection;
using System;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestCategory("Mood")]
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
            string actual = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCategory("Exception")]
        [TestMethod]
        //[DataRow(null, "Object reference not set to an instance of an object.")]
        //[DataRow(null, "happy")]
        [DataRow(null, "Message is having null")]
        [DataRow("", "Mood is Empty")]
        public void Given_NullMessage_Should_Return_Exception(string message, string expected)
        {
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
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Reflection")]
        //[DataRow("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser")]
        //[DataRow("MoodAnalyserProject.Contact", "Contact")]
        [DataRow("MoodAnalyserProject.MoodAnalyser", "Customer")]

        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object(string className, string constructor)
        {
            //string expectedMessage = "Class not found";
            string expectedMessage = "Constructor not found";
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructor);
                expected.Equals(actual);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        } 
    }
}
