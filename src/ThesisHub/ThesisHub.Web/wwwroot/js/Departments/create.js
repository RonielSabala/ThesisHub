function addEntity() {
    let entity = {
        deptName: $deptName.val(),
        facultyHead: $facultyHead.val(),
        email: $email.val()
    };

    return genericAddEntity(entity);
}
