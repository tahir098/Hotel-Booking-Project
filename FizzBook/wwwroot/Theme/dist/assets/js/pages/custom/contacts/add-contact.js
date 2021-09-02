"use strict";
$("body").on("click", "#NextBtn", function () {
	debugger
	var userFirstName = $("#UserFirstName").val();
	var userLastName = $("#UserLastName").val();
	var companyName = $("#CompanyName").val();
	var contactNo = $("#ContactNo").val();
	var email = $("#Email").val();
	var companySite = $("#CompanySite").val();
	var addressOne = $("#AddressOne").val();
	var addressTwo = $("#AddressTwo").val();
	var postCode = $("#PostCode").val();
	var city = $("#city").val();
	var state = $("#State").val();

	$("#companyName").val(companyName);
	$("#customerName").val(userFirstName + " " + userLastName);
	$("#contactNo").val(contactNo);
	$("#email").val(email);
	$("#companyName").val(companySite);
	$("#address1").val(addressOne);
	$("#address2").val(addressTwo);
	$("#postCode").val(postCode);

});
$("body").on("click", "#submitBtn", function (e) {
	debugger
	e.preventDefault();
	var userFirstName = $("#UserFirstName").val();
	var userLastName = $("#UserLastName").val();
	var companyName = $("#CompanyName").val();
	var contactNo = $("#ContactNo").val();
	var email = $("#Email").val();
	var companySite = $("#CompanySite").val();
	var addressOne = $("#AddressOne").val();
	var addressTwo = $("#AddressTwo").val();
	var postCode = $("#PostCode").val();
	var city = $("#city").val();
	var state = $("#State").val();
	var company = {
		UserFirstName: userFirstName,
		UserLastName: userLastName,
		CompanyName: companyName,
		ContactNo: contactNo,
		Email: email,
		CompanySite: companySite,
		AddressOne: addressOne,
		AddressTwo: addressTwo,
		PostCode: postCode,
		city: city,
		State: state
	};
	$.ajax({
		type: "POST",
		url: "/Master/Setup/AddCompany",
		contentType: "application/json; charset=utf-8",
		dataType: 'json',
		data: JSON.stringify(company),
		success: function () {
			location.reload();
			toastr.success("Client successfully created", "Success");
		}
	});

});


// Class definition
var KTContactsAdd = function () {
	// Base elements
	var _wizardEl;
	var _formEl;
	var _wizard;
	var _avatar;
	var _validations = [];

	// Private functions
	var initWizard = function () {
		// Initialize form wizard
		_wizard = new KTWizard(_wizardEl, {
			startStep: 1, // initial active step number
			clickableSteps: true  // allow step clicking
		});

		// Validation before going to next page
		_wizard.on('beforeNext', function (wizard) {
			// Don't go to the next step yet
			_wizard.stop();

			// Validate form
			var validator = _validations[wizard.getStep() - 1]; // get validator for currnt step
			validator.validate().then(function (status) {
				if (status == 'Valid') {
					_wizard.goNext();
					KTUtil.scrollTop();
				} else {
					Swal.fire({
						text: "Sorry, looks like there are some errors detected, please try again.",
						icon: "error",
						buttonsStyling: false,
						confirmButtonText: "Ok, got it!",
						customClass: {
							confirmButton: "btn font-weight-bold btn-light"
						}
					}).then(function () {
						KTUtil.scrollTop();
					});
				}
			});
		});

		// Change Event
		_wizard.on('change', function (wizard) {
			KTUtil.scrollTop();
		});
	}

	var initValidation = function () {
		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/

		// Step 1
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					firstname: {
						validators: {
							notEmpty: {
								message: 'First Name is required'
							}
						}
					},
					lastname: {
						validators: {
							notEmpty: {
								message: 'Last Name is required'
							}
						}
					},
					companyname: {
						validators: {
							notEmpty: {
								message: 'Company Name is required'
							}
						}
					},
					phone: {
						validators: {
							notEmpty: {
								message: 'Phone is required'
							},
							phone: {
								country: 'US',
								message: 'The value is not a valid US phone number. (e.g 5554443333)'
							}
						}
					},
					email: {
						validators: {
							notEmpty: {
								message: 'Email is required'
							},
							emailAddress: {
								message: 'The value is not a valid email address'
							}
						}
					},
					companywebsite: {
						validators: {
							notEmpty: {
								message: 'Website URL is required'
							}
						}
					}
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap()
				}
			}
		));

		// Step 2
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					// Step 2
					communication: {
						validators: {
							choice: {
								min: 1,
								message: 'Please select at least 1 option'
							}
						}
					},
					language: {
						validators: {
							notEmpty: {
								message: 'Please select a language'
							}
						}
					},
					timezone: {
						validators: {
							notEmpty: {
								message: 'Please select a timezone'
							}
						}
					}
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap()
				}
			}
		));

		// Step 3
		_validations.push(FormValidation.formValidation(
			_formEl,
			{
				fields: {
					address1: {
						validators: {
							notEmpty: {
								message: 'Address is required'
							}
						}
					},
					postcode: {
						validators: {
							notEmpty: {
								message: 'Postcode is required'
							}
						}
					},
					city: {
						validators: {
							notEmpty: {
								message: 'City is required'
							}
						}
					},
					state: {
						validators: {
							notEmpty: {
								message: 'state is required'
							}
						}
					},
					country: {
						validators: {
							notEmpty: {
								message: 'Country is required'
							}
						}
					},
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap()
				}
			}
		));
	}

	var initAvatar = function () {
		_avatar = new KTImageInput('kt_contact_add_avatar');
	}

	return {
		// public functions
		init: function () {
			_wizardEl = KTUtil.getById('kt_contact_add');
			_formEl = KTUtil.getById('kt_contact_add_form');

			initWizard();
			initValidation();
			initAvatar();
		}
	};
}();

jQuery(document).ready(function () {
	KTContactsAdd.init();
});
