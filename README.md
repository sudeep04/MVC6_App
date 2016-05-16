# MVC6_App
This is an example web app using ASP Net 5. 

The initial setup is completely different in the latest version. This will give a quick overview of running a basic ASP web app

Setup:
Intall ASP Net 5 by using the instructions here
https://docs.asp.net/en/latest/getting-started/installing-on-windows.html

Intall SQL Server management studio 2014

Create  an empty database called TestDB in it
and change the connection string in appsettings.json

Open CMD prompt at the project folder and run the following commands, It will create the table structure in the database
dnu restore
dnvm use 1.0.0-rc1-final -p
dnx ef migrations add Initial
dnx ef database update

