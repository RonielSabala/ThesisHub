// Local data
localAPI = documentAPI;
localForeignKeyAPI = projectAPI;
localRoutePrefix = "Documents";

// Fields
$docName = $("#docName");
$filePath = $("#filePath");
$uploadDate = $("#uploadDate");
$docStatus = $("#docStatus");
$project = $("#project");

statusOptions = [
    ["under review", "Under Review"],
    ["approved", "Approved"],
    ["rejected", "Rejected"]
];
