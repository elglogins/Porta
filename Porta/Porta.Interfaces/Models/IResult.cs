using System;
using System.Collections.Generic;

namespace Porta.Interfaces.Models
{
    public interface IResult
    {
        bool HasError { get; set; }
        Exception Exception { get; set; }
        List<string> Messages { get; set; }

        List<string> GetMessages();
    }

    public interface IResult<T> : IResult
    {
        T ResultObj { get; set; }
    }
}
