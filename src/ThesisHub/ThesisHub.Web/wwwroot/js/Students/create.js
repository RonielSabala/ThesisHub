function addEntity() {
    let entity = {
        firstName: $firstName.val(),
        lastName: $lastName.val(),
        email: $email.val(),
        phone: $phone.val(),
        departmentId: $department.val()
    };

    return genericAddEntity(entity, studentAPI, "Students");
}

function loadSelect() {
    return genericBuildSelect(
        $department,
        departmentAPI,
        (department) => department.deptName
   );
}
