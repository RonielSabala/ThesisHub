function loadEntity(id) {
    $.get(`${tutorAPI}/Get/${id}`, function (entity) {
        $firstName.text(entity.firstName);
        $lastName.text(entity.lastName);
        $email.text(entity.email);
        $specialization.text(entity.specialization);
        $department.text(entity.deptName);
    });
}
