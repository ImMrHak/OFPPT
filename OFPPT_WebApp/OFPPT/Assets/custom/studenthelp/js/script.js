window.addEventListener("load", function () {
    document.querySelector("#nav_menu").childNodes[1].nextElementSibling.childNodes[3].childNodes[1].setAttribute("class", "active");
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
function Checker() {
    var typedemande = document.getElementById("typedemandes").value;
    var comment = document.getElementById("comments").value;
    if (typedemande == 0 || comment == "") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'Help',
            type: 'POST',
            data: {
                "typedemande": typedemande,
                "comment": comment
            },
            success: function (response) {
                Message("success", 'Votre message à été envoyer avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}