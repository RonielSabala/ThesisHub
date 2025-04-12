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
