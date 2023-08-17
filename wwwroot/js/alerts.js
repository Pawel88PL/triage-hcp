document.addEventListener('DOMContentLoaded', function () {
    endOfTrialRemainder();
});

function endOfTrialAlert() {
    Swal.fire({
        title: 'Przepraszamy, darmowa wersja wygasła',
        text: 'Aby dalej korzystać z programu wykup wersję płatną.',
        icon: 'warning',
    });
}

function endOfTrialInfo() {
    Swal.fire({
        icon: 'info',
        title: 'Korzystasz z darmowej wersji!',
        text: 'Darmowa wersja programu wygasa 30.09.2023.',
        footer: 'Aby dalej korzystać z programu wykup wersję płatną'
    });
}


function endOfTrialDate() {
    const trialEndDate = new Date('2023-09-30');

    const currentDate = new Date();
    const timeDiff = trialEndDate - currentDate;
    const daysDiff = Math.ceil(timeDiff / (1000 * 60 * 60 * 24));

    return daysDiff;
}

function endOfTrialRemainder() {
    const daysLeft = endOfTrialDate();

    Swal.fire({
        icon: 'info',
        title: 'Korzystasz z darmowej wersji!',
        text: `Darmowa wersja programu wygasa za ${daysLeft} dni.`,
        footer: 'Aby dalej korzystać z programu wykup wersję płatną'
    });
}
