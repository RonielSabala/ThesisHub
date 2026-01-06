// Local data
localAPI = projectAPI;
localForeignKeyAPI = studentAPI;
localRoutePrefix = "Projects";

// Fields
$title = $("#title");
$projectDescription = $("#projectDescription");
$registrationDate = $("#registrationDate");
$projectStatus = $("#projectStatus");
$student = $("#student");

statusOptions = [
    ["in progress", "In Progress"],
    ["completed", "Completed"],
    ["under review", "Under Review"],
    ["approved", "Approved"],
    ["rejected", "Rejected"]
];
