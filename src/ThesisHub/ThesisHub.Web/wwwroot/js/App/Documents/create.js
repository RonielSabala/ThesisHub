function addEntity() {
    let entity = {
        docName: $docName.val(),
        filePath: $filePath.val(),
        uploadDate: formatDate(new Date()),
        docStatus: $docStatus.val(),
        projectId: $project.val()
    };

    genericAddEntity(entity);
}

function loadProjectSelect() {
    genericBuildSelect(
        $project,
        localForeignKeyAPI,
        (project) => project.title,
        "a project"
    );
}
