function genericAddEntity(entity, apiUrl, routePrefix) {
    $.ajax({
        url: `${apiUrl}/Add`,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(entity),
        success: (response) => succesResponse(response, routePrefix),
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}
