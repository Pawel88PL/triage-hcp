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

function endOfTrialDate() {
    const trialEndDateStr = document.querySelector('span[data-end-trial-date]').getAttribute('data-end-trial-date');
    const trialEndDate = new Date(trialEndDateStr);

    const currentDate = new Date();
    const timeDiff = trialEndDate - currentDate;
    const daysDiff = Math.ceil(timeDiff / (1000 * 60 * 60 * 24));

    return daysDiff;
}

function endOfTrialRemainder() {
    const daysLeft = endOfTrialDate();

    if (daysLeft <= 0) {
        endOfTrialAlert();
    } else {
        Swal.fire({
            icon: 'info',
            title: 'Korzystasz z darmowej wersji!',
            text: `Darmowa wersja programu wygasa za ${daysLeft} dni.`,
            footer: 'Aby dalej korzystać z programu wykup wersję płatną'
        });
    }
}