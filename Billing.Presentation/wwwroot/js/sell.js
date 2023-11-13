
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

function appendTableRow(arr) {
  let rowLength = $("#table-sell tbody tr").length;
  let tr = "<tr>";

  if (arr && arr.length) {
    let obj = {};
    arr.forEach((item, index) => {
      obj[item.name] = item.value;
      tr += `<td data-value=${item.value} data-name=${item.name}>${item.value}</td>`;
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
//});
