using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public MoodAnalyser() { }
        public string AnalyseMood()
        {
            try
            {
                if (message.ToLower().Contains("happy"))
                    return "happy";
                else
                    return "sad";
            }
            catch (NullReferenceException e)
            {
                //return "happy";
                return e.Message;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }
        public string CustomAnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    try
                    {
                        throw new CustomMoodAnalyserException("Mood is Empty", CustomMoodAnalyserException.ExceptionTypes.EMPTY_MOOD);
                    }
                    catch (CustomMoodAnalyserException e)
                    {
                        return e.Message;
                    }
                }
                else if (message.ToLower().Contains("happy"))
                    return "happy";
                else
                    return "sad";
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    throw new CustomMoodAnalyserException("Message is having null", CustomMoodAnalyserException.ExceptionTypes.NULL_MOOD);
                }
                catch(CustomMoodAnalyserException e)
                { 
                    return e.Message;
                }
            }
        }
    }
}
