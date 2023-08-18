
$(document).ready(function () {
    var patientName = $("#patientName").val() || "";
    var patientSurname = $("#patientSurname").val() || "";
    var documentUrl = $("#patientDocumentUrl").val();

    Swal.fire({
        title: 'Pobieranie dokumentów',
        html: 'Czy chcesz pobrać dokumenty pacjenta <br><b>' + patientName.toUpperCase() + ' ' + patientSurname.toUpperCase() + '</b>?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'POBIERZ',
        cancelButtonText: 'ANULUJ'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = documentUrl;
        }
    });
});