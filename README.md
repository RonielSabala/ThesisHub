# ThesisHub

## University Thesis Control System

ThesisHub is a web application built with **C#** and **ASP.NET MVC** to register, manage and monitor university theses. The system allows students to submit thesis files, tutors to review and comment on submissions, and administrators to track thesis status. Each thesis can have multiple documents attached; documents belong to a student and can be reviewed by assigned tutors.

---

## Table of Contents

* [Features](#features)
* [Architecture / Data Model](#architecture--data-model)
* [Requirements](#requirements)
* [Quick Setup](#quick-setup)
* [Run Locally](#run-locally)
* [Contributing](#contributing)
* [License](#license)

---

## Features

* Register and manage **theses**, **students**, **tutors**, and **departments**.
* Assign tutors to theses with a specific role such as "Advisor", "Co-Advisor", etc.
* Upload multiple documents per thesis.
* Tutors can review and comment on documents.
* Track thesis lifecycle status: **Open**, **Closed**, **Approved**, **Rejected**.
* Simple admin dashboard to view theses by status and assigned tutors.

---

## Architecture / Data Model

The database schema implements entities for `Students`, `Tutors`, `Departments`, `Projects`, `ProjectTutors`, `Documents`, and `Comments`. The relationships are:

* A `Department` has many `Students` and many `Tutors`.
* A `Student` can create many `Theses`.
* A `Thesis` can have many `Documents`.
* A `Document` belongs to a single `Student` and a single `Thesis`.
* `Tutors` can be assigned to many `Theses` through `ThesisTutors` with a `tutor_role`.
* `Comments` are made by tutors on documents.

See `db/diagrams/ER-diagram.pdf` for the full diagram.

---

## Requirements

* .NET SDK 6.0 or newer
* Visual Studio 2022 / Visual Studio Code
* SQL Server
* Optional: `dotnet-ef` tool for migrations

---

## Quick Setup

1. Clone the repository and open the solution in Visual Studio, or use the command line:

    ```bash
    git clone <repo-url>
    cd <repo-folder>
    ```

2. Restore NuGet packages (Visual Studio does this automatically) or run:

    ```bash
    dotnet restore
    ```

3. Configure the database connection and other settings in `appsettings.json` (see next section).

4. Run `db/scripts/creation.sql` to create the database schema.

5. Build and run the application.

---

## Run Locally

From Visual Studio: press F5 or run the project as a Console application.

---

## Contributing

Contributions are welcome. Suggested workflow:

1. Fork the repository.
2. Create a feature branch: `feature/my-change`.
3. Commit changes and open a pull request describing the change and reason.

---

## License

This project is available under the **MIT License**.
