# Path of Exile 2 Log Parser

This console app parses the Path of Exile 2 client log and extracts entries related to endgame locations, then displays the results.

## How to use

Place the executable inside the game's `logs` folder, located next to `Client.txt`, and run the application.

## What does it look like?

It’s a simple console window with text output. You can see an example in the screenshot below.

<img width="862" height="628" alt="view" src="https://github.com/user-attachments/assets/6d629fcf-1139-4176-90f9-2a9f4608d576" />

## Notes

- Built with C# and requires .NET 10.
- Processing time depends on the size of the log file.
- For large files (1GB+), parsing may take a while and the console may not update immediately.
