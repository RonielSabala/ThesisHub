function loadEntity(id) {
    $.get(`${studentAPI}/Get/${id}`, function (entity) {
        $("#firstName").text(entity.firstName);
        $("#lastName").text(entity.lastName);
        $("#email").text(entity.email);
        $("#phone").text(entity.phone);
        $("#department").text(entity.department.deptName);
    });
}