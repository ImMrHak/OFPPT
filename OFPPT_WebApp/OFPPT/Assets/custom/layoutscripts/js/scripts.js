function Message(icon, message) {
    Swal.fire({
        position: 'top-end',
        icon: icon,
        title: message,
        showConfirmButton: true,
        timer: 1500
    })
}
function EditUser() {
    var pass = document.getElementById("pass").value;
    var repass = document.getElementById("repass").value;
    if (pass == "" || repass == "") {
        Message("error", "Veuillez remplir les champs !");
    }
    else if (pass != repass) {
        Message("error", "Vos mot de passes ne sont pas identiques !");
    }
    else {
        $.ajax({
            url: 'ChangePassword',
            type: 'POST',
            data: {
                "pass": pass,
                "repass": repass
            },
            success: function (response) {
                Message("success", "Vous avez changer votre mot de passe avec succès");
            },
            error: function (response) {
                Message("success", "Vous avez changer votre mot de passe avec succès");
            }
        });
    }
}