function loadDelete(id) {
    $.get(`${departmentAPI}/Get/${id}`, function (entity) {
        $("#deptName").html(entity.deptName);
        $("#facultyHead").html(entity.facultyHead);
        $("#email").html(entity.email);
    });
}

function deleteDepartment(id) {
    $.ajax({
        url: `${departmentAPI}/Delete/${id}`,
        type: "DELETE",
        contentType: "application/json",
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