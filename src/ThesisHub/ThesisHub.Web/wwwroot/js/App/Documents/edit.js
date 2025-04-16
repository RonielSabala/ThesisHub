function fillEntityField(entity) {
    $docName.val(entity.docName);
    $filePath.val(entity.filePath);
    $uploadDate.val(entity.uploadDate);

    genericLoadStatusSelect($docStatus, entity.docStatus);
    genericLoadSelect(
        $project,
        entity.projectId,
        localForeignKeyAPI,
        (project) => project.title,
    );
}

function updateEntity(id) {
    let entity = {
        id: id,
        docName: $docName.val(),
        filePath: $filePath.val(),
        uploadDate: $uploadDate.val(),
        docStatus: $docStatus.val(),
        projectId: $project.val()
    };

    genericUpdateEntity(entity);
}
