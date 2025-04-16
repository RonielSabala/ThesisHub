function getEntityRow(entity) {
    const fields = [
        entity.firstName,
        entity.lastName,
        entity.email,
        entity.phone,
        entity.deptName,
    ]

    return getRow(entity.id, fields);
}
