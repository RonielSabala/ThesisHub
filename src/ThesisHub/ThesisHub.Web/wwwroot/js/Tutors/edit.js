function fillEntityField(entity) {
    $firstName.val(entity.firstName);
    $lastName.val(entity.lastName);
    $email.val(entity.email);
    $specialization.val(entity.specialization);

    genericLoadSelect(
        entity.departmentId,
        $department,
        localForeignKeyAPI,
        (department) => department.deptName
    );
}

function updateEntity(id) {
    let entity = {
        id: id,
        firstName: $firstName.val(),
        lastName: $lastName.val(),
        email: $email.val(),
        specialization: $specialization.val(),
        departmentId: $department.val()
    };

    genericUpdateEntity(entity);
}
