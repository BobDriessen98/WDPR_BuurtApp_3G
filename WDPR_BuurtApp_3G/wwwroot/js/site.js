// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function likeMelding(meldingID, userID) {
    const like = {
        UserID: userID,
        MeldingID: meldingID
}
fetch('/api/Likes', {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify(like)
})
    }

