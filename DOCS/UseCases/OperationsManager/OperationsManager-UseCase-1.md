# USE CASE 1:
### Monitor the operational status of sensors.  

### Goal in Context:
As an Operations Manager, I want to monitor the operational status of sensors to ensure that they are functioning correctly and providing accurate data, as expected.

### Scope and Level:
The functionality of the application that allows the Operations Manager to view real-time status updates of all deployed and available sensors.

### Preconditions:
- The database stores real-time sensor data, including operational status and activity logs.
- The sensors are connected to the system and transmitting data.

### Success End Condition:
- The Operations Manager can see real-time operational status for all sensors and potentially identify any issues.

### Failed End Condition:
- The sensor status is not updated correctly.
- The Operations Manager cannot access the sensor status information.

### Primary Actor:
Operations Manager.

### Trigger:
Pressing a button in the dashboard called "Sensor Status".

### Main Success Scenario:
1. The Operations Manager navigates to the dashboard and clicks on "Sensor Status".
2. The system retrieves real-time data from the available sensors.
3. The system displays the current operational status of all available sensors.
4. Any offline or malfunctioning sensors are listed or highlighted.
5. The Operations Manager reviews the status and takes appropriate action if needed.

### Extensions:
3a. The system fails to retrieve real-time sensor data.
   - The system displays an error message.
   - The Operations Manager retries or contacts support.

3b. A sensor's operational status is unclear or delayed.
   - The system marks the sensor as "Status Pending" and retries data retrieval.

### Sub-variations:
1. The Operations Manager applies filters to view specific sensor types or locations.
2. The Operations Manager exports sensor status reports for further analysis.

### Schedule:
TBA

