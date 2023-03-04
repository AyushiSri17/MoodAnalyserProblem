using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class CustomMoodAnalyserException:Exception
    {
        public ExceptionTypes exceptionTypes;
        public enum ExceptionTypes
        {
            NULL_MOOD,
            EMPTY_MOOD,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            NO_SUCH_METHOD
        }
        public CustomMoodAnalyserException(string message, ExceptionTypes exceptionTypes):base(message)
        {
            this.exceptionTypes = exceptionTypes;
        }
    }
}
