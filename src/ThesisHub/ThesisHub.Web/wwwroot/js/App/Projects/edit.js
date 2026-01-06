function fillEntityField(entity) {
    $title.val(entity.title);
    $projectDescription.val(entity.projectDescription);
    $registrationDate.val(entity.registrationDate);

    genericLoadStatusSelect($projectStatus, entity.projectStatus);
    genericLoadSelect(
        $student,
        entity.studentId,
        localForeignKeyAPI,
        (student) => student.firstName + " " + student.lastName
    );
}

function updateEntity(id) {
    let entity = {
        id: id,
        title: $title.val(),
        projectDescription: $projectDescription.val(),
        registrationDate: $registrationDate.val(),
        projectStatus: $projectStatus.val(),
        studentId: $student.val()
    };

    genericUpdateEntity(entity);
}
