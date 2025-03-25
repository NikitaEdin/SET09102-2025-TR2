# USE CASE 1:
### Manage sensor accounts and configure settings.

### Goal in Context:
As a Environmental Scientist i want to manage sensor accounts and configure settings.

### Scope and Level:
The functionality of the application that allows the enviromental scientist to manage sensor accounts configurations.

### Preconditions:
- The enviromental scientist is logged in and has appropriate permissions to access sensor account management tools.
- System provides interaface for scientist to manage sensor configurations and settings.

### Success End Condition:
- Enviromental scientist has successfully made changes to sensor account settings.

### Failed End Condition:
- The changes to sensor settings is not implemented correctly due to invalid input or system errors.
- The enviromental scientist cannot see the changes reflected in the system.
- Settings are incorrectly saved, leading to inaccurate data in database.

### Primary Actor:
Enviromental scientist.

### Trigger:
The Environmental Scientist clicks the “Settings” option from the sidebar and selects “Sensor Accounts”.

### Main Success Scenario:
1. The system loads Sensor Accounts Configurations Page, showing a list of all sensor accounts.
2. The Enviromental Scientist selects a sensor account to modify.
3. The system displays a form to view and edit sensor details.
4. The Enviromental scientist updates the desired inputs and clicks "Save Changes" button.
5. The system validates the form input and updates database with new data.
6. The system displays a success message, notfiying that the changes have been made.

### Extensions:
2a. System cannot load sensors from database. 
    - The system displays error message.
    - The enviromental scientist reloads the page or contacts technical support team.
5a. System recognises invalid input.
    - System displays error message and reloads form.
    - Enviromental scienist re-enters input correctly.
    - System validates input and updates database with new data.

### Sub-variations:
1. the enviromental scientist chooses to add new sensor account.
2. The enviromental scientist deletes an inactive sensor account.

### Schedule:
TBA