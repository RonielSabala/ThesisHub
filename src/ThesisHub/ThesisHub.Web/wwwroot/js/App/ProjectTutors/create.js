function addEntity() {
    let entity = {
        projectId: $project.val(),
        tutorId: $tutor.val(),
        tutorRole: $tutorRole.val(),
    };

    genericAddEntity(entity);
}

function loadProjectSelect() {
    genericBuildSelect(
        $project,
        localForeignKeyAPI1,
        (project) => project.title,
        "the project"
    );
}

function loadTutorSelect() {
    genericBuildSelect(
        $tutor,
        localForeignKeyAPI2,
        (tutor) => tutor.firstName + " " + tutor.lastName,
        "the tutor"
    );
}
