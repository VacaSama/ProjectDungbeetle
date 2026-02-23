document.addEventListener('DOMContentLoaded', () => {

    // retrieves the hints from the home/index-- Scripts section
    const hints = window.dashboardHints || [];

    // declaring variables from home/index
    const toast1 = document.getElementById('toastHint');
    const hint_btn = document.getElementById('liveToastBtn');
    const hint_txt = document.getElementById('hintText');

    if (!toast1 || !hint_btn) return; // safety guard, if there is no toast or hint button 
                                    // then don't do anything.

    const toast = new bootstrap.Toast(toast1); // retrieves the bootstrap needed for the toast

    // on-click event listener
    hint_btn.addEventListener('click', () => {
        // if there are no hints (if the length of the list is 0), do nothing
        if (hints.length === 0) return;

        // randomizes the hints using Math
        const randomHint = hints[Math.floor(Math.random() * hints.length)];
        // inserts the random hint into the blank hintText id
        hint_txt.innerText = randomHint;

        // shows the toast
        toast.show();
    });
});

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