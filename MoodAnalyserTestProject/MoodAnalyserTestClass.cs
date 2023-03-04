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
        [DataRow("MoodAnalyserProblem.Contact", "Contact")]
        //[DataRow("MoodAnalyserProblem.MoodAnalyser", "Customer")]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object(string className, string constructor)
        {
            string expectedMessage = "Class not found";
            //string expectedMessage = "Constructor not found";
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

        [TestMethod]
        [TestCategory("Reflection")]
        //[DataRow("MoodAnalyser", "MoodAnalyser")]//because in if either pass name of full name both are acceptable
        //[DataRow("MoodAnalyserProblem.Contact", "Contact")]
        [DataRow("MoodAnalyserProblem.MoodAnalyser", "Customer")]
        public void Given_MoodAnalyserWithMessage_Using_Reflection_Return_ParameterizedConstructor(string className, string constructor)
        {
            string message = "I am in a happy mood";
            //string expectedMessage = "Class not found";
            string expectedMessage = "Constructor not found";
            try
            {
                //MoodAnalyserFactory factory=new MoodAnalyser();
                MoodAnalyser expected = new MoodAnalyser(message);
                object actual = MoodAnalyserFactory.CreateMoodAnalyserObjectWithParameterizedConstructor(className, constructor, message);
                expected.Equals(actual);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("I am i happy mood", "AnalyseMood", "happy")]
        [DataRow("I am i happy mood", "Analyse", "Method not found")]
        public void Given_MoodAnalyser_Using_Reflaction_Invoke_Method(string message, string methodName, string expected)
        {
            try
            {
                string actual = MoodAnalyserFactory.InvokeAnalyseMethod(message, methodName);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
