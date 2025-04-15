function fillEntityField(entity) {
    genericLoadSelect(
        entity.projectId,
        $project,
        localForeignKeyAPI1,
        (project) => project.title
    );

    genericLoadSelect(
        entity.tutorId,
        $tutor,
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
