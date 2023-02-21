﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
using System;

namespace MoodAnalyserTestProject
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestMethod]
        public void Given_Message_Should_Return_UserMood()
        {
            //AAA Methodology

            //Arrange
            string message = "I am in sad mood";
            string expected = "sad";
            MoodAnalyser mood = new MoodAnalyser(message);

            //Act
            string actual=mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}