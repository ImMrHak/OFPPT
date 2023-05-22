window.addEventListener("load", function () {
    document.querySelector("#nav_menu").childNodes[1].nextElementSibling.childNodes[3].childNodes[5].setAttribute("class", "active");
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
function UnlockToEdit() {
    document.getElementById("nom").removeAttribute("disabled");
    document.getElementById("prenom").removeAttribute("disabled");
    document.getElementById("nompere").removeAttribute("disabled");
    document.getElementById("prenompere").removeAttribute("disabled");
    document.getElementById("adresse").removeAttribute("disabled");
    document.getElementById("nomar").removeAttribute("disabled");
    document.getElementById("prenomar").removeAttribute("disabled");
    document.getElementById("nommere").removeAttribute("disabled");
    document.getElementById("prenommere").removeAttribute("disabled");
    document.getElementById("tel").removeAttribute("disabled");
    document.getElementById("email").removeAttribute("disabled");
    document.getElementById("btnmodifuser").textContent = "Valider Les Modifications";
    document.getElementById("btnmodifuser").setAttribute("class", "btn btn-success mb-3");
    document.getElementById("btnmodif").style.display = "none";
    document.getElementById("btnmodifuser").style.display = "block";
}
function ValidateEdit() {
    var nom = document.getElementById("nom").value;
    var prenom = document.getElementById("prenom").value;
    var nompere = document.getElementById("nompere").value;
    var prenompere = document.getElementById("prenompere").value;
    var adresse = document.getElementById("adresse").value;
    var nomar = document.getElementById("nomar").value;
    var prenomar = document.getElementById("prenomar").value;
    var nommere = document.getElementById("nommere").value;
    var prenommere = document.getElementById("prenommere").value;
    var tel = document.getElementById("tel").value;
    var email = document.getElementById("email").value;
    if (nom == "" || prenom == "" || nompere == "" || prenompere == "" || adresse == "" || nomar == "" || prenomar == "" || nommere == "" || prenommere == "" || tel == "" || email == "") {
        Message("error", "Veuillez remplir les champs !");
    }
    else {
        document.getElementById("nom").setAttribute("disabled", "disabled");
        document.getElementById("prenom").setAttribute("disabled", "disabled");
        document.getElementById("nompere").setAttribute("disabled", "disabled");
        document.getElementById("prenompere").setAttribute("disabled", "disabled");
        document.getElementById("adresse").setAttribute("disabled", "disabled");
        document.getElementById("nomar").setAttribute("disabled", "disabled");
        document.getElementById("prenomar").setAttribute("disabled", "disabled");
        document.getElementById("nommere").setAttribute("disabled", "disabled");
        document.getElementById("prenommere").setAttribute("disabled", "disabled");
        document.getElementById("tel").setAttribute("disabled", "disabled");
        document.getElementById("email").setAttribute("disabled", "disabled");
        $.ajax({
            url: 'UpdateUser',
            type: 'POST',
            data: {
                "nom": nom,
                "prenom": prenom,
                "nompere": nompere,
                "prenompere": prenompere,
                "adresse": adresse,
                "nomar": nomar,
                "prenomar": prenomar,
                "nommere": nommere,
                "prenommere": prenommere,
                "tel": tel,
                "email": email
            },
            success: function (response) {
                Message("success", "Vous avez changer vos informations avec succès !");
            },
            error: function (response) {
                Message("error", "Une erreur est survenue !");
            }
        });
        document.getElementById("btnmodif").style.display = "block";
        document.getElementById("btnmodifuser").style.display = "none";
    }
}