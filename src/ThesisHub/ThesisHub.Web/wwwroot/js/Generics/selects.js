function getOption(value, label) {
    return `
        <option value="${value}">${label}</option>
    `;
}

function genericBuildSelect(select, apiUrl, valueGetter, selectText) {
    $.ajax({
        url: `${apiUrl}/GetAll`,
        type: "GET",
        success: function (entities) {
            select.empty();

            // Append options
            select.append(getOption("", `-- Select ${selectText} --`));
            $.each(entities, function (i, entity) {
                select.append(getOption(entity.id, valueGetter(entity)));
            });
        },
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}

function genericLoadSelect(mainOption, select, apiUrl, valueGetter) {
    $.ajax({
        url: `${apiUrl}/GetAll`,
        type: "GET",
        success: function (entities) {
            select.empty();

            let firstOption = "";
            let Options = [];

            $.each(entities, function (i, entity) {
                let option = getOption(entity.id, valueGetter(entity));

                if (entity.id == mainOption) {
                    firstOption = option;
                } else {
                    Options.push(option);
                }
            });

            select.append(firstOption);
            $.each(Options, function (i, option) {
                select.append(option);
            });
        },
        error: (xhr, status, error) => showError(xhr, status, error)
    });
}
