$(document).ready(function () {
    loadEntities();
});

const searchInput = document.getElementById("search");
searchInput.addEventListener("keydown", function (e) {
    if (e.key === "Enter") {
        e.preventDefault();
        loadEntities();
    }
});

searchInput.addEventListener("input", function () {
    if (this.value.trim() === "") {
        loadEntities();
    }
});

const baseStatusStyle = 'display:inline-block; white-space:nowrap; text-align:center; border-radius: 5px; font-weight: bold;';
function getStyledField(field) {
    const lowerField = field.toLowerCase();
    let spanStyle = '';

    if (lowerField === 'in progress') {
        spanStyle = `${baseStatusStyle} padding: 4px 14px; background-color: #FFF5D6; color: #FFC20D;`;

    } else if (lowerField === 'completed') {
        spanStyle = `${baseStatusStyle} padding: 3px 12px; background-color: #C8E6C9; color: #2E7D32;`;

    } else if (lowerField === 'under review') {
        spanStyle = `${baseStatusStyle} padding: 3px 12px; background-color: #BBDEFB; color: #0D47A1;`;

    } else if (lowerField === 'approved') {
        spanStyle = `${baseStatusStyle} padding: 3px 12px; background-color: #B2DFDB; color: #00695C;`;

    } else if (lowerField === 'rejected') {
        spanStyle = `${baseStatusStyle} padding: 3px 12px; background-color: #FFCDD2; color: #C62828;`;
    }

    return spanStyle ? `<span style="${spanStyle}">${field}</span>` : field;
}

function getRow(entityId, Entityfields) {
    return `
        <tr>
            ${Entityfields.map(field => {
        return `<td style="text-align:center; vertical-align:middle;">${getStyledField(field)}</td>`;
    }).join('')}
            <td style="text-align:center; vertical-align:middle; white-space: nowrap;">
                <a href="/${localRoutePrefix}/Details/${entityId}" class="btn btn-info me-1">
                    <i class="bi bi-eye-fill"></i> Details
                </a>
                <a href="/${localRoutePrefix}/Edit/${entityId}" class="btn btn-warning text-dark me-1">
                    <i class="bi bi-pencil-square"></i> Edit
                </a>
                <a href="/${localRoutePrefix}/Delete/${entityId}" class="btn btn-danger">
                    <i class="bi bi-trash3-fill"></i> Delete
                </a>
            </td>
        </tr>
    `;
}

function checkNoData() {
    const tableBody = document.getElementById("entityTable");
    const noDataDiv = document.getElementById("noData");

    if (!tableBody || !noDataDiv) return;

    const rowCount = Array.from(tableBody.children).filter(child => child.tagName === "TR").length;

    if (rowCount > 0) {
        noDataDiv.classList.add("d-none");
    } else {
        noDataDiv.classList.remove("d-none");
    }
}

function loadEntities() {
    let filter = $("#search").val();
    $.get(
        `${localAPI}/GetAll`,
        { filter: filter },
        function (entities) {
            const rows = entities.map(getEntityRow).join('');
            $("#entityTable").html(rows);
            checkNoData();
        }
    );
}
