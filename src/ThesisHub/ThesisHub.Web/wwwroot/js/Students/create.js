function loadSelect() {
    $.ajax({
        url: `${departmentAPI}/GetAll`,
        type: "GET",
        success: function (departments) {
            const $select = $("#departmentId");
            $select.empty();
            $select.append('<option value="">-- Select department --</option>');

            $.each(departments, function (i, dept) {
                $select.append(`<option value="${dept.id}">${dept.deptName}</option>`);
            });
        }
    });
}

function addEntity() {
    let entity = {
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        email: $("#email").val(),
        phone: $("#phone").val(),
        departmentId: $("#departmentId").val()
    };

    $.ajax({
        url: `${studentAPI}/Add`,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(entity),
        success: function (response) {
            if (response.success) {
                window.location.href = "/Students/Index";
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