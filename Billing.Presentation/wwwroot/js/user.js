$(document).ready(function () {
  // Add and configure the validation for the form
  $("#adduser").validate({
    //     errorClass: "is-invalid",
    //   validClass: "is-valid",
    errorElement: "div", // Change the error element to a div
    errorClass: "is-invalid", // Bootstrap class for styling
    errorPlacement: function (error, element) {
      // Add Bootstrap classes for styling
      error.addClass("invalid-feedback");
      error.insertAfter(element); // Insert the error message after the input element
    },
    highlight: function (element, errorClass, validClass) {
      // Add Bootstrap classes for styling to the input field
      $(element).addClass("is-invalid").removeClass("is-valid");
    },
    unhighlight: function (element, errorClass, validClass) {
      // Add Bootstrap classes for styling to the input field
      $(element).removeClass("is-invalid").addClass("is-valid");
    },
   
  });
});
