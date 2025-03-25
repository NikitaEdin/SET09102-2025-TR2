# USE CASE 4:
### Generate comprehensive reports on environmental trends.

### Goal in Context:
As a Environmental Scientist i want to generate comprehensive reports on environmental trends.

### Scope and Level:
The functionality of the application that allows the Environmental Scientist to view and generate on environmental trends.

### Preconditions:
The database stores sensor data that includes sensor values and sensor information.

### Success End Condition:
Allows the Environmental Scientist to generate and view environmental trends gathered from the sensor data.

### Failed End Condition:
Not enough data to generate report.

### Primary Actor:
Environmental Scientist.

### Trigger:
Pressing on button in the dashboard called "Generate report".

### Main Success Scenario:
1. The Environmental Scientist views sensors.
2. The Environmental Scientist presses "Generate" button.
3. The system reads the sensor values and calculates an average from the data and calculates trends.
4. Environmental trends report generated.
5. System Displays report to the Environmental Scientist.


### Extensions:
1. The system cannot find sensors in the database.
   - The system returns an error message.
   - The system ends run.
   
2. The system cannot calculate trend too few data values.  
   - The system returns an error message.  
   - The system ends run.  


### Sub-variations:
1. The Environmental Scientist goes to dashboard and presses on "Generate Report".

### Schedule:
TBA