using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NKN.Core.Validations
{
	public class UmbracoStringLength : StringLengthAttribute, IClientValidatable
	{
		private readonly string _errorMessageDictionaryKey;
		private readonly int _maximumLength;

		public UmbracoStringLength(string errorMessageDictionaryKey, int maximumLength) : base(maximumLength)
		{
			_maximumLength = maximumLength;
			_errorMessageDictionaryKey = errorMessageDictionaryKey;
		}


		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{

			ErrorMessage = UmbracoValidationHelper.FormatErrorMessage(_maximumLength.ToString(), _errorMessageDictionaryKey);

			var error = ErrorMessage;
			var rule = new ModelClientValidationStringLengthRule(error, MinimumLength, MaximumLength);

			yield return rule;
		}
	}
}
