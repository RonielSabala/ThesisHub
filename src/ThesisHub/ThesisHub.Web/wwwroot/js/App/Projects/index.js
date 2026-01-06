function getEntityRow(entity) {
    const fields = [
        entity.title,
        entity.projectDescription,
        entity.registrationDate,
        entity.projectStatus,
        entity.studentName,
    ]

    return getRow(entity.id, fields);
}
