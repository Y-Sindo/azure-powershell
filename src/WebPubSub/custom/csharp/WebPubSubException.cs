using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20;

namespace Microsoft.Azure.PowerShell.Cmdlets.WebPubSub
{
    internal class WebPubSubException : AggregateException
    {
        public IErrorAdditionalInfo[] AdditionalInfo { get; set; }
        public WebPubSubException(string message, IEnumerable<Exception> exceptions) : base(message, exceptions)
        {
        }
        
        public static WebPubSubException FromErrorResponse(IErrorResponse error)
        {
            return new WebPubSubException($"[{error.Code}] : {error.Message}", error.Detail?.Select(d => FromErrorDetail(d)))
            {
                AdditionalInfo = error.AdditionalInfo
            };
        }

        public static WebPubSubException FromErrorDetail(IErrorDetail error)
        {
            return new WebPubSubException($"[{error.Code}] : {error.Message}", error.Detail?.Select(d => FromErrorDetail(d)))
            {
                AdditionalInfo = error.AdditionalInfo
            };
        }
    }
}
