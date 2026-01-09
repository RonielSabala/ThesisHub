function addEntity() {
    let entity = {
        title: $title.val(),
        projectDescription: $projectDescription.val(),
        registrationDate: formatDate(new Date()),
        projectStatus: $projectStatus.val(),
        studentId: $student.val()
    };

    genericAddEntity(entity);
}

function loadStudentSelect() {
    genericBuildSelect(
        $student,
        localForeignKeyAPI,
        (student) => student.firstName + " " + student.lastName,
        "a student"
    );
}
