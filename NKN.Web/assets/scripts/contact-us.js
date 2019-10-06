$(document).ready(function () {
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

    // Hook up the form so we can prevent it from being posted
    document.querySelector("form#contact-us-form")
        .addEventListener("submit", function (ev) {
            ev.preventDefault();
            handleFormSubmit(this);
        });

    function handleFormSubmit(form) {
        // First we gather the values from the form
        var values = validate.collectFormValues(form);
        // then we validate them against the constraints
        var errors = validate(values, constraints, { format: "flat" });
        // then we update the form to reflect the results
        showErrors(form, errors || {});
        // And if all constraints pass we let the user know
        if (!errors) {
            showSuccess();
        }
    }

    // Updates the inputs with the validation errors
    function showErrors(form, errors) {
    }

    function showSuccess() {
        // We made it \:D/
        alert("Success!");
    }
});
