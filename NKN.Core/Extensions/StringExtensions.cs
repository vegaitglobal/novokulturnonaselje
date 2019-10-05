using System.Web.Mvc;
using NKN.Common.Extensions;

namespace NKN.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns <paramref name="controllerName"/> string after stripping "Controller" suffix from it.
        /// </summary>
        /// <param name="controllerName">The name of the controller class.</param>
        /// <returns>Name without "Controller" suffix.</returns>
        public static string RemoveControllerSuffix(this string controllerName)
        {
            return controllerName.RemoveSuffix(nameof(Controller));
        }
    }
}