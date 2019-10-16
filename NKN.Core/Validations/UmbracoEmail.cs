using NKN.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace NKN.Core.Validations
{
	public class UmbracoEmail : ValidationAttribute, IClientValidatable
	{
		private static Regex _regex = new Regex(AppSettings.EmailRegex, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

		/// <summary>
		/// 
		/// </summary>
		public string ErrorMessageDictionaryKey { get; set; }

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var email = Convert.ToString(value);
			if (!string.IsNullOrEmpty(email))
			{
				//Test the regex
				var result = _regex.Match(email).Length > 0;

				//If no matches then email NOT valid
				if (!result)
				{
					//Get the error message to return
					var error = UmbracoValidationHelper.FormatErrorMessage(validationContext.DisplayName, ErrorMessageDictionaryKey);

					//Return error
					return new ValidationResult(error);
				}
			}

			//All good :)
			return ValidationResult.Success;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var error = UmbracoValidationHelper.FormatErrorMessage(metadata.DisplayName, ErrorMessageDictionaryKey);
			var rule = new ModelClientValidationRule
			{
				ErrorMessage = error,
				ValidationType = "emailcustom"
			};

			rule.ValidationParameters["emailregex"] = _regex.ToString();

			yield return rule;

		}
	}
}
