//var constraints = {
//	email: {
//		presence: {
//			message: 'Email adresa nije uneta'
//		},
//		email: {
//			message: 'Email adresa nije validna'
//		}
//	},
//	name: {
//		presence: {
//			message: 'Ime i prezime nije uneto'
//		},
//		length: {
//			minimum: 3,
//			maximum: 50,
//			message: 'Ime i prezime može biti max 50 slova'
//		}
//	},
//	message: {
//		presence: {
//			message: 'Poruka nije uneta'
//		},
//		length: {
//			minimum: 3,
//			maximum: 500,
//			message: 'Poruka može biti max 500 slova'
//		}
//	}
//};

//var contactForm = document.getElementById("contact-us");
//if (contactForm !== null) {
//	document.getElementById("contact-us")
//		.addEventListener("submit", function (ev) {
//			ev.preventDefault();
//			handleFormSubmit(this);
//		});
//}

//function handleFormSubmit(form) {
//	var contactInfo = validate.collectFormValues(form);
//	var errors = validate(contactInfo, constraints, { format: "flat" });
//	showErrors(form, errors || []);

//	if (!errors) {
//		contact(contactInfo);
//	}
//}

//function showErrors(form, errors) {
//	clearSuccessMessage();
//	if (errors.length > 0) {
//		var message = errors.reduce(function (message, error) { return message + error.split(' ').slice(1).join(' ') + "!<br>"; }, '');
//		document.getElementsByClassName('js-error-message')[0].innerHTML = message;
//	}
//}

//function setErrorMessage() {
//	clearSuccessMessage();
//	return document.getElementsByClassName('js-error-message')[0].innerHTML = 'Udruženje nije kontaktirano. Email nije uspešno poslat.';
//}

//function clearErrorMessage() {
//	return document.getElementsByClassName('js-error-message')[0].innerHTML = '';
//}

//function clearSuccessMessage() {
//	$('.js-success-message').removeClass('show');
//}
//function contact(contactInfo) {
//	fetch('/umbraco/api/forms/contactus', {
//		method: 'POST',
//		headers: {
//			'Content-Type': 'application/json'
//		},
//		body: JSON.stringify(contactInfo)
//	}).then(function (response) {
//		if (response.status === 400) {
//			setErrorMessage();
//			return;
//		}

//		$('.js-success-message').addClass('show');
//		clearErrorMessage();
//	}).catch(function (error) {
//		setErrorMessage();
//	});
//}
// E-mail address validation
//jQuery.validator.unobtrusive.adapters.add("emailcustom", ["emailregex"], function (options) {
//	options.rules["emailcustom"] = { emailregex: options.params.emailregex };
//	if (options.message) {
//		options.messages["emailcustom"] = options.message;
//	}
//});
//jQuery.validator.addMethod("emailcustom", function (value, element, param) {
//	if (value === "") return true;

//	var regex = new RegExp(param.emailregex);

//	return regex.test(value);
//});
