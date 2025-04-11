BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Configuration" (
	"config_id"	INTEGER,
	"sensor_id"	INTEGER NOT NULL,
	"min_measurement"	REAL NOT NULL,
	"max_measurement"	REAL NOT NULL,
	"type"	TEXT NOT NULL,
	"firmware"	REAL,
	PRIMARY KEY("config_id" AUTOINCREMENT),
	FOREIGN KEY("sensor_id") REFERENCES "Sensors"("sensor_id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Measurements" (
	"ID"	INTEGER,
	"datetime"	DATETIME NOT NULL,
	"parameter"	TEXT NOT NULL,
	"value"	REAL NOT NULL,
	"unit"	TEXT NOT NULL,
	"site_id"	INTEGER,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("parameter") REFERENCES "Metadata"("parameter") ON DELETE CASCADE,
	FOREIGN KEY("site_id") REFERENCES "Sites"("site_id") ON DELETE SET NULL
);
CREATE TABLE IF NOT EXISTS "Metadata" (
	"parameter"	TEXT,
	"category"	TEXT NOT NULL,
	"symbol"	TEXT NOT NULL,
	"unit"	TEXT NOT NULL,
	"unit_description"	TEXT,
	"measurement_freq"	TEXT NOT NULL,
	"safe_limit"	REAL,
	"reference_url"	TEXT,
	"sensor_id"	INTEGER,
	PRIMARY KEY("parameter"),
	FOREIGN KEY("sensor_id") REFERENCES "Sensors"("sensor_id") ON DELETE SET NULL
);
CREATE TABLE IF NOT EXISTS "Roles" (
	"roleID"	INTEGER,
	"title"	TEXT NOT NULL,
	"description"	TEXT,
	"power"	INTEGER NOT NULL,
	PRIMARY KEY("roleID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Sensors" (
	"sensor_id"	INTEGER,
	"site_id"	INTEGER,
	"sensor_type"	TEXT NOT NULL,
	"sensor_url"	TEXT,
	"deployment_date"	DATE,
	"sensor_operational"	BOOLEAN,
	PRIMARY KEY("sensor_id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Sites" (
	"site_id"	INTEGER,
	"name"	TEXT NOT NULL,
	"latitude"	REAL NOT NULL,
	"longitude"	REAL NOT NULL,
	"type"	TEXT NOT NULL,
	"zone"	TEXT,
	"Agglomeration"	TEXT,
	"Local_authority"	TEXT,
	PRIMARY KEY("site_id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Users" (
	"UserID"	INTEGER,
	"username"	TEXT NOT NULL,
	"name"	TEXT NOT NULL,
	"password"	TEXT NOT NULL,
	"roleID"	INTEGER,
	PRIMARY KEY("UserID" AUTOINCREMENT),
	FOREIGN KEY("roleID") REFERENCES "Roles"("roleID") ON DELETE SET NULL
);
INSERT INTO "Configuration" VALUES (1,1,0.1,199.0,'Nitrogen dioxide',0.1);
INSERT INTO "Configuration" VALUES (2,2,0.1,265.0,'Sulphur dioxide',0.1);
INSERT INTO "Configuration" VALUES (3,3,0.1,34.0,'Particulate matter',0.1);
INSERT INTO "Configuration" VALUES (4,4,0.1,49.0,'Particulate matter',0.1);
INSERT INTO "Configuration" VALUES (5,5,0.1,2.0,'Nitrate',0.1);
INSERT INTO "Configuration" VALUES (6,6,0.1,49.0,'Nitrate',0.1);
INSERT INTO "Configuration" VALUES (7,7,0.0,0.1,'Phosphate',0.1);
INSERT INTO "Configuration" VALUES (8,8,0.1,499.0,'Escherichia coli',0.1);
INSERT INTO "Configuration" VALUES (9,9,0.1,184.0,'Intestinal enterococci',0.1);
INSERT INTO "Configuration" VALUES (10,10,0.1,184.0,'Air Temperature',0.1);
INSERT INTO "Configuration" VALUES (11,11,0.1,184.0,'Humidity',0.1);
INSERT INTO "Configuration" VALUES (12,12,0.1,184.0,'Wind speed',0.1);
INSERT INTO "Configuration" VALUES (13,13,0.1,184.0,'Wind Direction',0.1);
INSERT INTO "Roles" VALUES (1,'Administrator','Has full control over all system settings and data',90);
INSERT INTO "Roles" VALUES (2,'Operations Manager','Manages site operations and monitoring tasks',70);
INSERT INTO "Roles" VALUES (3,'Environmental Scientist','Analyses environmental data and reports',60);
INSERT INTO "Sensors" VALUES (1,1,'Air','https://airly.org/en/features/air-quality-sensors/','2025-04-06',1);
INSERT INTO "Sensors" VALUES (2,1,'Air','https://airly.org/en/features/air-quality-sensors/','2023-11-02',1);
INSERT INTO "Sensors" VALUES (3,1,'Air','https://airly.org/en/features/air-quality-sensors/','2024-02-16',1);
INSERT INTO "Sensors" VALUES (4,1,'Air','https://airly.org/en/features/air-quality-sensors/','2025-03-10',0);
INSERT INTO "Sensors" VALUES (5,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2023-01-01',1);
INSERT INTO "Sensors" VALUES (6,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2023-05-07',1);
INSERT INTO "Sensors" VALUES (7,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2024-02-22',1);
INSERT INTO "Sensors" VALUES (8,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2025-01-12',1);
INSERT INTO "Sensors" VALUES (9,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2021-01-18',0);
INSERT INTO "Sensors" VALUES (10,3,'Weather','https://www.alliot.co.uk/product/netvox-outdoor-temperature-and-humidity-sensor/','2024-08-12',1);
INSERT INTO "Sensors" VALUES (11,3,'Weather','https://www.alliot.co.uk/product/netvox-outdoor-temperature-and-humidity-sensor/','2025-08-15',1);
INSERT INTO "Sensors" VALUES (12,3,'Weather','https://www.vaisala.com/en/products/ultrasonic-wind-sensor-wm80','2024-06-11',1);
INSERT INTO "Sensors" VALUES (13,3,'Weather','https://www.vaisala.com/en/products/ultrasonic-wind-sensor-wm80','2025-02-11',0);
INSERT INTO "Users" VALUES (1,'admin','Admin User','123',1);
INSERT INTO "Users" VALUES (2,'operations','Operations Manager','123',2);
INSERT INTO "Users" VALUES (3,'env_sci','Environmental Scientist','123',3);
COMMIT;
