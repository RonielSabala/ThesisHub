function fillEntityField(entity) {
    $firstName.val(entity.firstName);
    $lastName.val(entity.lastName);
    $email.val(entity.email);
    $phone.val(entity.phone);

    loadSelect(entity.departmentId);
}

function loadSelect(mainOption) {
    return genericLoadSelect(
        mainOption,
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

    return genericUpdateEntity(entity);
}
