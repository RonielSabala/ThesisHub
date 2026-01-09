# ThesisHub

ThesisHub is a web application built with **C#** and **ASP.NET MVC** to register, manage and monitor university theses. It provides a workflow for students to submit thesis files, tutors to review, comment on submissions, and administrators to manage the thesis lifecycle and users.

---

## Table of Contents

* [Features](#features)
* [Architecture & Data Model](#architecture--data-model)
* [Requirements](#requirements)
* [Quick Start](#quick-start)
  * [Clone the repository](#clone-the-repository)
  * [Restore & Build](#restore--build)
  * [Database setup](#database-setup)
  * [Run locally](#run-locally)
* [Contributing](#contributing)
* [License](#license)

---

## Features

* Register and manage **Theses**, **Students**, **Tutors**, and **Departments**.
* Assign tutors to theses with roles (e.g., `Advisor`, `Co-Advisor`).
* Upload multiple document links per thesis.
* Tutors review and comment on documents.
* Track thesis lifecycle statuses: `Open`, `Closed`, `Approved`, `Rejected`.
* Simple admin dashboard to view theses by status and assigned tutors.

---

## Architecture & Data Model

Primary entities and relationships:

* A `Department` has many `Students` and many `Tutors`.
* A `Student` can create many `Theses`.
* A `Thesis` belongs to a `Student`, has many `Documents`, and connects to `Tutors` via `ProjectTutors` that stores `tutor_role`.
* A `Document` belongs to a single `Thesis` and is authored/owned by a `Student`.
* A `Tutor` can have many assigned `Theses`; can comment on `Documents`.
* A `Comment` is attached to a `Document`, authored by a `Tutor`.

> For a full ER diagram, see `db/diagrams/ER-diagram.pdf`

---

## Requirements

* .NET SDK 9.0 or newer
* Visual Studio
* SQL Server (Express or full)
* sqlcmd

---

## Quick Start

### Clone the repository

```bash
git clone <repo-url>
cd <repo-folder>
```

### Restore & Build

Restore NuGet packages and build the solution:

```bash
dotnet restore
dotnet build --configuration Debug
```

### Database setup

From the repository root, run the DB install script:

```bash
sqlcmd -S .\SQLEXPRESS -i db/scripts/creation.sql
```

> This script will create required tables and sample data.

### Run locally

1. Open the solution in Visual Studio.

2. Right-click the solution > **Configure Startup Projects...**

3. Select **Multiple startup projects** and set both `ThesisHub.Web` and `ThesisHub.API` to **Start**.

4. Save and run (F5).

> Visual Studio will launch both projects and open the configured URLs.

---

## Contributing

Contributions are welcome. Suggested workflow:

1. Fork the repository.
2. Create a feature branch: `feature/my-change`.
3. Commit, push, and open a pull request describing the change and reason.

---

## License

This project is available under the **MIT License**.
