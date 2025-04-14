function fillEntityField(entity) {
    $title.val(entity.title);
    $projectDescription.val(entity.projectDescription);
    $registrationDate.val(entity.registrationDate);
    $projectStatus.val(entity.projectStatus);

    loadSelect(entity.studentId);
}

function loadSelect(mainOption) {
    return genericLoadSelect(
        mainOption,
        $student,
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

    return genericUpdateEntity(entity);
}
