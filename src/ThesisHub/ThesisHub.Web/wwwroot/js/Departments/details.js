function loadDetails(id) {
    $.get(`${departmentAPI}/Get/${id}`, function (entity) {
        $("#deptName").text(entity.deptName);
        $("#facultyHead").text(entity.facultyHead);
        $("#email").text(entity.email);
    });
}