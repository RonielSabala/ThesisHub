function addEntity() {
    let entity = {
        commentText: $commentText.val(),
        uploadDate: formatDate(new Date()),
        documentId: $document.val(),
        tutorId: $tutor.val(),
    };

    genericAddEntity(entity);
}

function loadDocumentSelect() {
    genericBuildSelect(
        $document,
        localForeignKeyAPI1,
        (document) => document.docName,
        "a document"
    );
}

function loadTutorSelect() {
    genericBuildSelect(
        $tutor,
        localForeignKeyAPI2,
        (tutor) => tutor.firstName + " " + tutor.lastName,
        "a tutor"
    );
}
