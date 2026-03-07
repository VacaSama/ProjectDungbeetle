// This block handles the Hints
document.addEventListener('DOMContentLoaded', function () {

    // HINT LOGIC
    const hints = window.dashboardHints || [];
    const toastElement = document.getElementById('toastHint');
    const hintBtn = document.getElementById('liveToastBtn');
    const hintText = document.getElementById('hintText');

    if (toastElement && hintBtn) {
        const toast = new bootstrap.Toast(toastElement);
        hintBtn.addEventListener('click', function () {
            if (hints.length > 0) {
                const randomHint = hints[Math.floor(Math.random() * hints.length)];
                hintText.innerText = randomHint;
                toast.show();
            }
        });
    }

    // This block handles the "Auto-Popup"
    // QUESTIONNAIRE AUTO-POPUP
    const qModal = document.getElementById("questionnaireModal");
    const isDone = localStorage.getItem("surveyFinished");

    if (qModal && typeof window.mustShowSurvey !== 'undefined') {
        if (window.mustShowSurvey === true && !isDone) {
            qModal.style.display = "flex";
        }
    }
});

// BUTTON FUNCTIONS Skipping the Questionnaire, Saving User Response and Dev Reset (Outside the block so HTML can find them)
function closeModal() {
    var modal = document.getElementById("questionnaireModal");
    if (modal) { modal.style.display = "none"; }
}

function saveProfile() {
    localStorage.setItem("surveyFinished", "true");
    var modal = document.getElementById("questionnaireModal");
    if (modal) { modal.style.display = "none"; }
}

// Make a DEV Reset button to test the questionnaire, clears the local storage and reloads the page
function resetQuest() {
    localStorage.removeItem("surveyFinished");
    location.reload();
}

/* *** Psedo-Region (Context of this file - Dashboard.js)
From w3 Schools =>
The window object is supported by all browsers. It represents the browser's window.

All global JavaScript objects, functions, and variables automatically become members of the window object.

Global variables are properties of the window object.

Global functions are methods of the window object.

Even the document object (of the HTML DOM) is a property of the window object:

window.document.getElementById("header");

is the same as:

document.getElementById("header");

*/