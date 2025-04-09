$(document).ready(function () {
    loadDepartments();
});

function loadDepartments() {
    let filter = $("#search").val();

    $.get(`${departmentAPI}/GetAll`, { filter: filter }, function (entities) {
        const rows = entities.map(entity => `
            <tr>
                <td>${entity.deptName}</td>
                <td>${entity.facultyHead}</td>
                <td>${entity.email}</td>
                <td>
                    <a href="/Departments/Details/${entity.id}" class="btn btn-info me-2">
                        <i class="bi bi-eye me-1"></i> Details
                    </a>
                    <a href="/Departments/Edit/${entity.id}" class="btn btn-warning me-2 text-white">
                        <i class="bi bi-pencil-square me-1"></i> Edit
                    </a>
                    <a href="/Departments/Delete/${entity.id}" class="btn btn-danger">
                        <i class="bi bi-trash3-fill me-1"></i> Delete
                    </a>
                </td>
            </tr>
        `).join('');

        $("#entityTable").html(rows);
    });
}