TEAMS-Module
============
[Webpage.](http://rit-lecdm.github.io/TEAMS-Module/)

This is the respository for the TEAMS Module being developed at the Rochester Institute of Technology to go onto the GREET Model of emissions tracking and lifecycle analysis.

Overview
--------

TEAMS stands for Total Energy and Emissions Analysis for Marine Systems. TEAMS is the first-ever model able to calculate total fuel-cycle emissions and energy use for marine vessels. The model has been updated to serve as a plugin within GREET and uses GREET pathways to do its calculations.

More information on the TEAMS Model can be found at: http://www.rit.edu/cla/teams/

Workflow
--------

The basic workflow for this project is as such: 

1) Install the plugin by placing the compiled .dll file in the folder containing the greet.exe file (Can be found by opening GREET and going to the about button in the about tab)

2) Open GREET and then click on the new TEAMS plugin

3) Agree to the copyright information

4) Upon opening TEAMS, you may access and edit the various input values from their default state and make them reflect the values your particular analysis requires

5) When you are ready to submit each tab, scroll to the bottom and hit the submit button

6) Once all tabs are submitted you are eligible to run the simulation and get your results.

Summary and Notes
=========
Some of the important reasons for creating this module instead of maintaining the TEAMS spreadsheet model that has been a highly functioal tool for a number of years at this point, is that integration with GREET would make the lifespan of a given distribution of TEAMS would be drastically improved, since there would no longer need to be updates every time GREET updated their database of values, since the values would be taken directly from the database, and not hard coded as in the Spreadsheet.

Notes: If you are interested in developing for this platform, there are a few things that you'll need to be aware of.
1) You will need to find the folder that contains the greet.exe, so that you can place your plugin.dll in that location.

2) You will also need to be aware of the GREET database file that is located in the same folder as the plugins, but under the subfolder of database and will be named either default, or whatever the user is currently using (Since you can change the database and make your own forked versions of it). This is important because it is how you will find the ID numbers for all of the pathways, which results in being able to access all of the GREET data. These numbers are the primary keys for getting at the database information, which needs to be examined in a code editor to most basically view the data. Personally, I've been using NP++ and recommend it for this purpose.

Also Includes GREET-API

Video Tutorials are available on our [webpage.](http://rit-lecdm.github.io/TEAMS-Module/)

=========

Public interface for GREET project

More information on the GREET-API can be found at: http://greet.es.anl.gov/greet/

The GREET-API git repo is available here: https://github.com/greet-dev/GREETAPI


EPPlus
=========

TEAMS uses the standard EPPlus version 3.1.3 binary to export data to a .xlsx file. We have included the source code for EPPlus 3.1.3 and the LGPL license for EPPlus in the /EPPlus directory within our repository. EPPlus.dll is provided as-is and no ownership of the library is implied.

More information on EPPlus can be found at http://epplus.codeplex.com/
