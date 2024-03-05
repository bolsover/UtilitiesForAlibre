# UtilitiesForAlibre

A C# project to generate an Alibre Add-On.

Note that the project has only been tested against Alibre V27 and that there is no warranty for the application.
Your attention is drawn to the included Copyright and License text.

The project distribution does NOT include the required AlibreX.dll, AlibreAddOn.dll or  ObjectListView.2.9.1 dll.
You will need to add these files to the project before it can be compiled.

The project is generally written using the Jetbrains Rider IDE but it should work equally well with Visual Studio 2022.

# Known Issues
DataBrowser. A previous, stand alone version of the data browser could obtain IADSession connections to Alibre, interrogate the Part, Sheet Metal, Assembly and Drawing properties and report these in the application window.
Running the same code within the context of an AddOn requires connecting to the Alibre IADRoot object, obtaining an IADSession, querying the design properties and closing the session.
Closing a session is fine - UNLESS the Part, Assembly etc. is actually already open in Alibre. If the design is open in Alibre, closing the session will cause the design window to close - without saving any changes that may have been made. NOT good!
As a partial fix for this problem, the code now checks if a file is open before opening an Alibre IADSession. If the file is not in use, it is OK to proceed getting the design properties. If the file is already open, the IADRoot.Sessions are searched to find the relevant design and the data retrieved without closing the session.
This fix works for Part, Sheet Metal and Assembly designs but NOT for Drawings. So the present code just ignores any open drawings and does not retrieve the design data. 

DataBrowser can not edit any Alibre file already open elsewhere (assumed to be Alibre). This is intentional and probably can't be fixed anyway. The user is warned if an attempt to edit an open file is made.

# Compile code.
As noted above, AlibreX.dll, AlibreAddOn.dll and  ObjectListView.dll (version 2.9.1) are not included with this code. If you don't have Alibre V27 - well not much I can do about that. ObjectListView can be downloaded here : http://objectlistview.sourceforge.net/cs/index.html

# Installation with Alibre
Installation with alibre is a simple matter of extracting the UtilitiesForAlbreSetup.exe from the release .zip and executing this on your PC.
The installer will create a new folder in your Program Files directory and copy the required files to this location.
The installer will also create a new entry in the Windows Start Menu for the Add-on uninstaller.

# Additional Documentation
http://bolsover.com/utilitiesforalibre/utilities-for-alibre.html


DB
