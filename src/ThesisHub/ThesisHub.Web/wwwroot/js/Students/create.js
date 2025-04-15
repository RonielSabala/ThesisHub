function addEntity() {
    let entity = {
        firstName: $firstName.val(),
        lastName: $lastName.val(),
        email: $email.val(),
        phone: $phone.val(),
        departmentId: $department.val()
    };

    genericAddEntity(entity);
}

function loadSelect() {
   genericBuildSelect(
        $department,
        localForeignKeyAPI,
        (department) => department.deptName,
        "a department"
   );
}
