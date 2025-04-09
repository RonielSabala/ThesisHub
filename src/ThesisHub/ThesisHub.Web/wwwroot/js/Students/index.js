$(document).ready(function () {
    loadStudents();
});

function loadStudents() {
    let filter = $("#search").val();

    $.get(`${studentAPI}/GetAll`, { filter: filter }, function (entities) {
        const rows = entities.map(entity => `
            <tr>
                <td>${entity.firstName}</td>
                <td>${entity.lastName}</td>
                <td>${entity.email}</td>
                <td>${entity.phone}</td>
                <td>${entity.department.deptName}</td>
                <td>
                    <a href="/Students/Details/${entity.id}" class="btn btn-info me-2">
                        <i class="bi bi-eye me-1"></i> Details
                    </a>
                    <a href="/Students/Edit/${entity.id}" class="btn btn-warning me-2 text-white">
                        <i class="bi bi-pencil-square me-1"></i> Edit
                    </a>
                    <a href="/Students/Delete/${entity.id}" class="btn btn-danger">
                        <i class="bi bi-trash3-fill me-1"></i> Delete
                    </a>
                </td>
            </tr>
        `).join('');

        $("#studentsTable").html(rows);
    });
}