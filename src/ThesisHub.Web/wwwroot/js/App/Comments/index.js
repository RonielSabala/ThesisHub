function getEntityRow(entity) {
    const fields = [
        entity.commentText,
        entity.uploadDate,
        entity.docName,
        entity.tutorName,
    ]

    return getRow(entity.id, fields);
}
