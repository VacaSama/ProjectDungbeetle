crc-cards (Class–Responsibility–Collaboration) markdown file

# CRC Cards
### Current Models: Entry, UserProfile, Hints, Questionnaire, QuestionnaireResponse


### Entry Model 
** Responsiblities: ** 

- Create, read, log and delete user entries
- Validate entry data to ensure all required fields are filled
- Provide formatted data to display on the dashboard
- Tracks which user created the entry, to avoid every user seeing everyones entries.

** Collaborators: ** 
- UserProfile

### UserProfile Model 
** Responsiblities: ** 
- Store the users questionnaire response information 
- Manage the users personallized entries. 
- Gives the user access to hints

** Collaborators: ** 
- QuestionnaireResponse
- Hints

### Hints Model 
** Responsiblities: ** 
- Provide the user with hints, based on common programmer errors
- Store hints and their associated error types (ex: syntax, logical, etc)

** Collaborators: ** 
- None

### Questionnaire Model 
** Responsiblities: ** 
- Asks the user (if new) a series of questions to determine why they are using the app
- Stores the questions within the database
- Formats the questions in a modal 
- validates the users response to ensure all required fields are filled

** Collaborators: ** 
- QuestionnaireResponse
- UserProfile


### QuestionnaireResponse Model 
** Responsiblities: ** 
- Stores the user response from the questionnaire
- Validates the users response to ensure all required fields are filled
- Tracks user response with the user profile
- Allows the user to update their response to the questionnaire, via user profile


** Collaborators: ** 
- Questionnaire
- UserProfile

### Dashboard ViewModel (coming soon!)
** Responsiblities: ** 
 - Retrieves all models required for the dashboard/home view to function 
 - Shows the user their entries and hints
	- Contains redirects to the user profile and questionnaire response info.

** Collaborators: ** 
- Entry 
- UserProfile
- Hints
- Questionnaire
- QuestionnaireResponse