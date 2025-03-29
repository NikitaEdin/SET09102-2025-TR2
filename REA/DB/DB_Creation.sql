﻿CREATE TABLE Roles (
    roleID INTEGER PRIMARY KEY AUTOINCREMENT,
    title TEXT NOT NULL,
    description TEXT,
    power INTEGER NOT NULL
);


CREATE TABLE Users (
    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT NOT NULL,
    name TEXT NOT NULL,
    password TEXT NOT NULL,
    roleID INTEGER,
    FOREIGN KEY (roleID) REFERENCES Roles(roleID) ON DELETE SET NULL
);

CREATE TABLE Sites (
    site_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    latitude REAL NOT NULL,
    longitude REAL NOT NULL,
    type TEXT NOT NULL,
    zone TEXT,
    Agglomeration TEXT,
    Local_authority TEXT
);

CREATE TABLE Sensors (
    sensor_id INTEGER PRIMARY KEY AUTOINCREMENT,
    sensor_type TEXT NOT NULL,
    sensor_url TEXT,
    deployment_date DATE,
    sensor_operational BOOLEAN,
    configID INTEGER,
    FOREIGN KEY (configID) REFERENCES Configuration(ConfigID) ON DELETE SET NULL
);

CREATE TABLE Configuration (
    ConfigID INTEGER PRIMARY KEY AUTOINCREMENT,
    sensor_id INTEGER NOT NULL,
    minMeasurement REAL NOT NULL,
    maxMeasurement REAL NOT NULL,
    type TEXT NOT NULL,
    unit TEXT NOT NULL,
    firmware BLOB, -- assuming firmware is a file, stored as BLOB
    FOREIGN KEY (sensor_id) REFERENCES Sensors(sensor_id) ON DELETE CASCADE
);

CREATE TABLE Metadata (
    parameter TEXT PRIMARY KEY,
    category TEXT NOT NULL,
    symbol TEXT NOT NULL,
    unit TEXT NOT NULL,
    unit_description TEXT,
    measurement_freq TEXT NOT NULL,
    safe_limit REAL,
    reference_url TEXT,
    sensor_id INTEGER,
    FOREIGN KEY (sensor_id) REFERENCES Sensors(sensor_id) ON DELETE SET NULL
);

CREATE TABLE Measurements (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    datetime DATETIME NOT NULL,
    parameter TEXT NOT NULL,
    value REAL NOT NULL,
    unit TEXT NOT NULL,
    site_id INTEGER,
    FOREIGN KEY (site_id) REFERENCES Sites(site_id) ON DELETE SET NULL,
    FOREIGN KEY (parameter) REFERENCES Metadata(parameter) ON DELETE CASCADE
);




-- Insert roles into the Roles table
INSERT INTO Roles (title, description, power) VALUES
('Administrator', 'Has full control over all system settings and data', 90),
('Operations Manager', 'Manages site operations and monitoring tasks', 70),
('Environmental Scientist', 'Analyses environmental data and reports', 60);


-- Insert users into the Users table with the new structure
INSERT INTO Users (username, name, password, roleID) VALUES
('admin', 'Admin User', '123', (SELECT roleID FROM Roles WHERE title = 'Administrator')),
('operations', 'Operations Manager', '123', (SELECT roleID FROM Roles WHERE title = 'Operations Manager')),
('env_sci', 'Environmental Scientist', '123', (SELECT roleID FROM Roles WHERE title = 'Environmental Scientist'));
