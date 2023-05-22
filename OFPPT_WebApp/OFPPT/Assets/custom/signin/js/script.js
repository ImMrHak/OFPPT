function Message(icon, message) {
    Swal.fire({
        position: 'top-end',
        icon: icon,
        title: message,
        showConfirmButton: true,
        timer: 1500
    })
}
function Checker() {
    var cin = document.getElementById("cin").value;
    var pass = document.getElementById("pass").value;
    if (cin == "" & pass == "") {
        document.getElementById("cin").setAttribute("class", "text-danger");
        document.getElementById("pass").setAttribute("class", "text-danger");
        Message("error", "Veuillez remplir les champs !")
    }
    else if (cin != "" & pass == "") {
        document.getElementById("cin").setAttribute("class", "text-success");
        document.getElementById("pass").setAttribute("class", "text-danger");
    }
    else if (cin == "" & pass != "") {
        document.getElementById("cin").setAttribute("class", "text-danger");
        document.getElementById("pass").setAttribute("class", "text-success");
    }
    else {
        document.getElementById("cin").setAttribute("class", "text-success");
        document.getElementById("pass").setAttribute("class", "text-success");
    }
}