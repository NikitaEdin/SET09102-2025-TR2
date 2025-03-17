# USE CASE 4:
### Address and report sensor malfunctions or anomalies.

### Goal in Context:
As a Operations Manager i want to address and report sensor malfunctions or anomalies 

### Scope and Level:
The functionality of the application that allows the Operations Manager to view and report on sensor malfunctions or anomalies if there are any errors or anomalies with the sensors.

### Preconditions:
The database stores sensor data that includes sensor values and sensor information.

### Success End Condition:
Allows the Operations Manager to check if there are any inaccuracies or errors with any of the deployed sensors. And allow the Operations Manager to report on these malfunctioning sensors.

### Failed End Condition:
Malfunctioning sensors are not being detected.

### Primary Actor:
Operations Manager.

### Trigger:
Pressing on button in the dashboard called "Errors & Malfunctions"

### Main Success Scenario:
1. The Operations Manager presses "Errors & Malfunctions" button.
2. The system reads the sensor data and if a sensor is behaving unexpectedly or is offline it gets displayed to the operations manager.
3. If there are sensors offline or malfunctioning it gets flagged and displays affected sensors and allows the operations manager to report on the malfunction.
4. System submits report.


### Extensions:
2. The system cannot find a malfunctioning sensor in the database.  
   - The system returns an message.  
   - The system ends run.  


### Sub-variations:
1. The Operations Manager goes to dashboard and presses on "Errors & Malfunctions".

### Schedule:
TBA