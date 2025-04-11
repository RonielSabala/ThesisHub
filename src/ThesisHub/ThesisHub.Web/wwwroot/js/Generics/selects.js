function getOption(entity, valueGetter) {
    return `
        <option value="${entity.id}">${valueGetter(entity)}</option>
    `;
}

function genericBuildSelect(select, apiUrl, valueGetter) {
    $.ajax({
        url: `${apiUrl}/GetAll`,
        type: "GET",
        success: function (entities) {
            select.empty();

            // Append options
            select.append('<option value="">-- Select department --</option>');
            $.each(entities, function (i, entity) {
                select.append(getOption(entity, valueGetter));
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
                let option = getOption(entity, valueGetter);

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
