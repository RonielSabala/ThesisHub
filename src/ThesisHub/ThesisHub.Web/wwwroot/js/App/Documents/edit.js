function fillEntityField(entity) {
    $docName.val(entity.docName);
    $filePath.val(entity.filePath);
    $uploadDate.val(entity.uploadDate);

    loadStatusSelect(entity.docStatus);
    genericLoadSelect(
        entity.projectId,
        $project,
        localForeignKeyAPI,
        (project) => project.title,
    );
}

function loadStatusSelect(mainOption) {
    $docStatus.empty();

    let firstOption = "";
    let Options = [];

    $.each(statusOptions, function (i, status) {
        let option = getOption(status[0], status[1]);

        if (status[0] == mainOption) {
            firstOption = option;
        } else {
            Options.push(option);
        }
    });

    $docStatus.append(firstOption);
    $.each(Options, function (i, option) {
        $docStatus.append(option);
    });
}

function updateEntity(id) {
    let entity = {
        id: id,
        docName: $docName.val(),
        filePath: $filePath.val(),
        uploadDate: $uploadDate.val(),
        docStatus: $docStatus.val(),
        projectId: $project.val()
    };

    genericUpdateEntity(entity);
}
