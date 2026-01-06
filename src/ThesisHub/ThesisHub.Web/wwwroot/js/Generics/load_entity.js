function loadEntity(id) {
    $.get(`${localAPI}/Get/${id}`, function (entity) {
        fillEntityField(entity);
    });
}
