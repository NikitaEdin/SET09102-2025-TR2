BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Configuration" (
	"ConfigID"	INTEGER,
	"sensor_id"	INTEGER NOT NULL,
	"minMeasurement"	REAL NOT NULL,
	"maxMeasurement"	REAL NOT NULL,
	"type"	TEXT NOT NULL,
	"unit"	TEXT NOT NULL,
	"firmware"	BLOB,
	PRIMARY KEY("ConfigID" AUTOINCREMENT),
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
	"sensor_type"	TEXT NOT NULL,
	"sensor_url"	TEXT,
	"deployment_date"	DATE,
	"sensor_operational"	BOOLEAN,
	"configID"	INTEGER,
	PRIMARY KEY("sensor_id" AUTOINCREMENT),
	FOREIGN KEY("configID") REFERENCES "Configuration"("ConfigID") ON DELETE SET NULL
);
CREATE TABLE IF NOT EXISTS "Sites" (
	"site_id"	INTEGER,
	"name"	TEXT,
	"latitude"	REAL,
	"longitude"	REAL,
	"elevation"	INTEGER,
	"timezone"	TEXT,
	"utc_offset"	INTEGER,
	"type"	TEXT,
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
INSERT INTO "Roles" VALUES (1,'Administrator','Has full control over all system settings and data',90);
INSERT INTO "Roles" VALUES (2,'Operations Manager','Manages site operations and monitoring tasks',70);
INSERT INTO "Roles" VALUES (3,'Environmental Scientist','Analyses environmental data and reports',60);
INSERT INTO "Roles" VALUES (4,'Administrator','Has full control over all system settings and data',90);
INSERT INTO "Roles" VALUES (5,'Operations Manager','Manages site operations and monitoring tasks',70);
INSERT INTO "Roles" VALUES (6,'Environmental Scientist','Analyses environmental data and reports',60);
INSERT INTO "Sites" VALUES (1,'Edinburgh Nicolson Street',55.94476,-3.183991,0,'',0,'Urban Traffic','Central Scotland','Edinburgh Urban Area','Edinburgh');
INSERT INTO "Sites" VALUES (2,'Edinburgh Nicolson Street',55.94476,-3.183991,0,'',0,'Urban Traffic','Central Scotland','Edinburgh Urban Area','Edinburgh');
INSERT INTO "Sites" VALUES (3,'Glencorse B',55.86111111,3.25388889,0,'',0,'','','','');
INSERT INTO "Sites" VALUES (4,'',55.008785,-3.5856323,8,'',0,'','','','');
INSERT INTO "Users" VALUES (1,'admin','Admin User','123',1);
INSERT INTO "Users" VALUES (2,'operations','Operations Manager','123',2);
INSERT INTO "Users" VALUES (3,'env_sci','Environmental Scientist','123',3);
INSERT INTO "Users" VALUES (4,'admin','Admin User','123',1);
INSERT INTO "Users" VALUES (5,'operations','Operations Manager','123',2);
INSERT INTO "Users" VALUES (6,'env_sci','Environmental Scientist','123',3);
COMMIT;
