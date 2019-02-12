<html>
<head><h1>Athlete Data Tracker</h1></head>
<body>
<p>I designed this Athlete Data tracker using C# in Visual Studio along with MySQL for the user databases.</p>
<br>
<p>The Athlete tracker is built to aid athletes competing in triathalons log their data of Cycling/Running/Swimming to a secure database hidden behind their login (Username and Hashed Password)
The program will log data and perform calculates such as generating average times/best times the user has performed, outputs this data from the database to a table which the user can sort depending on each event.
If the user competes in a team it also has a Team Picker section for users to pick from the currently registered users other well performing users to join their team to compete or to just compare data with.
</p>
<br>
<p>The application has a register form for users to register their accounts with the MySQL database and private user data such as passwords is hashed before being secured</p>
<p>The user also has the option to amend details within their account page on the application</p>
<p>Their is an administrator page that allows an admin to view all users and amend any details they deem necessary</p>
<p>The MySQL server is not currently hosted as it is an old project so I have set the server to localhost on the application for any users wishing to host it themselves</p>
<p>
Server=localhost;
user id=db_user;
password=microsoft;
Database=traininglog;
</p>
</body>
</html>
