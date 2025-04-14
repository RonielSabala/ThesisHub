function addEntity() {
    let entity = {
        title: $title.val(),
        projectDescription: $projectDescription.val(),
        registrationDate: $registrationDate.val(),
        projectStatus: $projectStatus.val(),
        studentId: $student.val()
    };

    return genericAddEntity(entity);
}

function loadSelect() {
    return genericBuildSelect(
        $student,
        localForeignKeyAPI,
        (student) => student.firstName + " " + student.lastName,
        "a student"
   );
}
