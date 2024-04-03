I love playing Football Manager. Something I discovered recently, is that you can create your own custom regens that will come through the youth facilities. This is done by creating a .edt file with a very specific line of text, detailing the properties of the player.

Looking around to find a tool to automate the making of this file resulted in discovering that this doesn't exist yet. So, being a programmer that loves Football Manager, I created my own tool for it.

This simple tool allows the user to set the properties of the regen they want to create. In the background, the tool makes sure that the properties are saved into a string correctly, so that the player is generated correctly.

There are 2 pages with properties that can be filled in:

The first page holds the required properties. These properties are required to be filled in by the game in order to create a player. The second page holds the optional properties. These properties are not required to create a player and, if left blank, will be randomised by the game.

This tool was made in C#, using WPF for the UI elements.

Features:
* Creating a list of players
* Exporting file with all players

Future features:
* Display created players
* Edit previously created players
* Import previously made file
