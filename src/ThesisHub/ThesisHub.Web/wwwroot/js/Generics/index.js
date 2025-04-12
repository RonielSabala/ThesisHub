$(document).ready(function () {
    loadEntities();
});

function getRow(entityId, Entityfields) {
    return `
        <tr>
            ${Entityfields.map(field => `
                <td>${field}</td>
            `).join('')}
            <td>
                <a href="/${localRoutePrefix}/Details/${entityId}" class="btn btn-info me-2">
                    <i class="bi bi-eye me-1"></i> Details
                </a>
                <a href="/${localRoutePrefix}/Edit/${entityId}" class="btn btn-warning me-2 text-black">
                    <i class="bi bi-pencil-square me-1"></i> Edit
                </a>
                <a href="/${localRoutePrefix}/Delete/${entityId}" class="btn btn-danger">
                    <i class="bi bi-trash3-fill me-1"></i> Delete
                </a>
            </td>
        </tr>
    `;
}

function loadEntities() {
    let filter = $("#search").val();

    $.get(
        `${localAPI}/GetAll`,
        { filter: filter },
        function (entities) {
            const rows = entities.map(getEntityRow).join('');
            $("#entityTable").html(rows);
        }
    );
}
