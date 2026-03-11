commonality-variablility markdown file 

# Commonality and Variability Analysis

## Commonalities
- An entry must consist of a title, code snippet,coding language and created/updated at timestamps.
- The Dashboard Creates, Reads, Updates and Deletes entries
- The User Profile stores the questionnaire information and basic user information like their name.

## Variabilities
- Required Notes => Nullable Notes
  - Why it may change:
	
	Not every user may want to add notes to their entry, 
	they might want to just save a title and a code snippet without any additional information.
	Especially if the user is in a hurry or just wanting to save a code snippet for later reference.
	
  - How it is isolated:
	
	Currently the notes field is required because there is no separate page or form for Notes ONLY, 
	that reference it's attached entry. There is also no blank notes section that allows the users
	to add general notes that are NOT attached to a specific entry.

- Questionnaire Schema
  - Why it may change:
	
	As the user progresses from a student to a professional, the "Self-Reflection" goals may change.
	A student cares about learning a language, whereas a seasoned programmer cares about project milestones. 
	The system needs to support different sets of questions without breaking the User Profile.
	
  - How it is isolated:
	
	Isolated via a Configuration Object, instead of hard-coding quesion 1, question 2 etc, etc, 
	into the Questionnaire table, I have an Options property that can store multiple questions 
	and options. 
