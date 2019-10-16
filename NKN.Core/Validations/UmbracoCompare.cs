using NKN.Core.Validations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
	public class UmbracoCompare : System.ComponentModel.DataAnnotations.CompareAttribute, IClientValidatable
	{
		private readonly string _otherProperty;
		private readonly string _errorMessageDictionaryKey;


		public UmbracoCompare(string errorMessageDictionaryKey, string otherProperty)
			: base(otherProperty)
		{
			_otherProperty = otherProperty;
			_errorMessageDictionaryKey = errorMessageDictionaryKey;
		}


		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(_errorMessageDictionaryKey);

			var error = FormatErrorMessage(metadata.DisplayName);
			var rule = new ModelClientValidationEqualToRule(error, _otherProperty);

			yield return rule;
		}
	}
}
