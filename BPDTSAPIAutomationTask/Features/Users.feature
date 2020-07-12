Feature: Users

Scenario: API_Users_01_Verify that existing records can be retrieved from Users resource
	Given that BPDTSTestApp web services with GET endpoint /users is running
	Then the status code for GET endpoint is equal to OK
	And the following records should be retrived from users
	| first_name |
	| Mechelle   |
	| Terry      |
	| Andrew     |
	| Stephen    |
	| Tiffi      |
	| Katee      |
