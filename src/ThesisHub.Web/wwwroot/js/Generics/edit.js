function loadFormEntity(id) {
    $.get(`${localAPI}/Get/${id}`, function (entity) {
        fillEntityField(entity);
    });
}

function genericUpdateEntity(entity) {
    $.ajax({
        url: `${localAPI}/Update`,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(entity),
        success: (response) => succesResponse(response, localRoutePrefix),
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}
