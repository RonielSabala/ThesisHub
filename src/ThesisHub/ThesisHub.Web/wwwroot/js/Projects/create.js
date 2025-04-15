function addEntity() {
    let entity = {
        title: $title.val(),
        projectDescription: $projectDescription.val(),
        registrationDate: formatDate(new Date()),
        projectStatus: $projectStatus.val(),
        studentId: $student.val()
    };

    return genericAddEntity(entity);
}

function formatDate(date) {
    let year = date.getFullYear();
    let month = String(date.getMonth() + 1).padStart(2, '0');
    let day = String(date.getDate()).padStart(2, '0');
    let hours = String(date.getHours()).padStart(2, '0');
    let minutes = String(date.getMinutes()).padStart(2, '0');
    let seconds = String(date.getSeconds()).padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}`;
}

function loadStudentSelect() {
    return genericBuildSelect(
        $student,
        localForeignKeyAPI,
        (student) => student.firstName + " " + student.lastName,
        "a student"
    );
}
