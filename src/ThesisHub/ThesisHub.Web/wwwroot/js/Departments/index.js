$(document).ready(function () {
    loadEntities();
});

function loadEntities() {
    return genericLoadEntities(localAPI, getEntityRow);
}

function getEntityRow(entity) {
    const fields = [
        entity.deptName,
        entity.facultyHead,
        entity.email,
    ]

    return getRow(entity.id, fields, localRoute);
}
