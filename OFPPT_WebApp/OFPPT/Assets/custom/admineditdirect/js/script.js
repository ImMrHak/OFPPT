window.addEventListener("load", function () {
    document.querySelector("#nav_menu").childNodes[5].childNodes[3].childNodes[1].setAttribute("class", "active");
});
function Message(icon, message) {
    Swal.fire({
        position: 'top-end',
        icon: icon,
        title: message,
        showConfirmButton: true,
        timer: 1500
    })
}
function EditDirect() {
    var cin = document.getElementById("cin").value;
    var pass = document.getElementById("pass").value;
    var email = document.getElementById("email").value;
    var nom = document.getElementById("nom").value;
    var prenom = document.getElementById("prenom").value;
    var e_id = document.getElementById("etabl").value;

    if (cin == "" || pass == "" || email == "" || nom == "" || prenom == "") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'EditDirect',
            type: 'POST',
            data: {
                "cin": cin,
                "pass": pass,
                "email": email,
                "nom": nom,
                "prenom": prenom,
                "e_id": e_id
            },
            success: function (response) {
                Message("success", 'Votre modification a ete modifier avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}
function DelDirect() {
    var cin = document.getElementById("cinval").value;
    $.ajax({
        url: 'DelDirect',
        type: 'POST',
        data: {
            "cin": cin,
        },
        success: function (response) {
            Message("success", 'Vous avez supprimer un directeur avec succès!');
        },
        error: function (response) {
            Message("error", 'Une erreur est survenue !');
        }
    });
}