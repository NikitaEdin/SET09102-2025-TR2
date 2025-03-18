# USE CASE 2:
### Maintain high levels of system security and data protection.

### Goal in Context:
As an Administrator, I want to maintain high levels of system security and data protection as to ensure that data cannot be obtained or altered in unintended ways.

### Scope and Level:
The functionality of the application that allows the administrator to manage access to specific datasets, user access, and oversee maintenance plans.

### Preconditions:
- The system's authorisation mechanism
- The user role information
- The maintenance log

### Success End Condition:
Allows the administrator to edit system access, oversee datasets, and oversee maintenance plans to ensure that there is no vulnerabilities in the organisation setup.

### Failed End Condition:
A vulnerability is found in the system or data is obtained or edited in a way that was not intended.

### Primary Actor:
Administrator

### Trigger:
Accessing the maintenance log section, or editing authorisation/role configuration.

### Main Success Scenario:
1. The administrator navigates to the maintenance log or authorisation configuration views.
2. The administrator may view or change authorisation configuration.
3. If changes were made, the system will update and propogate authorisation information.
4. The system will confirm that committed actions were completed.

### Extensions:
3. An error occurs while trying to update cconfiguration
  - The system will display an error message

### Sub-variations:
1. The administrator updates data authorisation information.

### Schedule:
TBA
