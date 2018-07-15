using Porta.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Porta.Models
{
    public class Result : IResult
    {
        public Result()
        {
            Messages = new List<string>();
        }

        public Result(bool hasError, string message)
        {
            Messages = new List<string>();
            HasError = hasError;

            if (!String.IsNullOrEmpty(message))
                Messages.Add(message);
        }

        public bool HasError { get; set; }
        public Exception Exception { get; set; }
        public List<string> Messages { get; set; }

        public List<string> GetMessages()
        {
            return Messages ?? new List<string>();
        }
    }

    public class Result<T> : IResult<T>
    {
        public bool HasError { get; set; }
        public Exception Exception { get; set; }
        public List<string> Messages { get; set; }

        public List<string> GetMessages()
        {
            var messages = new List<string>();
            if (Messages != null)
                foreach (var message in Messages)
                    messages.Add(message);
            if (Exception != null)
                messages.Add(Exception.Message);

            return messages;
        }

        public T ResultObj { get; set; }

        public Result()
        {
            Messages = new List<string>();
        }

        public Result(T t)
        {
            ResultObj = t;
        }

        public Result(string message, bool hasError = true)
        {
            Messages = new List<string> { message };
            HasError = hasError;
        }
    }
}
