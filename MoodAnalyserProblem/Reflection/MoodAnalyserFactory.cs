using MoodAnalyserProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem.Reflection
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyserObject(string className, string constructor)
        {
            string pattern = @"." + constructor + "$";//MoodAnalyserProblem.MoodAnalyser
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            else
            {
                throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
            }
        }

        public static object CreateMoodAnalyserObjectWithParameterizedConstructor(string className, string constructor, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Contains(className) || type.FullName.Contains(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });//search for the constructor
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            else
            {
                throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
            }
        }

        public static string InvokeAnalyseMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                object moodAnalyseObject = CreateMoodAnalyserObjectWithParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info = methodInfo.Invoke(moodAnalyseObject, null);//it will invoke method and store the return value
                return info.ToString();
            }
            catch (CustomMoodAnalyserException ex)
            {
                if (ex.Message.Equals("Class not found"))
                {
                    throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
                else
                {
                    throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            catch (Exception)
            {
                throw new CustomMoodAnalyserException("Method not found", CustomMoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }

        public static string DynamicSetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);                
                field.SetValue(moodAnalyser, message);
                if (message == null)
                {
                    throw new CustomMoodAnalyserException("Message should not be null", CustomMoodAnalyserException.ExceptionTypes.NULL_MESSAGE);
                }
                return moodAnalyser.message;//return should be the last executing statement
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserException("Field is not found", CustomMoodAnalyserException.ExceptionTypes.NO_SUCH_FIELD);
            }
        }
    }
}
