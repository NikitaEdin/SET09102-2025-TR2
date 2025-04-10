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
CREATE TABLE IF NOT EXISTS "Metadata" (
	"ID"	INTEGER,
	"category"	TEXT NOT NULL,
	"quantity"	TEXT NOT NULL,
	"symbol"	TEXT NOT NULL,
	"unit"	TEXT NOT NULL,
	"unit_drescription"	TEXT,
	"measurement_freq"	TEXT,
	"safe_level"	REAL,
	"Sensor"	TEXT,
	"reference_url"	TEXT,
	"sensor_id"	INTEGER,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("sensor_id") REFERENCES "Sensors"("sensor_id")
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
	"site_id"	INTEGER NOT NULL,
	"sensor_type"	TEXT NOT NULL,
	"sensor_url"	TEXT,
	"deployment_date"	TEXT,
	"sensor_operational"	BOOLEAN,
	PRIMARY KEY("sensor_id" AUTOINCREMENT)
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
CREATE TABLE IF NOT EXISTS "water_measurements" (
	"ID"	INTEGER,
	"datetime"	DATETIME NOT NULL,
	"Nitrate"	REAL,
	"Nitrite"	REAL,
	"Phosphate"	REAL,
	"EC"	REAL,
	"metadata"	INTEGER,
	PRIMARY KEY("ID" AUTOINCREMENT),
	FOREIGN KEY("metadata") REFERENCES "Metadata"("ID")
);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (1,1,0.1,199.0,'Nitrogen dioxide',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (2,2,0.1,265.0,'Sulphur dioxide',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (3,3,0.1,34.0,'Particulate matter',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (4,4,0.1,49.0,'Particulate matter',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (5,5,0.1,2.0,'Nitrate',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (6,6,0.1,49.0,'Nitrate',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (7,7,0.0,0.1,'Phosphate',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (8,8,0.1,499.0,'Escherichia coli',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (9,9,0.1,184.0,'Intestinal enterococci',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (10,10,0.1,184.0,'Air Temperature',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (11,11,0.1,184.0,'Humidity',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (12,12,0.1,184.0,'Wind speed',0.1);
INSERT INTO "Configuration" ("config_id","sensor_id","min_measurement","max_measurement","type","firmware") VALUES (13,13,0.1,184.0,'Wind Direction',0.1);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (1,'Air quality','Nitrogen dioxide','NO2','ug/m3','microgrammes per cubic metre','Hourly',200.0,'Airly','https://uk-air.defra.gov.uk/air-pollution/daqi?view=more-info&pollutant=no2#pollutant',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (2,'Air quality','Sulphur dioxide','SO2','ug/m3','microgrammes per cubic metre','Hourly',266.0,'Airly','https://uk-air.defra.gov.uk/air-pollution/daqi?view=more-info&pollutant=so2#pollutant',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (3,'Air quality','Particulate matter <= 2.5 microns in diameter','PM2.5','ug/m3','microgrammes per cubic metre','Hourly',35.0,'Airly','https://www.gov.uk/government/statistics/air-quality-statistics/concentrations-of-particulate-matter-pm10-and-pm25',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (4,'Air quality','Particulate matter <= 10 microns in diameter','PM10','ug/m3','microgrammes per cubic metre','Hourly',50.0,'Airly','https://www.gov.uk/government/statistics/air-quality-statistics/concentrations-of-particulate-matter-pm10-and-pm25',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (5,'Water quality','Nitrite','-NO3','mg/l','milligrammes per litre','Hourly',3.0,'ClearWater','https://cdn.who.int/media/docs/default-source/wash-documents/water-safety-and-quality/chemical-fact-sheets-2022/nitrate-and-nitrite-fact-sheet-2022.pdf?sfvrsn=a65406e9_2&download=true',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (6,'Water quality','Nitrate','-NO2','mg/l','milligrammes per litre','Hourly',50.0,'ClearWater','https://cdn.who.int/media/docs/default-source/wash-documents/water-safety-and-quality/chemical-fact-sheets-2022/nitrate-and-nitrite-fact-sheet-2022.pdf?sfvrsn=a65406e9_2&download=true',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (7,'Water quality','Phosphate','-PO4','mg/l','milligrammes per litre','Hourly',0.1,'ClearWater','https://assets.publishing.service.gov.uk/media/5a7b1f23ed915d3ed90624fc/defra-stats-observatory-indicators-da3-120224.pdf',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (8,'Water quality','Escherichia coli','EC','cfu/100ml','Colony forming units (cfu) per 100ml','Daily',500.0,'ALERT','https://environment.data.gov.uk/bwq/profiles/help-understanding-data.html',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (9,'Water quality','Intestinal enterococci','IE','cfu/100ml','Colony forming units (cfu) per 100ml','Daily',185.0,'ALERT','https://environment.data.gov.uk/bwq/profiles/help-understanding-data.html',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (10,'Weather','Air temperature','T','C','Degrees Celcius','Hourly',0.0,'Netvox R712','',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (11,'Weather','Humidity','H','%','Percentage','Hourly',0.0,'Netvox R712','',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (12,'Weather','Wind speed','WS','m/s','Metres per second','Hourly',0.0,'Vaisala WM80','',NULL);
INSERT INTO "Metadata" ("ID","category","quantity","symbol","unit","unit_drescription","measurement_freq","safe_level","Sensor","reference_url","sensor_id") VALUES (13,'Weather','Wind direction','WD','degree','Degrees from north','Hourly',0.0,'Vaisala WM80','',NULL);
INSERT INTO "Roles" ("roleID","title","description","power") VALUES (1,'Administrator','Has full control over all system settings and data',90);
INSERT INTO "Roles" ("roleID","title","description","power") VALUES (2,'Operations Manager','Manages site operations and monitoring tasks',70);
INSERT INTO "Roles" ("roleID","title","description","power") VALUES (3,'Environmental Scientist','Analyses environmental data and reports',60);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (1,1,'Air','https://airly.org/en/features/air-quality-sensors/','2025-04-06',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (2,1,'Air','https://airly.org/en/features/air-quality-sensors/','2023-11-02',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (3,1,'Air','https://airly.org/en/features/air-quality-sensors/','2024-02-16',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (4,1,'Air','https://airly.org/en/features/air-quality-sensors/','2025-03-10',0);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (5,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2023-01-01',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (6,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2023-05-07',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (7,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2024-02-22',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (8,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2025-01-12',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (9,2,'Water','https://clearwatersensors.com/nitrate-sensor.html','2021-01-18',0);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (10,3,'Weather','https://www.alliot.co.uk/product/netvox-outdoor-temperature-and-humidity-sensor/','2024-08-12',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (11,3,'Weather','https://www.alliot.co.uk/product/netvox-outdoor-temperature-and-humidity-sensor/','2025-08-15',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (12,3,'Weather','https://www.vaisala.com/en/products/ultrasonic-wind-sensor-wm80','2024-06-11',1);
INSERT INTO "Sensors" ("sensor_id","site_id","sensor_type","sensor_url","deployment_date","sensor_operational") VALUES (13,3,'Weather','https://www.vaisala.com/en/products/ultrasonic-wind-sensor-wm80','2025-02-11',0);
INSERT INTO "Sites" ("site_id","name","latitude","longitude","elevation","timezone","utc_offset","type","zone","Agglomeration","Local_authority") VALUES (1,'Edinburgh Nicolson Street',55.94476,-3.183991,0,'',0,'Urban Traffic','Central Scotland','Edinburgh Urban Area','Edinburgh');
INSERT INTO "Sites" ("site_id","name","latitude","longitude","elevation","timezone","utc_offset","type","zone","Agglomeration","Local_authority") VALUES (2,'Glencorse B',55.86111111,3.25388889,0,'',0,'','','','');
INSERT INTO "Sites" ("site_id","name","latitude","longitude","elevation","timezone","utc_offset","type","zone","Agglomeration","Local_authority") VALUES (3,'',55.008785,-3.5856323,8,'',0,'','','','');
INSERT INTO "Users" ("UserID","username","name","password","roleID") VALUES (1,'admin','Admin User','123',1);
INSERT INTO "Users" ("UserID","username","name","password","roleID") VALUES (2,'operations','Operations Manager','123',2);
INSERT INTO "Users" ("UserID","username","name","password","roleID") VALUES (3,'env_sci','Environmental Scientist','123',3);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (1,'01/02/2025 01:00:00',26.33,1.33,0.07,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (2,'01/02/2025 02:00:00',23.4,1.52,0.06,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (3,'01/02/2025 03:00:00',28.9,1.32,0.05,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (4,'01/02/2025 04:00:00',22.54,1.41,0.05,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (5,'01/02/2025 05:00:00',29.36,1.61,0.02,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (6,'01/02/2025 06:00:00',25.19,1.42,0.02,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (7,'01/02/2025 07:00:00',25.39,1.26,0.03,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (8,'01/02/2025 08:00:00',23.18,1.63,0.03,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (9,'01/02/2025 09:00:00',27.25,1.26,0.06,0.0,NULL);
INSERT INTO "water_measurements" ("ID","datetime","Nitrate","Nitrite","Phosphate","EC","metadata") VALUES (10,'01/02/2025 10:00:00',29.07,1.4,0.07,0.0,NULL);
COMMIT;
