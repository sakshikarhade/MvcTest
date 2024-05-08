
$(document).ready(function () {
    GetInformationList();
});
var SaveInfo = function () {
    debugger;

    var id = $("#hdnId").val();
    var firstname = $("#FirstName").val();
    var lastname = $("#LastName").val();
    var dob = $("#DOB").val();
    var email = $("#Email").val();
    var phone = $("#Phone").val();

    var model = {

        Id: id,
        FirstName: firstname,
        LastName: lastname,
        DOB: dob,
        Email: email,
        Phone: phone,
    }
    $.ajax({
        url: "/Information/SaveInfo",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "Application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
        },
        error: function (response) {
            alert(response.Message);
        }
    });
}

var GetInformationList = function () {
    debugger;
    $.ajax({
        url: "/Information/GetInformationList",
        method: "Post",
        contentType: "Application/json;charset=utf-8",
        dataType: "json",
        async:false,
        success: function (response)

        {
            var html = "";

            $("#tblDetail tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Srno +
                    "</td><td>" + elementValue.Id +
                    "</td><td>" + elementValue.FirstName +
                    "</td><td>" + elementValue.LastName +
                    "</td><td>" + elementValue.DOB +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.Phone +
                    "</td></tr>"
            });

            $("#tblDetail tbody").append(html);
        }
    });
}