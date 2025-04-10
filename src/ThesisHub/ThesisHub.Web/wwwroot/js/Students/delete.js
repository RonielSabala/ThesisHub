function loadEntity(id) {
    $.get(`${studentAPI}/Get/${id}`, function (entity) {
        $("#firstName").text(entity.firstName);
        $("#lastName").text(entity.lastName);
        $("#email").text(entity.email);
        $("#phone").text(entity.phone);
        $("#department").text(entity.deptName);
    });
}

function deleteEntity(id) {
    $.ajax({
        url: `${studentAPI}/Delete/${id}`,
        type: "DELETE",
        contentType: "application/json",
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