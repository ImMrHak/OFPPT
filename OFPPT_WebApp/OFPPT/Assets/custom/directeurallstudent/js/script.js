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

function DelStudent() {
    var cin = document.getElementById("cin").value;
    $.ajax({
        url: 'DelStudent',
        type: 'POST',
        data: {
            "cin": cin
        },
        success: function (response) {
            Message("success", 'Votre etudiant a ete supprimer avec succès!');
        },
        error: function (response) {
            Message("error", 'Une erreur est survenue !');
        }
    });
}

function ValidateStudent() {
    var cin = document.getElementById("cin").value;
    var choixvalide = document.getElementById("choixvalide").value;
    if (choixvalide == 0) {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'ValidateStudent',
            type: 'POST',
            data: {
                "cin": cin,
                "ch_ID": choixvalide
            },
            success: function (response) {
                Message("success", 'Votre etudiant a ete valider avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function EditStudent() {
    var cin = document.getElementById("cin").value;
    var genre = document.getElementById("genreee").value;
    var natio = document.getElementById("natiooo").value;
    var dtnaiss = document.getElementById("dtnaissss").value;
    var cne = document.getElementById("cneee").value;
    var categorie = document.getElementById("categorieee").value;
    var scolarite = document.getElementById("scolariteee").value;
    var branche = document.getElementById("brancheee").value;
    var etabl = document.getElementById("etablll").value;
    if (genre == "" || natio == "" || dtnaiss == "" || cne == "" || categorie == "" || scolarite == "" || branche == "" || etabl == "") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'DirecteurEditStudent',
            type: 'POST',
            data: {
                "cin": cin,
                "genre": genre,
                "natio": natio,
                "dtnaiss": dtnaiss,
                "cne": cne,
                "c_ID": categorie,
                "s_ID": scolarite,
                "b_ID": branche,
                "e_ID": etabl
            },
            success: function (response) {
                Message("success", 'Votre etudiant a ete modifier avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}