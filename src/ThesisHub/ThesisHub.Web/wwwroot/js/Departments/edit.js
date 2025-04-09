function loadDepartment(id) {
    $.get(`${departmentAPI}/Get/${id}`, function (entity) {
        $("#deptName").val(entity.deptName);
        $("#facultyHead").val(entity.facultyHead);
        $("#email").val(entity.email);
    });
}

function updateDepartment() {
    let entity = {
        id: $("#modelId").val(),
        deptName: $("#deptName").val(),
        facultyHead: $("#facultyHead").val(),
        email: $("#email").val()
    };

    $.ajax({
        url: `${departmentAPI}/Update`,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(entity),
        success: function (response) {
            if (response.success) {
                window.location.href = "/Departments/Index";
            } else {
                alert("Error: " + response.message);
            }
        },
        error: function (xhr, status, error) {
            console.error("AJAX Error:", status, error);
            alert("An error occurred. Please try again.");
        }
    });
}