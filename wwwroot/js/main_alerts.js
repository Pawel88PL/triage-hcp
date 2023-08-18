
function endOfTrialInfo() {
    Swal.fire({
        icon: 'info',
        title: 'Korzystasz z darmowej wersji!',
        text: 'Darmowa wersja programu wygasa 30.09.2023.',
        footer: 'Aby dalej korzystać z programu wykup wersję płatną'
    });
}

function endOfTrialAlert() {
    Swal.fire({
        title: 'Przepraszamy, darmowa wersja wygasła',
        text: 'Aby dalej korzystać z programu wykup wersję płatną.',
        icon: 'warning',
    });
}