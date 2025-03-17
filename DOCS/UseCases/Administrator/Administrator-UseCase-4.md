# USE CASE 4:
### Update sensor configurations and firmware.

### Goal in Context:
As a Administrator i want to update sensor configurations and firmware. 

### Scope and Level:
The functionality of the application that allows the administrator to update sensor settings and update the firmware.

### Preconditions:
The database stores sensor data including configurations to be updated and storing firmware information to be updated.

### Success End Condition:
Allows the administrator to update sensor settings and update firmware, and that get's reflected in the database.

### Failed End Condition:
Update to the configuration or firmware failed.

### Primary Actor:
Administrator.

### Trigger:
Pressing on update firmware or configuration buttons.

### Main Success Scenario:
1. The Administrator presses either "update firmware" or "update configuration" button.
2. Depending on what the administrator presses the relevant page loads and allows the administrator to change configuration values or update sensor firmware.
3. The system then updates the configuration values or updates the firmware of the sensor based on the input from the administrator.
4. System Outputs update complete.


### Extensions:
2. The system cannot find the sensor in the database.  
   - The system returns an error.  
   - The system ends run.  


### Sub-variations:
1. The Administrator goes to view sensors and presses on either update configuration or firmware.

### Schedule:
TBA