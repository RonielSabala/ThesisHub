function getRow(entityId, Entityfields, routePrefix) {
    return `
        <tr>
            ${Entityfields.map(field => `
                <td>${field}</td>
            `).join('')}
            <td>
                <a href="/${routePrefix}/Details/${entityId}" class="btn btn-info me-2">
                    <i class="bi bi-eye me-1"></i> Details
                </a>
                <a href="/${routePrefix}/Edit/${entityId}" class="btn btn-warning me-2 text-black">
                    <i class="bi bi-pencil-square me-1"></i> Edit
                </a>
                <a href="/${routePrefix}/Delete/${entityId}" class="btn btn-danger">
                    <i class="bi bi-trash3-fill me-1"></i> Delete
                </a>
            </td>
        </tr>
    `;
}

function genericLoadEntities(apiUrl, getEntityRow) {
    let filter = $("#search").val();

    $.get(
        `${apiUrl}/GetAll`,
        { filter: filter },
        function (entities) {
            const rows = entities.map(getEntityRow).join('');
            $("#entityTable").html(rows);
        }
    );
}
