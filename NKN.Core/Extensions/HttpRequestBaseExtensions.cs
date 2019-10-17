using System.Web;
using NKN.Common;

namespace NKN.Core.Extensions
{
    public static class HttpRequestBaseExtensions
    {
        public static string GetQueryParameter(this HttpRequestBase request)
        {
            if (request == null) return string.Empty;

            return request[Common.Constants.RequestParameters.Query];
        }

        public static int GetPageParameter(this HttpRequestBase request)
        {
            const int defaultValue = 1;
            if (request == null) return defaultValue;

            return int.TryParse(request[Common.Constants.RequestParameters.Page], out var page) ? page : defaultValue;
        }
    }
}