var constraints = {
    email: {
        presence: true,
        email: true
    },
    fullName: {
        presence: true,
        length: {
            minimum: 3,
            maximum: 50
        }
    },
    message: {
        presence: true,
        length: {
            minimum: 3,
            maximum: 500
        }
    }
};

document.getElementById("contact-us")
    .addEventListener("submit", function (ev) {
        ev.preventDefault();
        handleFormSubmit(this);
    });

function handleFormSubmit(form) {
    // First we gather the values from the form
    var contactInfo = validate.collectFormValues(form);
    // then we validate them against the constraints
    var errors = validate(contactInfo, constraints, { format: "flat" });
    // then we update the form to reflect the results
    showErrors(form, errors || []);
    // And if all constraints pass we let the user know
    if (!errors) {
        contact(contactInfo);
    }
}

// Updates the inputs with the validation errors
function showErrors(form, errors) {
    if (errors.length > 0)
        document.getElementsByClassName('error-message')[0].innerHTML = errors.reduce(function (message, error) {
            return message + error;
        });
}

function setErrorMessage() {
    return document.getElementsByClassName('error-message')[0].innerHTML = 'Udruženje nije kontaktirano. Email nije uspešno poslat.';
}

function contact(contactInfo) {
    fetch('/umbraco/api/forms/contactus', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(contactInfo)
    }).then(function (response) {
        if (response.status === 400) {
            setErrorMessage();
            return;
        }

        // Your code for handling the data you get from the API
        document.getElementsByClassName('error-message')[0].innerHTML = '@Model.WriteUs.OnSubmitMessage'
    }).catch(function () {
        setErrorMessage();
    });
}
