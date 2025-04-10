function loadEntity(id) {
    $.get(`${studentAPI}/Get/${id}`, function (entity) {
        $("#firstName").val(entity.firstName);
        $("#lastName").val(entity.lastName);
        $("#email").val(entity.email);
        $("#phone").val(entity.phone);

        loadDepartments(entity.departmentId);
    });
}

function loadDepartments(mainOption) {
    $.ajax({
        url: `${departmentAPI}/GetAll`,
        type: "GET",
        success: function (departments) {
            const $select = $("#departmentId");
            $select.empty();

            let firstOption = "";
            let Options = [];

            $.each(departments, function (i, dept) {
                let item = `<option value="${dept.id}">${dept.deptName}</option>`;

                if (dept.id == mainOption) {
                    firstOption = item;
                } else {
                    Options.push(item);
                }
            });

            $select.append(firstOption);
            $.each(Options, function (i, option) {
                $select.append(option);
            });
        },
        error: function (xhr, status, error) {
            console.error("AJAX Error:", status, error);
            alert("An error occurred. Please try again.");
        }
    });
}

function updateEntity() {
    let entity = {
        id: $("#modelId").val(),
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        email: $("#email").val(),
        phone: $("#phone").val(),
        departmentId: $("#departmentId").val()
    };

    $.ajax({
        url: `${studentAPI}/Update`,
        type: "PUT",
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