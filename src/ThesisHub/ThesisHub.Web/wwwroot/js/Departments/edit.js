function fillEntityField(entity) {
    $deptName.val(entity.deptName);
    $facultyHead.val(entity.facultyHead);
    $email.val(entity.email);
}

function updateEntity(id) {
    let entity = {
        id: id,
        deptName: $deptName.val(),
        facultyHead: $facultyHead.val(),
        email: $email.val()
    };

    return genericUpdateEntity(entity);
}
