function fillEntityField(entity) {
    genericLoadSelect(
        $project,
        entity.projectId,
        localForeignKeyAPI1,
        (project) => project.title
    );

    genericLoadSelect(
        $tutor,
        entity.tutorId,
        localForeignKeyAPI2,
        (tutor) => tutor.firstName + " " + tutor.lastName
    );

    $tutorRole.val(entity.tutorRole);
}

function updateEntity(id) {
    let entity = {
        id: id,
        projectId: $project.val(),
        tutorId: $tutor.val(),
        tutorRole: $tutorRole.val(),
    };

    genericUpdateEntity(entity);
}
