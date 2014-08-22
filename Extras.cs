using System;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace FlurryBinding
{
    public partial class FlurryApi : NSObject {
        public static void LogEvent(string eventName, List<Parameter> parameters)
        {
            FlurryApi.LogEvent(eventName, ParametersToNSDictionary(parameters));
        }

        public static void LogError(string message, Exception exception)
        {
            FlurryApi.LogError(exception.Message, message, new NSException(exception.Message, "", null));
        }

        public static void EndTimedEvent(string eventName, List<Parameter> parameters)
        {
            FlurryApi.EndTimedEvent(eventName, ParametersToNSDictionary(parameters));
        }

        private static NSDictionary ParametersToNSDictionary(List<Parameter> parameters)
        {
            var dict = new NSDictionary();
            foreach (var parameter in parameters)
            {
                dict[new NSString(parameter.Name)] = new NSString(parameter.Value);
            }

            return dict;
        }
    }
    /*public partial class FlurryApi : NSObject {
        public static void LogEvent (string eventName, List<Parameter> parameters)
        {
            Api.LogEvent(eventName, ParametersToNSDictionary(parameters));
        }

        public static void LogError (string message, Exception exception)
        {

        }

        private static NSDictionary ParametersToNSDictionary(List<Parameter> parameters)
        {
            var dict = new NSDictionary();
            foreach (var parameter in parameters)
            {
                dict[new NSString(parameter.Name)] = new NSString(parameter.Value);
            }

            return dict;
        }
    }*/

    public class Parameter
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public Parameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}

