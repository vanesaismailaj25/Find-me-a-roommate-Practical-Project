# Find-me-a-roommate-Practical-Project
Scenario – Find me a roommate
Suppose that you need to build a software to help the college campus organize students into dormitories. Students should be able to post announcements looking for roommates. Also, people interested should be able to apply for a free spot.

Entities
Dormitories Id (int -> pk)
Code (string -> unique)
Name (string)
MaxCapacity (int)

Students Id (int -> pk)
Name (string)
Surname (string)

DormitoryStudent Id (int -> pk)
DormitoryId (int -> fk)
StudentId (int -> fk -> unique)
Capacity (int)

Announcements Id (int -> pk)
Title (string)
Description (string)
PublishedDate (DateTime)
IsActive (bool)

Applications Id (int -> pk)
StudentId (int -> fk)
AnnouncementId (int -> fk)
ApplicationDate (DateTime)
IsActive (bool)
Functionalities

Pre-Work
For simplicity we will register in the database the: - Dormitories
- Students
- Student per dormitories

User Interface
Since you are not familiar yet with the principals and knowledge of the website interface, for this project you are expected to use a simple command line menu. You should be able to print the menu to the console with a code (shortcut) attached for each action for e.g.:
- New announcement (AA)
- Edit announcement (EA)
- New Application (AAPP) etc.

However, if you are familiar with the frontend and feel like taking up a challenge, you can set up a simple UI with the help of your trainer.

Announcements Management
Adding

The user should be able to add an announcement to the database. Additionally, as part of the task, the user should ensure appropriate validation - The title is required
- The description is required
- Do not allow more than one active announcement per dormitory

If incorrect data are entered, the user should be notified via an appropriate message

Listing By selecting the menu option, the user should be able to see all the active announcements in the database. By providing the dormitory id, the user should be able to see if there already is an active announcement.

Applications Management
Adding The user should be able to apply to an announcement by providing the announcement id and the user id.

Additionally, as part of the task, the user should ensure appropriate validation
- The announcement id is required and it exits
- The user id is required and it exits
- The user should be able to apply for a certain announcement only once
- The user should not be possible to apply to a disabled announcement

If incorrect data are entered, the user should be notified via an appropriate message.

Listing By selecting the menu option, the user should be able to see all the active applications in the database.
By providing the announcement id, the user should be able to see its applications.

Additional/Optional
Disabling The user should be able to disable an announcement by providing the announcement id.
If an announcement is disabled, all the applications for it should be disabled too.

Additionally, as part of the task, the user should ensure appropriate validation
- The announcement id is required and it exits

The user should be able to disable a specific application by providing the application id.
Additionally, as part of the task, the user should ensure appropriate validation
- The application id is required and it exits

If incorrect data are entered, the user should be notified via an appropriate message.

Student distribution
The user should be able to accept a student to a dormitory my providing the dormitory id and the student id.
Additionally, as part of the task, the user should ensure appropriate validation.

The dormitory id is required and it exits
The student id is required and it exits
The student shouldn’t be added if the dormitory is at maximum capacity
The user should be able to list all the dormitories that are not at maximum capacity.
The user should be able to list all the students that are not accommodated in a dormitory.
The user should be able to list the students present in a dormitory by providing the dormitory id.

Additionally, as part of the task, the user should ensure appropriate validation
- The dormitory id is required and it exits

The user should be able to view the dormitory for a certain student by proving the student id.

Additionally, as part of the task, the user should ensure appropriate validation
- The student id is required and it exits
- If the student is not accommodated in a dormitory the user should be informed via a message.
