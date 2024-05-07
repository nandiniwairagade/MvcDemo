$(document).ready(function () {
    GetRegistrationList();
    GetRegisterbyId();
    RedirectDetails();

});


var SaveReg = function () {
    debugger;
    var Id = $("#hdnid").val();
    var name = $("#textname").val();
    var mobile_no = $("#textmobileno").val();
    var address = $("#textaddress").val();
    var city = $("#textcity").val();

    if (name == "") {
        alert("please your name")
    }
    
    var model = {
        Id: Id,
        Name: name,
        Mobile_No: mobile_no,
        Address: address,
        City: city
    };
    $.ajax({
        url: "/mvc/SaveReg",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.message);
            GetRegistrationList();
        },
        error: function (response) {
            alert(response.message);
        }

    });
};

var GetRegistrationList = function () {
    debugger;
    $.ajax({
        url: "/mvc/GetRegistrationList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblregistration tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.srno +
                    "</td><td>" + elementValue.Id +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Mobile_No +
                    "</td><td>" + elementValue.Address +
                    "</td><td>" + elementValue.City +
                    "</td><td><input type='button' value='delete' class='btn btn-danger' onclick ='deleteregistration(" + elementValue.Id + ")'/>&nbsp<input type='button' value='Edit'class='btn btn-success' onclick ='GetRegisterbyId(" + elementValue.Id + ")'/>&nbsp<input type='button' value='Redirect deatils' class='btn btn-info' onclick =' details(" + elementValue.Id +")'/></td></tr>";
            });
            $("#tblregistration tbody").append(html);
        }
    });
}

var deleteregistration = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/mvc/deleteregistration",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
            GetRegistrationList();
        },
        error: function (response) {
            alert(response.model);
        }

    });
}
var GetRegisterbyId = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/mvc/GetRegisterbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            $("#hdnid").val(responce.model.Id);
            $("#textname").val(responce.model.Name);
            $("#textmobileno").val(responce.model.Mobile_No);
            $("#textaddress").val(responce.model.Address);
            $("#textcity").val(responce.model.City);
        }


    });
}
var details = function (Id) {

    window.location.href = "/mvc/detailsIndex?Id=" + Id;
}

var RedirectDetails = function () {

    var Id = $("#hdnid").val();
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/mvc/GetRegisterbyId",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            $("#hdnid").text(responce.model.Id);
            $("#textname").text(responce.model.Name);
            $("#textmobileno").text(responce.model.Mobile_No);
            $("#textaddress").text(responce.model.Address);
            $("#textcity").text(responce.model.City);
        }


    });
}
