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
    if (cin == "") {
        document.getElementById("cin").setAttribute("class", "text-danger");
        Message("error", "Veuillez entrer votre cin !");
    }
    else {
        document.getElementById("cin").setAttribute("class", "text-success");
        $.ajax({
            url: 'Recover',
            type: 'POST',
            data: {
                "cin": cin
            },
            success: function (response) {
                Message("success", "Veuillez verifier votre boîte de réception  !")
            },
            error: function (response) {
                Message("error", "Une erreur est survenue !")
            }
        });
    }
}