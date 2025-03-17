# USE CASE 1:
### Manage user access and roles within the application.  

### Goal in Context:
As an Administrator, I want to manage user access and roles within the application to ensure accurate authorisation and permissions for different users.

### Scope and Level:
The functionality of the application that enables the Administrator to assign, modify, and revoke user roles and access privileges.

### Preconditions:
- The system has an authentication and authorisation mechanism.
- The database stores user data, including roles and access permissions.

### Success End Condition:
- The Administrator successfully assigns, modifies, or revokes user roles and access permissions.

### Failed End Condition:
- Unauthorised users have incorrect access.
- The Administrator cannot modify user roles due to a system issue.

### Primary Actor:
Administrator.

### Trigger:
Pressing a button in the dashboard called "User Management".

### Main Success Scenario:
1. The Administrator navigates to the dashboard and clicks on "User Management".
2. The system displays a list of users along with their current roles and permissions.
3. The Administrator selects a user and modifies their role or access permissions.
4. The system updates the user's role and permissions in the database.
5. The system confirms the successful update and logs the action.

### Extensions:
3a. The system fails to update the user role due to an error.
   - The system displays an error message.
   - The Administrator retries the action or contacts support.

3b. The Administrator attempts to assign a role beyond their own privileges.
   - The system restricts the action and notifies the Administrator.

### Sub-variations:
1. The Administrator removes a user's access instead of modifying roles.
2. The Administrator creates a new user and assigns initial roles.

### Schedule:
TBA

