using FluentEmail.Core.Models;
using System;
using System.Linq;

namespace NKN.Core.Extensions
{
    public static class SendResponseExtensions
    {
        public static Exception ToException(this SendResponse sendResponse)
            => new Exception(sendResponse.ErrorMessages.Aggregate((s, current) => s + current));
    }
}