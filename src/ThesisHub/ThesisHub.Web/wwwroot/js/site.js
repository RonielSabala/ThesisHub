// API's
const API = "https://localhost:7149";
const departmentAPI = `${API}/Departments`;
const studentAPI = `${API}/Students`;
const tutorAPI = `${API}/Tutors`;
const projectAPI = `${API}/Projects`;
const projectTutorAPI = `${API}/ProjectTutors`;


function succesResponse(response, routePrefix) {
    if (response.success) {
        window.location.href = `/${routePrefix}/Index`;
    } else {
        alert("Error: " + response.message);
    }
}

function showError(
    xhr,
    status,
    error,
    msg = "An error occurred. Please try again."
)
{
    console.error("AJAX Error:", status, error);
    alert(msg);
}
