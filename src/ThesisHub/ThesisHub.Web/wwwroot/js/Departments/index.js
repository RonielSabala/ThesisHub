$(document).ready(function () {
    genericLoadEntities(departmentAPI, getEntityRow);
});

function getEntityRow(entity) {
    const fields = [
        entity.deptName,
        entity.facultyHead,
        entity.email,
    ]

    return getRow(entity.id, fields, "Departments");
}
