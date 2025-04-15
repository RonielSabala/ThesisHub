function fillEntityField(entity) {
    $title.val(entity.title);
    $projectDescription.val(entity.projectDescription);
    $registrationDate.val(entity.registrationDate);

    loadStatusSelect(entity.projectStatus);
    loadStudentSelect(entity.studentId);
}

function loadStatusSelect(mainOption) {
    $projectStatus.empty();

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

    $projectStatus.append(firstOption);
    $.each(Options, function (i, option) {
        $projectStatus.append(option);
    });
}

function loadStudentSelect(mainOption) {
    return genericLoadSelect(
        mainOption,
        $student,
        localForeignKeyAPI,
        (student) => student.firstName + " " + student.lastName
    );
}

function updateEntity(id) {
    let entity = {
        id: id,
        title: $title.val(),
        projectDescription: $projectDescription.val(),
        registrationDate: $registrationDate.val(),
        projectStatus: $projectStatus.val(),
        studentId: $student.val()
    };

    return genericUpdateEntity(entity);
}
