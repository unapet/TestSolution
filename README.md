This application is created as an assignment for Play Studios.

I used asp .net core mvc architecture with controllers and views to represent models.
Also I used Microsoft Identity for authentication and authorization.
For db I used Microsoft SQLExpress with entity framework core, you need to have it instaled before or change the connection string to your db.

I added a test coverage only for one controller, the test logic should be more or less the same for the rest.
I implemented SmtpClient for sending the mail, please when you login and sign in use existing email to test
this funtionality.

Email verification will be used for email confirmation and also when user is forgeting the password.

Before starting the app you need to run migration: 
  - Open Package Manager Console in your visual studio and write "dotnet ef database update"
  - This should run migration that is already added (Initial)
    
When starting the app please set as startup project "ProductStore" from the drop down.
Front end is basic so please don't pay a lot attention :) 
I didn't have a time to implement the swagger, but you can check here https://github.com/unapet/AuthenticationExample
how I implemented swagger ui with bearer token authorization earlier.

I added product controller in order for the login user to add new product or list existing ones.
Only logged user can add new products, but all can get the existing.

If there is anything to ask please contact me at unapet998@gmail.com



