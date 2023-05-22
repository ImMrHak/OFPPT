window.addEventListener("load", function () {
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
function AddDirect() {
    var cin = document.getElementById("cindirect").value;
    var pass = document.getElementById("passdirect").value;
    var nom = document.getElementById("nomdirect").value;
    var prenom = document.getElementById("prenomdirect").value;
    var email = document.getElementById("emaildirect").value;
    var etablissement = document.getElementById("etablissementdirect").value;
    if (cin == "" || pass == "" || nom == "" || prenom == "" || email == "" || etablissement == 0) {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'AddDirect',
            type: 'POST',
            data: {
                "cin": cin,
                "pass": pass,
                "nom": nom,
                "prenom": prenom,
                "email": email,
                "etablissement": etablissement
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter un administrateur avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddEpreuve() {
    var epreuvenom = document.getElementById("epreuvenom").value;
    var datedebutepreuve = document.getElementById("datedebutepreuve").value;
    var datefinepreuve = document.getElementById("datefinepreuve").value;
    var choixbranche = document.getElementById("choixbranche").value;
    if (epreuvenom == "" || datedebutepreuve == "" || datefinepreuve == "" || choixbranche == 0) {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'AddEpreuve',
            type: 'POST',
            data: {
                "epreuvenom": epreuvenom,
                "datedebutepreuve": datedebutepreuve,
                "datefinepreuve": datefinepreuve,
                "choixbranche": choixbranche
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter une epreuve avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddVille() {
    var villee = document.getElementById("villee").value;
    if (villee == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddVille',
            type: 'POST',
            data: {
                "villee": villee
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter une ville avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddEtablissement() {
    var etab = document.getElementById("etab").value;
    if (etab == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddEtablissement',
            type: 'POST',
            data: {
                "etab": etab
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter un etablissement avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AdddNvFormation() {
    var nvforma = document.getElementById("nvforma").value;
    if (nvforma == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddNvFormation',
            type: 'POST',
            data: {
                "nvforma": nvforma
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter un niveaux de formation avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddCategorie() {
    var categoriee = document.getElementById("categoriee").value;
    if (categoriee == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddCategorie',
            type: 'POST',
            data: {
                "categoriee": categoriee
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter une categorie avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddBranche() {
    var branchee = document.getElementById("branchee").value;
    if (branchee == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddBranche',
            type: 'POST',
            data: {
                "branchee": branchee
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter une branche avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddTypeFormation() {
    var tyformation = document.getElementById("tyformation").value;
    if (tyformation == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddTypeFormation',
            type: 'POST',
            data: {
                "tyformation": tyformation
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter un type de fomation avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddScolarite() {
    var scolarite = document.getElementById("scolarite").value;
    if (scolarite == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddScolarite',
            type: 'POST',
            data: {
                "scolarite": scolarite
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter une scolarite avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}

function AddChoix() {
    var choix = document.getElementById("choix").value;
    if (choix == "") {
        Message("error", 'Veuillez remplir le champ');
    }
    else {
        $.ajax({
            url: 'AddChoix',
            type: 'POST',
            data: {
                "choix": choix
            },
            success: function (response) {
                Message("success", 'Vous avez ajouter un choix avec succès!');
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}