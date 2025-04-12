function loadEntity(id) {
    $.get(`${localAPI}/Get/${id}`, function (entity) {
        $deptName.text(entity.deptName);
        $facultyHead.text(entity.facultyHead);
        $email.text(entity.email);
    });
}
