# USE CASE 3:
### Verify the accuracy and integrity of collected data.

### Goal in Context:
As a Operations Manager I want to verify the accuracy and integrity of collected data.

### Scope and Level:
The functionality of the application that allows the Operations Manager to validate data accuracy and quality.

### Preconditions:
- The data validation rules have been predefined in the system.
- The Operations Manager has permisssions to access data to view and verify it.

### Success End Condition:
- The Operations Manager successfully reviews collected data, identifies mistakes, and verifies that data meets predefined quality standards.

### Failed End Condition:
- Collected data contains errors that go unnoticed.
- The Operations Manager cannot access data to validate it.

### Primary Actor:
Operations Manager

### Trigger:
The Operations Manager clicks "Verify Collected Data" option on dashboard.

### Main Success Scenario:
1. The system loads Data Validation page.
2. The system retrieves the recently collected, unreviewed data from database.
3. The system runs checks on the data and displays mistakes.
4. The Operations Manager reviews the systems checks.
5. The Operations Manager performs manual checks on data, excluding faulty data and approving rest.
6. The system saves the changes made and logs the audit.

### Extensions:
1a. The system cannot retrieve the data.
    - The system shows error message.
    - The Operations Manager reloads system.
    - The Operations Manager contacts technical support team.

### Sub-variations:
1. The Operational Manager identifies a major issue with data accuracy and alerts team.

### Schedule:
TBA