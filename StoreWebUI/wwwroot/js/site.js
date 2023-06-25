// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addProduct() {
    const name = document.getElementById("product").value;
    const price = document.getElementById("price").value;
    const quantity = document.getElementById("quantity").value;

    let obj = {
        "id": 0,
        "name": name,
        "price": Number(price),
        "quantity": Number(quantity)
    };
    console.log(obj);

    $.ajax({
        url: "https://localhost:22950/p",
        method: "POST",
        data: obj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            CallGetAll();
            location.href = 'https://localhost:7189/';
            alert("Product Added Successfully");
        },
        error: function (data) {
            console.log(data);
        }
    })
}

function CallGetAll() {
    $.ajax({
        url: "https://localhost:22950/p",
        method: "GET",
        success: function (data) {

            let content = "";
            for (var i = 0; i < data.length; i++) {
                let item = `
<div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">${data[i].name}</h5>
    <p class="card-text">${data[i].price}$</p>
    <a href="#" class="btn btn-primary">Select Product</a>
  </div>
</div>
`;
                content += item;
            }
            console.log(data);
            $("#products").html(content);
        }
    })
}