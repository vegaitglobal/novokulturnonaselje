using System.IO;
using System.Web;

namespace NKN.Core.Extensions
{
    /// <summary>
    /// <see cref="HttpResponseBase"/> extension methods.
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Converts <paramref name="response"/> to <see cref="HttpResponseBase"/> type.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        /// <returns><see cref="HttpResponseBase"/> instance created from <paramref name="response"/>.</returns>
        public static HttpResponseBase ToBase(this HttpResponse response)
        {
            return new HttpResponseWrapper(response);
        }

        /// <summary>
        /// Writes content of the <paramref name="filePath"/> to the HTTP response, ensuring that valid content (MIME) type is specified.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        /// <param name="filePath">Path to the file whose content will be written to the response.</param>
        public static void TransmitFileContent(this HttpResponseBase response, string filePath)
        {
            var filename = Path.GetFileName(filePath);
            if (filename == null) return;

            response.ContentType = MimeMapping.GetMimeMapping(filename);
            response.TransmitFile(filePath);
        }
    }
}