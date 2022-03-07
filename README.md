# DataBrowserForAlibre

A C# project designed to allow users to browse Alibre data files and display Design Properties.

Note that the project has only been tested against Alibre V24 and that there is no warranty for the application.
Your attention is drawin to the included Copyright and License text.

The project distribution does NOT include the required AlibreX.dll; you will need to add that file to the project before it can be compiled.

The project is generally written using the Jetbrains Rider IDE but it should work equally well with Visual Studio 2022.

![DataBrowserForAlibre](https://user-images.githubusercontent.com/32017426/154139069-68aa51e5-d517-46b6-9165-211df5f5c321.jpg)

## Selecting Alibre Parts and Assemblies for editing
Selection of parts and assemblies is a simple matter of checking the relevant item/directory in the tree.
Once items have been selected, the Alibre files are read and data is shown in the browser.
Currently, only Alibre Part and Assemblies are available for editing.

## Columns
There are so many Alibre design extended properties it is quite likely users don't use them all. By right clicking the table header, you can select which columns to display by default. Once you are happy with the display, click the 'Save State' button and the arrangement will be saved to file (%AppData%/DataBrowser/table.settings)

## Part numbering
The Part # column is available for editing in the same way as other text based columns. Alternatively you can use the Part numbering feature to automatically re-number all selected Part and Assembly files. 

## Copy to all selected
When checked, edits in one column/field are copied to all other selected parts and assemblies.

## Materials
Material changes can only be applied to Part files.
When selecting a part for a material edit, the popup material selector does not currently select the exiting material from the dialog.

## Limitations and Known Issues

Yes, there are bugs! But I have done my level best to ensure these do not cause any corruption of the Alibre files. 
The known issues are generally around performance and the user getting over eager to perform edits before all data has been retrieved from the selected files.
If the application crashes - it's most likely that the user is being over eager - please give the application time to complete long running tasks!! I know this is a prolem and I'm working on some fixes.

Almost all of the Alibre design and extended design properties are availale for edit. Of the extended design properties only the Material property is not expoded for editing. I did this deliberately because changing the 'standard' Material design property will overwite any text entered in the extended property. This is a 'limitation' imposed by Alibre and while Alibre warns the user that the overwrite is about to take place, this software does NOT.

## Version Comment

The version comment is not currently available for display or editing; this is a restriction imposed by the AlibreX.dll which does not expose this property to the user.

## Version 1.0.0.5
Changed to the retrieval of Alibre data to occur when a directory is expanded rather than when a checkbox is selected. This makes the system more responsive. Additionally, Alibre data is no longer cleared when an item is deselected.
Retrieval of Alibre data happens only once. If files are added to a directory already expanded, they will only show after application restart.
Added facility to display and edit Alibre drawing description and part numbers.

DB
