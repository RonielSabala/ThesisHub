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