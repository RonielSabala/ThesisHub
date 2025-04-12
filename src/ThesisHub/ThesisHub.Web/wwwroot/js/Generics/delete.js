function DeleteEntity(id) {
    $.ajax({
        url: `${localAPI}/Delete/${id}`,
        type: "DELETE",
        contentType: "application/json",
        success: (response) => succesResponse(response, localRoutePrefix),
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}
