window.addEventListener("load", function () {
    document.querySelector("#nav_menu").childNodes[1].nextElementSibling.childNodes[3].childNodes[9].setAttribute("class", "active");
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
function SendRinscri() {
    var ville = document.getElementById("ville").value;
    var etablissement = document.getElementById("etablissement").value;
    var typeformation = document.getElementById("typeformation").value;
    var firstchoice = document.getElementById("firstchoice").value;
    var secondchoice = document.getElementById("secondchoice").value;
    var thirdchoice = document.getElementById("thirdchoice").value;
    if (ville == "0" || etablissement == "0" || typeformation == "0" || firstchoice == "0" || secondchoice == "0" || thirdchoice == "0") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'Register',
            type: 'POST',
            data: {
                "ville": ville,
                "etablissement": etablissement,
                "typeformation": typeformation,
                "firstchoice": firstchoice,
                "secondchoice": secondchoice,
                "thirdchoice": thirdchoice
            },
            success: function (response) {
                Message("success", 'Votre re-inscription a été validée!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }

}