
// E-mail address validation
jQuery.validator.unobtrusive.adapters.add("emailcustom", ["emailregex"], function (options) {
	options.rules["emailcustom"] = { emailregex: options.params.emailregex };
	if (options.message) {
		options.messages["emailcustom"] = options.message;
	}
});

jQuery.validator.addMethod("emailcustom", function (value, element, param) {
	if (value === "") return true;

	var regex = new RegExp(param.emailregex);

	return regex.test(value);
});
