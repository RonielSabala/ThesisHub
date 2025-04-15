function getEntityRow(entity) {
    const fields = [
        entity.projectTitle,
        entity.tutorName,
        entity.tutorRole,
    ]

    return getRow(entity.id, fields);
}

function loadEntities() {
    let filter = $("#search").val();
    let isProject = $("#searchCategory").val();

    $.get(
        `${localAPI}/GetAll`,
        { filter: filter, filterProject: isProject }
    )
    .done(function (entities) {
        const rows = entities.map(getEntityRow).join('');
        $("#entityTable").html(rows);
    })
    .fail(showError);
}
