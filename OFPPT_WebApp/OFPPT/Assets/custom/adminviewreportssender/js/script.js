function Message(icon, message) {
    Swal.fire({
        position: 'top-end',
        icon: icon,
        title: message,
        showConfirmButton: true,
        timer: 1500
    })
}
function SendResponse() {
    var sujet = document.getElementById("sujet").value;
    var reponse = document.getElementById("reponse").value;
    var idedemande = document.getElementById("idedemande").value;
    if (sujet == "" || reponse == "" || idedemande == "") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'SendResponse',
            type: 'POST',
            data: {
                "sujet": sujet,
                "reponse": reponse,
                "idedemande": idedemande
            },
            success: function (response) {
                Message("success", 'Vous avez envoyer la reponse avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}