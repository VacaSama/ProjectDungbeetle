//  Make sure JS runs AFTER the HTML exists --> addEventListener w/
// 'DOMContentLoaded makes sure of that

document.addEventListener('DOMContentLoaded', function () {
    // This block handles the Hints
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

    // USER PROFILE MATCHING

    // Occupation dropdown
    document.querySelectorAll('.occupation-option').forEach(item => {
        item.addEventListener('click', function () {
            const value = this.getAttribute('data-value');
            document.getElementById('occupation-input').value = value;
        });
    });
    // ENABLES THE READONLY-DISABLED ATTRIBUTES FROM INPUT ON CLICK
    document.getElementById('enable-changes').addEventListener('click', function () {
        document.querySelectorAll('.questionnaire-input').forEach(input => {
            input.removeAttribute('readonly');
        });
    });


    // Experience dropdown
    document.querySelectorAll('.experience-option').forEach(item => {
        item.addEventListener('click', function () {
            const value = this.getAttribute('data-value');
            document.getElementById('experience-input').value = value;
        });
    });
}); 

function loadEntryForEdit(id) {
    fetch(`/Home/GetEntry/${id}`)
        .then(res => res.json())
        .then(entry => {
            // Fill the modal fields
            document.getElementById("entry-id").value = entry.id;
            document.getElementById("Entry_Title").value = entry.title;
            document.getElementById("Entry_CodingLanguage").value = entry.codingLanguage;
            document.getElementById("Entry_CodeSnippet").value = entry.codeSnippet;
            document.getElementById("Entry_ErrorDescription").value = entry.errorDescription;
            document.getElementById("Entry_Notes").value = entry.notes;

            // Change modal title + button text
            document.getElementById("newEntryLabel").innerText = "Edit Entry";
            document.querySelector("#entryForm button[type='submit']").innerText = "Save Changes";

            // Change form action to UpdateEntry
            document.getElementById("entryForm").setAttribute("action", "/Home/UpdateEntry");
        });
}
function resetEntryModal() {
    document.getElementById("entry-id").value = "";
    document.getElementById("Entry_Title").value = "";
    document.getElementById("Entry_CodingLanguage").value = "";
    document.getElementById("Entry_CodeSnippet").value = "";
    document.getElementById("Entry_ErrorDescription").value = "";
    document.getElementById("Entry_Notes").value = "";

    document.getElementById("newEntryLabel").innerText = "New Entry";
    document.querySelector("#entryForm button[type='submit']").innerText = "Add";

    document.getElementById("entryForm").setAttribute("action", "/Home/AddEntry");
}


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
    // This is a security measure, while in development if I want
    // to reset the questionnaire for testing that I am sure I want to reset
        const devReset = confirm("Are you sure you want to reset: **QUESTIONNAIRE DATA**");

    // if the user confirms then the finished survery cache will be removed
        localStorage.removeItem("surveyFinished");
    // the application will reload
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