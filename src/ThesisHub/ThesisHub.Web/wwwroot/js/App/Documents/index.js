function getEntityRow(entity) {
    const fields = [
        entity.docName,
        entity.filePath,
        entity.uploadDate,
        entity.docStatus,
        entity.projectTitle,
    ]

    return getRow(entity.id, fields);
}
