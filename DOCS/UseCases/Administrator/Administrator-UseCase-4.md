# USE CASE 4:
### Manage data storage and configure backup solutions.

### Goal in Context:
As a Administrator i want to oversee data storage and implement backup strategies.

### Scope and Level:
The functionality of the application that allows the administrator to back up data and oversee the storage of data.

### Preconditions:
The Administrator is logged in with the appropriate authorisation and permissions to access data storage.


### Success End Condition:
- The Administrator successfully oversees storage status.
- The Administrator performs backups which are stored correctly.

### Failed End Condition:
- Backup is not created.
- Storage copacities are exceeded without warning.
- Administrator cannot access the backup configurations.

### Primary Actor:
Administrator

### Trigger:
The Administrator navigates to Storage Management Page.

### Main Success Scenario:
1. The system displays storage usage statistics, previous backups, and current configurations.
2. The Administrator reads the storage information displayed and decides to change backup settings.
3. The Administrator selects BackUp Settings button.
4. The system displays backup configurations form.
5. The Administrator alters the frequency of backups and presses "Save Changes" button.
6. The system validates input and implements new backup strategy.
7. The system display success message and reflects the changes made in display.

### Extensions:
1a. Data storage is at capacity.
    - The system displays alert message.
    - The Administrator implements solution to create or free up storage.
4a. Backup configurations are unavailable.
    - The system displays error message.
    - The system navigates back to Storage Management Page.
    - The Administrator fixes issue or contacts technical support team.

### Sub-variations:
1. The Administrator sets up partial backups instead of full backups.
2. The administrator performs a manual back up.

### Schedule:
TBA