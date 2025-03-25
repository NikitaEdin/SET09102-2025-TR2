# USE CASE 3:
### Receive real-time alerts on threshold breaches, displayed on an interactive map.

### Goal in Context:
As an Environmental Scientist I want to receive real-time alerts on threshold breaches, displayed on an interactive map, so that I know about and can respond to exceptional circumstances.

### Scope and Level:
The functionality of the application that allows the Environmental Scientist to enable push notifications & view threshold breaches.

### Preconditions:
- The application has push notifications enabled.
- The application shows exceptional sensor readings on an interactive map.

### Success End Condition:
- The Environmental Scientist successfully receives push notifications of threshold breaches and can view information about them.

### Failed End Condition:
- Push notifications are sent too frequently/not enough.
- The interactive map does not show threshold breaches

### Primary Actor:
Environmental Scientist

### Trigger:
- Presses a threshold breach notification
- Opens the interactive map

### Main Success Scenario:
1. The Environmental Scientist navigates to the interactive map via the app button or push notification
2. The system retrieves information about sensor readings associated with geographic information
3. The system displays it on an interactive map along with clickable buttons for exceptional sensor readings
4. The Environmental Scientist can view information about threshold breaches

### Extensions:
2. The system fails to retreive sensor reading information
    - Error message is displayed

### Sub-variations:
4. The Environmental Scientist taps on a specific geographical sensor reading and views information associated.

### Schedule:
TBA
