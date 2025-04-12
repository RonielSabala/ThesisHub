$(document).ready(function () {
    loadEntities();
});

function loadEntities() {
    return genericLoadEntities(tutorAPI, getEntityRow);
}

function getEntityRow(entity) {
    const fields = [
        entity.firstName,
        entity.lastName,
        entity.email,
        entity.specialization,
        entity.deptName,
    ]

    return getRow(entity.id, fields, "Tutors");
}
