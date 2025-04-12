function addEntity() {
    let entity = {
        firstName: $firstName.val(),
        lastName: $lastName.val(),
        email: $email.val(),
        phone: $phone.val(),
        departmentId: $department.val()
    };

    return genericAddEntity(entity);
}

function loadSelect() {
    return genericBuildSelect(
        $department,
        localForeignKeyAPI,
        (department) => department.deptName
   );
}
