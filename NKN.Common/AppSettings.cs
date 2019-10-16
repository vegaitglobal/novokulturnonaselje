﻿using System.ComponentModel;
using System.Configuration;

namespace NKN.Common
{
    /// <summary>
    /// Enables access to application settings, stored in App.config or Web.config 'appSettings' section.
    /// </summary>
    public static class AppSettings
    {
        public static bool DisableHttpCompression => Get("disableHttpCompression", false);
        public static string XMLSitemapRouteUrl => Get("xmlSitemapRouteUrl", "xmlsitemap");
        public static string SmtpUsername => Get("smtp.Username", "xmlsitemap");
        public static string SmtpPassword => Get("smtp.Password", "xmlsitemap");
        public static string DateFormat => Get("dateFormat", "dd.MM.yyyy.");

		//MailChimp
		public static string MailchimpApiKey => Get<string>("mailchimpApiKey");
		public static string MailchimpListId => Get<string>("mailchimpListId");

		public static string EmailRegex => Get<string>("emailRegex");

		/// <summary>
		/// Retrieves configuration value associated with given <paramref name="key"/>.
		/// </summary>
		/// <typeparam name="T">Configuration value type.</typeparam>
		/// <param name="key">Configuration key.</param>
		/// <returns>Configuration value associated with given <paramref name="key"/>.</returns>
		public static T Get<T>(string key)
        {
            var setting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(setting))
                throw new ConfigurationErrorsException($"Key '{key}' not found in the configuration file!");

            return (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(setting);
        }

        /// <summary>
        /// Retrieves configuration value associated with given <paramref name="key"/>.
        /// If value for given <paramref name="key"/> is not found, <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <typeparam name="T">Configuration value type.</typeparam>
        /// <param name="key">Configuration key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Configuration value associated with given <paramref name="key"/>, or <paramref name="defaultValue"/> if given <paramref name="key"/> is not found.</returns>
        public static T Get<T>(string key, T defaultValue)
        {
            var setting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(setting)) return defaultValue;

            return (T) TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(setting);
        }
    }
}