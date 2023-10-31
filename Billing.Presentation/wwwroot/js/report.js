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
          `<td>${item[tdItem]}</td>`;
        
      });
      tr+='</tr>';
      $("#table-sell tbody").append(tr);
    });
    $(".table-data-js").removeClass('d-none');
  } else {
    $(".table-data-js").addClass('d-none');

  }
}

$( document ).ready(function() {
    let tableData=localStorage.getItem("tableData");
    if(tableData !== null){
        tableData = JSON.parse(tableData);
        appendTableRow(tableData);
        
    }
    console.log( "ready!" );
});