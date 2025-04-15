function addEntity() {
    let entity = {
        deptName: $deptName.val(),
        facultyHead: $facultyHead.val(),
        email: $email.val()
    };

    genericAddEntity(entity);
}
