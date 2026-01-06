function genericAddEntity(entity) {
    $.ajax({
        url: `${localAPI}/Add`,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(entity),
        success: (response) => succesResponse(response, localRoutePrefix),
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}

function formatDate(date) {
    let year = date.getFullYear();
    let month = String(date.getMonth() + 1).padStart(2, '0');
    let day = String(date.getDate()).padStart(2, '0');
    let hours = String(date.getHours()).padStart(2, '0');
    let minutes = String(date.getMinutes()).padStart(2, '0');
    let seconds = String(date.getSeconds()).padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}`;
}
