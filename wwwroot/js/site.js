// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function checkAndShowModal() { 
    // check Local Storage to see if the user has been here before 
    const hasCompletedQuest = localStorage.getItem("user_completed_quest");


    // if the user has NOT completed the questionnaire, show the modal 
    if (!hasCompletedQuest) { 
        // try to grab the modal elements
        // the questions
        // the user response

        // display the questions onto the modal

        // open the modal 
    }
}

// create a function that restarts the questionnaire prompt, and clears it from the local storage
function resetQuest() {
} 