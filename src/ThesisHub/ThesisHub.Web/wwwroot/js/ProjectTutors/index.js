function getEntityRow(entity) {
    const fields = [
        entity.projectTitle,
        entity.tutorName,
        entity.tutorRole,
    ]

    return getRow(entity.id, fields);
}
