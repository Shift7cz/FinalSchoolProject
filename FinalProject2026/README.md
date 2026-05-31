## Code structure
- Program begins by calling App class and running the Run function that implements all the other parts of teh program mainly split across environment and terminal.
- Terminal handles user inputs and calling for Commands, which are structured by classes inside Command folder. Each Command inherits form ICommandable for unified structure.
- Environment handles planets (SpaceObject) and the satellite. They are grouped by the World class, but a lot of other classes access satellite directly for convenience.
- Print class handles custom print mechanics allowing for easy debug toggle and full control over printing.
- FileRegenerator class handles regeneration of program file saving data in the case that they are either missing entirely or in a bad format.

## How to play?
- Once ingame you will be greeted with a welcome message and a terminal you cna type into.
- For ingame help or tutorial type "help" or "help tutorial" respectively. the "help" command will show you other options for more detailed help options.

## Commands
| Command | Description |
|---|---|
| `sat new` | Build a new satellite |
| `sat status` | Show satellite status |
| `sat travel height` | Change orbital height |
| `sat travel speed` | Changes orbital speed |
| `sat travel object` | Travel to a planet |
| `sat travel snap` | Fine position adjustment |
| `scan [planet]` | Scan a planet for points |
| `objects` | List all planets |
| `time [days]` | Skip time |
| `points` | Show current points |
| `help [command]` | Show help |

## Licence
- This code if fully free and OpenSource for everyone EXCEPT my classmates during the duration of the final project submission window ending May 31. at 23:55 2026.
- This code comes as is with no warranty.