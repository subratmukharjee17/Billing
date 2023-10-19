let faqs_row = 1;

function addSells() {
  let html = `<tr id="sell-${faqs_row}">
<td><input type="text" name="pName" class="form-control" placeholder="Product name"></td>
<td><input type="text" name="nos" placeholder="Nos" class="form-control"></td>
<td><input type="text" name="weight" placeholder="wight" class="form-control"></td>
<td><input type="text"  name="rate" placeholder="Rate" class="form-control"></td>
<td><input type="text" name="amount"  placeholder="Amount" class="form-control"></td>
<td class="mt-10"><button class="btn btn-danger" id="sell-btn-js"  data-rownum="${
    "sell-" + faqs_row
  }"><i class="bi bi-x-circle"></i> </button></td>
</tr>`;

  $("#sells tbody").append(html);

  faqs_row++;
}

$(document).on("click", "#sell-btn-js", function (e) {
  let sell = $(this).attr("data-rownum");
  $("#" + sell).remove();
  console.log($(this).attr("data-rownum"));
});

$(document).on("click", ".btn-save", function (e) {
  loadValues();
});

function loadValues() {
  let mainArr = [];
  let tmpArr = [];
  var mainTable = $("#sells");
  var tr = mainTable.find("tbody tr");
  tr.each(function () {
    tmpArr = []; // has to clean on every found for take every td values into array
    $(this)
      .find("td")
      .each(function () {
        var values = $(this).find("input, select").val();
        var key = $(this).find("input, select").attr("name");
        console.log(key);

        if (values) tmpArr.push({ key, values });
      });
    mainArr.push(tmpArr);
  });
  console.log(mainArr);
  appendTableRow(mainArr);
  localStorage.setItem('tableData',JSON.stringify(mainArr));
}

function appendTableRow(arr) {
    $("#table-sell tbody").empty();
  if (arr && arr.length) {
    arr.forEach((item, index) => {
      let tr = '<tr>'
      let td = Object.keys(item);
      td.forEach((tdItem, tdIndex) => {
        console.log(item[tdItem]);
        tr +=
        //   `<td><input type="text" class="form-control" readonly placeholder="Product name" value=${item[tdItem].values}></td>`
          `<td>${item[tdItem].values}</td>`;
        
      });
      tr+='</tr>';
      $("#table-sell tbody").append(tr);
    });
    $(".table-data-js").removeClass('d-none');
  } else {
    $(".table-data-js").addClass('d-none');

  }
}
