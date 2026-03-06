// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById("questionnaireModal");

    // Check LocalStorage to see if they've finished it before
    const isDone = localStorage.getItem("surveyFinished");

    if (!isDone) {
        // Show the modal if they haven't finished it
        modal.style.display = "flex";
    }
});

function closeModal() {
    // Just hides the modal. 
    // Since we DON'T set "surveyFinished", it will pop up again next refresh!
    document.getElementById("questionnaireModal").style.display = "none";
}

function saveProfile() {
    // Logic to save data...
    // Then set the flag so it stays hidden forever
    localStorage.setItem("surveyFinished", "true");
    document.getElementById("questionnaireModal").style.display = "none";
}

// create a function that restarts the questionnaire prompt, and clears it from the local storage
function resetQuest() {
} 