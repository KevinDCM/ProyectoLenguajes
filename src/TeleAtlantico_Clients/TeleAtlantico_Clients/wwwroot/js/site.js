
$(document).ready(function () {

    //LoadData();
});

function Add() {


    if (/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(document.getElementById("emaillog").value)) {

        var client = {

            name: $('#namelog').val(),
            firstsurname: $('#firstsurnamelog').val(),
            secondsurname: $('#secondsurnamelog').val(),
            email: $('#emaillog').val(),
            password: $('#passwordlog').val(),
            phonenumber: $('#phonelog').val(),
            secondcontact: $('#secondcontactlog').val(),
            fulladdress: $('#adresslog').val()

        };

        $.ajax({
            url: "/Home/Insert",
            data: JSON.stringify(client),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                document.getElementById('namelog').value = '';
                document.getElementById('namelog').value = ''
                document.getElementById('firstsurnamelog').value = ''
                document.getElementById('secondsurnamelog').value = ''
                document.getElementById('emaillog').value = ''
                document.getElementById('passwordlog').value = ''
                document.getElementById('phonelog').value = ''
                document.getElementById('secondcontactlog').value = ''
                document.getElementById('adresslog').value = ''

                alert("client succesfully registered !");
                window.location.href = "https://www.telcel.com/personas/atencion-a-clientes/puntos-de-contacto";
                return false;
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });

    } else {
        alert("You have entered an invalid email address!")
        return false;
    }


}

function login() {


    if (/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(document.getElementById("emailsign").value)) {

        var client = {


            email: $('#emailsign').val(),
            password: $('#passsign').val()

        };

        $.ajax({
            url: "/Home/Validate",
            data: JSON.stringify(client),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                console.log(result);

                if (result == 1) {
                    alert("client succesfully registered !");
                    window.location.href = "https://www.telcel.com/personas/atencion-a-clientes/puntos-de-contacto";
                } else {
                    alert("email / password is incorrect!");
                    document.getElementById('passsign').value = '';
                }


                return false;
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });

    } else {
        alert("You have entered an invalid email address!")
        return false;
    }

}


function LoadData() {
    //$.ajax({
    //    url: "/Student/GetStudents",
    //    type: "GET",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //    success: function (result) {
    //        var html = '';
    //        $.each(result, function (key, item) {
    //            html += '<tr>';
    //            html += '<td>' + item.studentId + '</td>';
    //            html += '<td> <div contenteditable>' + item.name + '</td>';
    //            html += '<td> <div contenteditable>' + item.email + '</td>';
    //            html += '<td> <div contenteditable>' + item.password + '</td>';
    //            html += '<td> <a onclick="return Update(' + item.studentId + ')">Edit</a> | <a onclick="return Delete(' + item.studentId + ')">Delete</a>  </td>';
    //        });
    //        $('.tbody').html(html);

    //    },
    //    error: function (errorMessage) {
    //        alert(errorMessage.responseText);
    //    }
    //})

}

