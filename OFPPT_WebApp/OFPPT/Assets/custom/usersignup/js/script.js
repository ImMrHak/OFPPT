function Message(icon, message) {
    Swal.fire({
        position: 'top-end',
        icon: icon,
        title: message,
        showConfirmButton: true,
        timer: 1500
    })
}
function Step1() {
    var cin = document.getElementById("cin").value;
    var cne = document.getElementById("cne").value;
    var dtnaiss = document.getElementById("dtnaiss").value;
    var email = document.getElementById("email").value;
    if (cin == "" || cne == "" || dtnaiss == "" || email == "") {
        Message("error", 'Veuillez remplir les champs');
    } else {
        document.getElementById("step1").click();
    }
}

function Step2() {
    var nom = document.getElementById("nom").value;
    var prenom = document.getElementById("prenom").value;
    var nomar = document.getElementById("nomar").value;
    var prenomar = document.getElementById("prenomar").value;
    var adresse = document.getElementById("adresse").value;
    var numtel = document.getElementById("numtel").value;
    var natio = document.getElementById("natio").value;
    var genre = document.getElementById("genre").value;
    var mgbac = document.getElementById("mgbac").value;
    var nompere = document.getElementById("nompere").value;
    var prenompere = document.getElementById("prenompere").value;
    var cinpere = document.getElementById("cinpere").value;
    var nommere = document.getElementById("nommere").value;
    var prenommere = document.getElementById("prenommere").value;
    var cinmere = document.getElementById("cinmere").value;
    var ville = document.getElementById("ville").value;
    if (nom == "" || prenom == "" || nomar == "" || prenomar == "" || adresse == "" || numtel == "" || natio == "" || genre == "" || mgbac == "" || nompere == "" || prenompere == "" || cinpere == "" || nommere == "" || prenommere == "" || cinmere == "" || ville == "0") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        document.getElementById("step2").click();
    }
}

function Step3() {
    var cin = document.getElementById("cin").value;
    var cne = document.getElementById("cne").value;
    var dtnaiss = document.getElementById("dtnaiss").value;
    var email = document.getElementById("email").value;
    var nom = document.getElementById("nom").value;
    var prenom = document.getElementById("prenom").value;
    var nomar = document.getElementById("nomar").value;
    var prenomar = document.getElementById("prenomar").value;
    var adresse = document.getElementById("adresse").value;
    var numtel = document.getElementById("numtel").value;
    var natio = document.getElementById("natio").value;
    var genre = document.getElementById("genre").value;
    var mgbac = document.getElementById("mgbac").value;
    var nompere = document.getElementById("nompere").value;
    var prenompere = document.getElementById("prenompere").value;
    var cinpere = document.getElementById("cinpere").value;
    var nommere = document.getElementById("nommere").value;
    var prenommere = document.getElementById("prenommere").value;
    var cinmere = document.getElementById("cinmere").value;
    var ville = document.getElementById("ville").value;
    var nvscolarite = document.getElementById("nvscolarite").value;
    var categorie = document.getElementById("categorie").value;
    var branche = document.getElementById("branche").value;
    var ville1 = document.getElementById("ville1").value;
    var etablissement = document.getElementById("etablissement").value;
    var typeformation = document.getElementById("typeformation").value;
    var nvformation = document.getElementById("nvformation").value;
    var firstchoice = document.getElementById("firstchoice").value;
    var secondchoice = document.getElementById("secondchoice").value;
    var thirdchoice = document.getElementById("thirdchoice").value;
    if (nvscolarite == "0" || categorie == "0" || branche == "0" || ville1 == "0" || etablissement == "0" || typeformation == "0" || nvformation == "0" || firstchoice == "0" || secondchoice == "0" || thirdchoice == "0") {
        Message("error", 'Veuillez remplir les champs');
    }
    else {
        $.ajax({
            url: 'SignUp',
            type: 'POST',
            data: {
                "cin": cin,
                "cne": cne,
                "dtnaiss": dtnaiss,
                "email": email,
                "nom": nom,
                "prenom": prenom,
                "nomar": nomar,
                "prenomar": prenomar,
                "adresse": adresse,
                "numtel": numtel,
                "natio": natio,
                "genre": genre,
                "mgbac": mgbac,
                "nompere": nompere,
                "prenompere": prenompere,
                "cinpere": cinpere,
                "nommere": nommere,
                "prenommere": prenommere,
                "cinmere": cinmere,
                "ville": ville,
                "nvscolarite": nvscolarite,
                "categorie": categorie,
                "branche": branche,
                "ville1": ville1,
                "etablissement": etablissement,
                "typeformation": typeformation,
                "nvformation": nvformation,
                "firstchoice": firstchoice,
                "secondchoice": secondchoice,
                "thirdchoice": thirdchoice
            },
            success: function (response) {
                Message("success", 'Votre compte à été creer avec succès!');
                document.getElementById("step3").click();
                document.getElementById("cin").textContent = cin;
                document.getElementById("motpass").textContent = cin;
                Message("info", 'Vous allez être redirigé vers la page de connexion');
                setTimeout(function () {
                    window.location.href='SignIn'
                }, 5000);
            },
            error: function (response) {
                Message("error", 'Une erreur est survenue !');
            }
        });
    }
}