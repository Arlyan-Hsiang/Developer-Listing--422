# Refactoring Work 08/02/2021
    AccountController.cs
    1. Move the sql command into Account.cs.
    2. Catch Exception.
    3. Remove unnecessary using directive.
    4. Show the message when update, insert or delete is not working.
    5. Due to the 4., reomove the Get() before update and delete.
    6. Add program notes.

    Account.cs
    1. Change Get() logic to query once.
    2. Change amount format to decimal.
    3. Use string builder for sql command to keep it tidy and easy for    
       expanding.
    4. Remove unnecessary using directive.
    5. Put '' for the number of insert() to make sure it doesn't miss 0.
    6. Return error when update, Insert or delete is not working.
    7. Remove unnecessary variables.
    8. Add program notes.

    TransactionController.cs
    1. Move the sql command into Transactions.cs.
    2. Move the sql command related to updating Account into Account.cs
    2. Catch Exception.
    3. Restore for updating.
    4. Remove unnecessary using directive.
    5. Add program notes.

    Transactions.cs
    1. Change the Date format into string for presenting correctly.
    2. Use string builder for sql command to keep it tidy and easy for    
       expanding
    3. Remove unnecessary using directive.
    4. Remove unnecessary variables.
    5. Add program notes.

    Helpers.cs
    1. Rename to ConnectDB.cs.
    2. Move into the Model folder.
    3. Use string builder for sql command to keep it tidy and easy for    
       expanding.
    4. Remove unnecessary using directive.

# Refactoring Assessment

This repository contains a terribly written Web API project. It's terrible on purpose, so you can show us how we can improve it.

## Getting Started

Fork this repository, and make the changes you would want to see if you had to maintain this api. To set up the project:

 - Open in Visual Studio (2015 or later is preferred)
 - Restore the NuGet packages and rebuild
 - Run the project
 
 Once you are satisied, replace the contents of the readme with a summary of what you have changed, and why. If there are more things that could be improved, list them as well.

The api is composed of the following endpoints:

| Verb     | Path                                   | Description
|----------|----------------------------------------|--------------------------------------------------------
| `GET`    | `/api/Accounts`                        | Gets the list of all accounts
| `GET`    | `/api/Accounts/{id:guid}`              | Gets an account by the specified id
| `POST`   | `/api/Accounts`                        | Creates a new account
| `PUT`    | `/api/Accounts/{id:guid}`              | Updates an account
| `DELETE` | `/api/Accounts/{id:guid}`              | Deletes an account
| `GET`    | `/api/Accounts/{id:guid}/Transactions` | Gets the list of transactions for an account
| `POST`   | `/api/Accounts/{id:guid}/Transactions` | Adds a transaction to an account, and updates the amount of money in the account

Models should conform to the following formats:

**Account**
```
{
    "Id": "01234567-89ab-cdef-0123-456789abcdef",
	"Name": "Savings",
	"Number": "012345678901234",
	"Amount": 123.4
}
```	

**Transaction**
```
{
    "Date": "2018-09-01",
    "Amount": -12.3
}
```