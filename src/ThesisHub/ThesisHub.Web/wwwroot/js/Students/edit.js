function fillEntityField(entity) {
    $firstName.val(entity.firstName);
    $lastName.val(entity.lastName);
    $email.val(entity.email);
    $phone.val(entity.phone);

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
        phone: $phone.val(),
        departmentId: $department.val()
    };

    genericUpdateEntity(entity);
}
