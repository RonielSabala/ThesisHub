function genericDeleteEntity(id, apiUrl, routePrefix) {
    $.ajax({
        url: `${apiUrl}/Delete/${id}`,
        type: "DELETE",
        contentType: "application/json",
        success: (response) => succesResponse(response, routePrefix),
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}
