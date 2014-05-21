TEAMS-Module
============

The respository for the TEAMS Module being developed at the Rochester Institute of Technology to go onto the GREET Model of emissions tracking and lifecycle analysis.

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
=========

Public interface for GREET project

More information on the GREET-API can be found at: http://greet.es.anl.gov/greet/

The GREET-API git repo is available here: https://github.com/greet-dev/GREETAPI

=========

Public interface for GREET project

GREET API for plugin

GREET is now capable of loading plugin in order to extend functionalities. We are at the early stages of developing this API so we do appreciate any comments that may help us improving.

The plugin page shows examples of plugin that have been developed using the interface.

Documentation about the available methods and classes is available as HTML

The project containing the interfaces and some examples is available from GitHub https://github.com/greet-dev/GREETAPI

You can communicate with the GREET development team online on our irc webchat
Getting started

In order to familiarize yourself with the available methods and objects we created examples available from the archive. Example1 lists all pathways and allows you to observe the total GHGs for a selected pathway. Example2 allows the user to find a parameter and change the user value by the model, then allows to run another simulation.

Examples source code can be downloaded and tested by following these instructions:

    1) Download the Interfaces and examples on the GitHub repository
    2) Extract and open the GreetAPI-Examples.sln using VisualStudio 2010 or above:
    3) We need to configure Visual Studio so that it runs GREET and automatically load the plug-ins in debug mode.       This allows you to debug your work using the Visual Studio IDE.
    In order to do so we'll need to configure the Debug and Post-Build actions for all projects under the solution.
    First right click the Example1 project and select "Properties"
    4) In the properties pane, select the "Debug" tab
    In the debug tab edit the paths to the greet executable. GREET is installed in a sub-folder of your personal         folder, but the easiest way to find the exact location is by running GREET, then click the "About" menu, then        "About..." A new window will pop up, the installation location can be seen at the bottom.
    5) In the properties pane, select now the "Build" tab
    In the build tab edit the path to GREET with your own folder path.
    It is also possible to copy the plugins in the folder "My Documents\Greet\Plugins\". GREET checks if that folder     contains plugins at startup. See more details in the following chapter about the plugins life cycle.
    If you choose to do so, replace the path to greet with the "My Documents\Greet\Plugins\" folder in the Post-build     event command line.
    6) Test your plugin by starting it in Debug mode:
    When running in Debug mode you can put breakpoints in your code and easily follow the execution of the program       for your plugin.
    For this example you should see the menu item "Example1" created by the plugin.

Plugin Life Cycle

Plugins are loaded into GREET at startup before the data file is loaded and before the main interface is started. We are looking to load plugins from two different locations: The first location we're looking into is the folder in which the greet.exe file is located. In this folder we are loading the modules provided by the GREET development team.

For user generate plugins it is preferable to copy them into the folder : "My Documents\Greet\Plugins\" that we also explore in order to find libraries.
The main advantage of using this location is that these plugins will be loaded regardless of the real location of the executable. As GREET is released using ClickOnce, the real location of greet.exe is subject to change when there is an update.

After an instance of the plugin class is created, the first call to a plugin is InitializePlugin. This call offers to the developer an instance to the controler class that can be used for the plugin. The controler class is very important and provides access to the loaded database and to commands such as RunSimulations().

After that the plugin will receive multiple calls: when a data file is loaded the onDatabaseLoaded() method is called, when the main user interface of GREET is loaded, the plugin calls will be GetMainButton() and GetMainMenuItems(). You can override these methods to provide the main user interface with a list of Buttons or ToolStripMenuItems that will be loaded into the main window of GREET. There are many calls that can be used and we suggest you to look in the APlugin class for an exhaustive list of all the existing methods.

Finally when the user chooses to close GREET, the plugin is called twice. The first call is onMainFormClosing() at this point we are starting to close the software, but we haven't checked for database changed yet. It is then a good time for your plugin to push data changes before a message asks the user to save or not his changes. The last call is onFinalizePlugin() at this point all resources are unallocated and GREET execution is about to be terminated. 


EPPlus
=========

TEAMS uses the standard EPPlus version 3.1.3 binary to export data to a .xlsx file. We have included the source code for EPPlus 3.1.3 and the LGPL license for EPPlus in the /EPPlus directory within our repository. EPPlus.dll is provided as-is and no ownership of the library is implied.

More information on EPPlus can be found at http://epplus.codeplex.com/
