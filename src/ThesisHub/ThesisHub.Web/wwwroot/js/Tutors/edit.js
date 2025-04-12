function loadFormEntity(id) {
    $.get(`${tutorAPI}/Get/${id}`, function (entity) {
        $firstName.val(entity.firstName);
        $lastName.val(entity.lastName);
        $email.val(entity.email);
        $specialization.val(entity.specialization);

        loadSelect(entity.departmentId);
    });
}

function loadSelect(mainOption) {
    return genericLoadSelect(
        mainOption,
        $department,
        departmentAPI,
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

    return genericUpdateEntity(entity, tutorAPI, "Tutors");
}
