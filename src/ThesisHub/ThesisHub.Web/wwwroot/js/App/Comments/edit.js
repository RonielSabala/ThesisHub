function fillEntityField(entity) {
    $commentText.val(entity.commentText);
    $uploadDate.val(entity.uploadDate);

    genericLoadSelect(
        $document,
        entity.documentId,
        localForeignKeyAPI1,
        (document) => document.docName
    );

    genericLoadSelect(
        $tutor,
        entity.tutorId,
        localForeignKeyAPI2,
        (tutor) => tutor.firstName + " " + tutor.lastName
    );
}

function updateEntity(id) {
    let entity = {
        id: id,
        commentText: $commentText.val(),
        uploadDate: $uploadDate.val(),
        documentId: $document.val(),
        tutorId: $tutor.val(),
    };

    genericUpdateEntity(entity);
}
