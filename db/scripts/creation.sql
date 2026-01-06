-- Create the database
IF NOT EXISTS (
    SELECT
        name
    FROM
        sys.databases
    WHERE
        name = 'ThesisHubDb'
) BEGIN CREATE DATABASE ThesisHubDb;

END
GO
    USE ThesisHubDb;

GO
    -- Tabla Departments
    CREATE TABLE departments (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        dept_name VARCHAR(50) NOT NULL,
        faculty_head VARCHAR(50) NOT NULL,
        email VARCHAR(50) NOT NULL
    );

GO
    -- Tabla Students
    CREATE TABLE students (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        first_name VARCHAR(50) NOT NULL,
        last_name VARCHAR(50) NOT NULL,
        email VARCHAR(50) NOT NULL,
        phone VARCHAR(15) NOT NULL,
        department_id INT NOT NULL,
        CONSTRAINT FK_students_departments FOREIGN KEY (department_id) REFERENCES departments(id)
    );

GO
    -- Tabla Tutors
    CREATE TABLE tutors (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        first_name VARCHAR(50) NOT NULL,
        last_name VARCHAR(50) NOT NULL,
        email VARCHAR(50) NOT NULL,
        specialization VARCHAR(50),
        department_id INT NOT NULL,
        CONSTRAINT FK_tutors_departments FOREIGN KEY (department_id) REFERENCES departments(id)
    );

GO
    -- Tabla Projects
    CREATE TABLE projects (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        title VARCHAR(50) NOT NULL,
        project_description VARCHAR(250),
        registration_date DATETIME NOT NULL,
        project_status VARCHAR(20) NOT NULL CHECK (
            project_status IN (
                'in progress',
                'completed',
                'under review',
                'approved',
                'rejected'
            )
        ),
        student_id INT NOT NULL,
        CONSTRAINT FK_projects_students FOREIGN KEY (student_id) REFERENCES students(id)
    );

GO
    -- Tabla Project_Tutors
    CREATE TABLE project_tutors (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        project_id INT NOT NULL,
        tutor_id INT NOT NULL,
        tutor_role VARCHAR(50) NOT NULL,
        CONSTRAINT FK_project_tutors_projects FOREIGN KEY (project_id) REFERENCES projects(id),
        CONSTRAINT FK_project_tutors_tutors FOREIGN KEY (tutor_id) REFERENCES tutors(id)
    );

GO
    -- Tabla Documents
    CREATE TABLE documents (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        doc_name VARCHAR(50) NOT NULL,
        file_path VARCHAR(250) NOT NULL,
        upload_date DATETIME NOT NULL,
        doc_status VARCHAR(20) NOT NULL CHECK (
            doc_status IN ('under review', 'approved', 'rejected')
        ),
        project_id INT NOT NULL,
        CONSTRAINT FK_documents_projects FOREIGN KEY (project_id) REFERENCES projects(id)
    );

GO
    -- Tabla Comments
    CREATE TABLE comments (
        id INT IDENTITY(1, 1) PRIMARY KEY,
        comment_text VARCHAR(500) NOT NULL,
        upload_date DATETIME NOT NULL,
        document_id INT NOT NULL,
        tutor_id INT NOT NULL,
        CONSTRAINT FK_comments_documents FOREIGN KEY (document_id) REFERENCES documents(id),
        CONSTRAINT FK_comments_tutors FOREIGN KEY (tutor_id) REFERENCES tutors(id)
    );

GO