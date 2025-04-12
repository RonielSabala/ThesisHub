function addEntity() {
    let entity = {
        firstName: $firstName.val(),
        lastName: $lastName.val(),
        email: $email.val(),
        specialization: $specialization.val(),
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
