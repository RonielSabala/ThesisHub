$(document).ready(function () {
    genericLoadEntities(studentAPI, getEntityRow);
});

function getEntityRow(entity) {
    const fields = [
        entity.firstName,
        entity.lastName,
        entity.email,
        entity.phone,
        entity.deptName,
    ]

    return getRow(fields, "Students", entity.id);
}
