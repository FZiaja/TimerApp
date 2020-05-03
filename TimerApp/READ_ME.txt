This is a Timer application that allows users to set and run a timer.
Timers can be given a timer name and saved to a database.
A list of saved timers will appear on the main page of the application and can be selected at convenience.

This application is a re-design of my previous Timer application.
The previous application worked, but the interface and code were messy, and some features were missing.
The new version will implement SQLite, custom user controls, and the MVVM design pattern.

Here is a list of components that have been tested and are functioning as expected:

Timer-editing interface.
Starting, pausing, resuming, and resetting a timer.
The User Control for displaying timers in a list.
Reading a list of timers from the database.
Saving timers to the database.


The following is a list of items that still need some work:

Clean up the interface.
Organize the code in TimerViewModel.cs.
Selecting a timer from the list of saved timers.
Deleting timers from the database.
Updating timers that already exist in the database.
Implement a better sound when a timer finishes running.
