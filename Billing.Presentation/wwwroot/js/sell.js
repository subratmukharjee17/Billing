var mainArray = [];
$(document).on("click", ".btn-del", function (e) {
  $(this).closest("tr").remove();
  if ($("#table-sell tbody tr").length) {
    $(".table-data-js").removeClass("d-none");
    let row = $(this).attr("data-rownum");
    mainArray.splice(+row-1,1);
  } else {
    $(".table-data-js").addClass("d-none");
  }
});


function submitForm(formDataArray) {

    $.ajax({
        type: 'POST',
        url: '/Sales/AddSale',
        contentType: 'application/json',
        dataType: 'json', 
        data: JSON.stringify(formDataArray),
      //  data: JSON.stringify(postData),
        success: function (response) {
            alert(response);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function appendTableRow(arr) {
   // var formDataArray = [];
    let rowLength = $("#table-sell tbody tr").length;
    let tr = "<tr>";

    if (arr && arr.length) {
        let obj = {};
        //arr.forEach((item, index) => {
        //    obj[item.name] = item.value;
        //    tr += `<td data-value=${item.value} data-name=${item.name}>${item.value}</td>`;
        //});

        arr.forEach((item, index) => {
            // Include only specific fields in the table
            if (item.name === "ProductId" || item.name === "Quantity" || item.name === "Price" || item.name === "Amount") {
                obj[item.name] = item.value;
                tr += `<td data-value=${item.value} data-name=${item.name}>${item.value}</td>`;
            }
            // if (item.name === "customerName" || item.name === "PhoneNo" || item.name === "PaymentType") {
            //    // Include remaining three controls in mainArray
            //    obj[item.name] = item.value;
            //}
           
        });

        tr += `<td data-value="button" class="d-flex justify-content-end" data-name="button" ><button class="btn btn-danger sell-0 btn-del"
            data-rownum="${rowLength + 1}" id="sell-plus-btn-js"><i class="bi bi-x-circle"></i> </button></td>`;

        tr += "</tr>";
        $("#table-sell tbody").append(tr);
        $(".table-data-js").removeClass("d-none");
        mainArray.push(obj);
    } else {
        $(".table-data-js").addClass("d-none");
    }
}
 // Event delegation for form submission
$(document).on("submit", ".sell-form", function (e) {
  //  debugger;
    e.preventDefault();
    console.log("Form submitted!");

    if ($(this).valid()) {
        appendTableRow($(this).serializeArray());
      //  $(this).find("input[type=text]:not(#CustomerName), textarea, select").val("");
      //  $(this).find("input[type=text], textarea").val("");
        $(this).find("input[type=text], textarea, select").removeClass("is-valid");

        // Check if there are multiple orders
        if ($("#table-sell tbody tr").length >= 1) {
            var formDataArray = [];

            // Iterate through each row and add data to formDataArray
            $("#table-sell tbody tr").each(function () {
                var formData = {};
                $(this).find("td").each(function () {
                    formData[$(this).data("name")] = $(this).data("value");
                });
                formDataArray.push(formData);
            });

            // Submit the form data array to the server
            submitForm(formDataArray);
        }
    }
});


//$(document).on("click", ".btn-save-table-data", function (e) {
//    debugger;
//  if(mainArray && mainArray.length) {
//    localStorage.setItem('tableData',JSON.stringify(mainArray));
//    showSuccess(`<div class="" >
//   Saved successfully.
//  </div>`,'success')
//  } else {
//    showSuccess(`<div class="" >
//   Error, Please try again!
//   </div>`,'danger');
//  }


//  console.log(mainArray);
//});



$(document).ready(function () {
    // Event delegation for button click
    $(document).on("click", "#SaveSale", function (e) {
        debugger;
        e.preventDefault();

        // Check if there are multiple orders
        if ($("#table-sell tbody tr").length >= 1) {
            var formDataArray = [];

            //var additionalFields = {
            //    customerName: $("#customerName").val(),
            //    PhoneNo: $("#PhoneNo").val(),
            //    PaymentType: $("#PaymentType").val()
            //};

            // Iterate through each row and add data to formDataArray
            $("#table-sell tbody tr").each(function () {
                var formData = {};
                $(this).find("td").each(function () {
                    formData[$(this).data("name")] = $(this).data("value");
                });
                formData["BillingId"] =  $("#BillingId").text();
                formData["CustomerName"] = $("#CustomerName").val();
                formData["PhoneNo"] = $("#PhoneNo").val();
                formData["PaymentType"] = $("#PaymentType").val();
                formDataArray.push(formData);
            });

            // Submit the form data array to the server
            submitForm(formDataArray);
        }
    });

    // ... other code

    // Dynamic row addition code
    $("#sell-plus-btn-js").click(function () {
        // Increment the row counter
        // ... (your existing code for adding dynamic rows)
    });

    // Dynamic row removal code
    $(document).on("click", ".btn-remove-row", function () {
        // ... (your existing code for removing dynamic rows)
    });
});




//$(document).ready(function (e) {
//  // Add and configure the validation for the form
//  //$(".sell-form").validate({
//  //  //     errorClass: "is-invalid",
//  //  //   validClass: "is-valid",
//  //  errorElement: "div", // Change the error element to a div
//  //  errorClass: "is-invalid", // Bootstrap class for styling
//  //  errorPlacement: function (error, element) {
//  //    // Add Bootstrap classes for styling
//  //    error.addClass("invalid-feedback");
//  //    error.insertAfter(element); // Insert the error message after the input element
//  //  },
//  //  highlight: function (element, errorClass, validClass) {
//  //    // Add Bootstrap classes for styling to the input field
//  //    $(element).addClass("is-invalid").removeClass("is-valid");
//  //  },
//  //  unhighlight: function (element, errorClass, validClass) {
//  //    // Add Bootstrap classes for styling to the input field
//  //    $(element).removeClass("is-invalid").addClass("is-valid");
//  //  },
//  });

  $(".sell-form").submit(function (e) {
    e.preventDefault(e);
    console.log($(this).valid());
    if($(this).valid()) {
      appendTableRow($(this).serializeArray());
      $(this).find("input[type=text], textarea").val("");
      $(this).find("input[type=text], textarea, select").removeClass("is-valid");
    }
  });
////});
