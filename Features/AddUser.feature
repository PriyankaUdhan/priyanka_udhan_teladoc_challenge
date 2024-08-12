Feature: User Management 

Add, delete and edit an user
More Scenarios like below can be added like the ones as follows:

ADD USER
1 Add a valid user
2 Add an existing user
3 Add a recently deleted user
4 Add user with all the fields entered in the user details popup
5 Add user with only required fields entered in the popup
6 Add a user with invalid details filled in the popup i.e. Email, Name, etc.
7 Closing the add user popup after entering the fields
8 Closing the add user popup without entering the fields


DELETE USER
1 Delete existing user
2 Delete the single user in the webtable (only one user exists in the webtable)
3 Click on cancel button on the popup

@UserManagement
Scenario: Add a new User
	Given Open the browser
	When Enter the URL
	Then Add a new User

@UserManagement
Scenario: Delete a User
	Given Open the browser
	When Enter the URL
	Then Delete a User
