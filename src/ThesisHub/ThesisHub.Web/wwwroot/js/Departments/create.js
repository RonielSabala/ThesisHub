function addEntity() {
    let entity = {
        facultyHead: $("#facultyHead").val(),
        deptName: $("#deptName").val(),
        email: $("#email").val()
    };

    $.ajax({
        url: `${departmentAPI}/Add`,
        type: "POST",
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