## Code structure
- Program begins by calling App class and running the Run function that implements all the other parts of the program mainly split across environment and terminal.
- The terminal handles user inputs and calling of commands, which are structured by classes inside command folder. Each Command inherits form ICommandable for unified structure.
- Environment handles planets (SpaceObject) and the satellite. They are grouped by the World class, but a lot of other classes access satellite directly for convenience.
- Print class handles custom print function, allowing for easy debug toggle and full control over printing.
- FileRegenerator class handles regeneration of program file saving data in the case that they are either missing entirely or in a bad format.

```mermaid
classDiagram
    class Satellite {
        -string Name
        -bool IsConfigured
        -double UnifiedFuelAmount
        -World SolarSystem
        -SatelliteBuilder Builder
        -PositionTracker PosTracker
        -List~SatBattery~ SatBattery
        -List~SatFuelTank~ SatFuelTank
        -List~SatEngine~ SatEngine
        +GetAcceleration() double
        +UnifyFuel() void
        +ChangeOrbitalHeight(int) string
        +ChangeOrbitalSpeed(double) string
        +SnapOrbit(double, double) string
        +ChangePosition(string, int) string
        +Reset() void
    }

    class SpaceObject {
        -string Name
        -int Distance
        -double Weight
        -int Diameter
        -double OrbitalPos
        -double AngularSpeed
        -double PointsMultiplier
        +AddOrbitalPos(double) double
        +CalculateOrbitalPos(double) double
        +ToString() string
    }

    class SatelliteBuilder {
        -List~SatBattery~ SatBatteryList
        -List~SatFuelTank~ SatFuelTankList
        -List~SatEngine~ SatEngineList
        +LoadFilesSafe() void
        -LoadFiles() void
    }

    class SatBattery {
        -string Name
        -string Type
        -char Size
        -int Weight
        -int DegradeTime
        -int Hp
        -int BatteryLevel
        -int Capacity
        -int MaxChargeLevel
        +RecalculateMaxChargeLevel() void
    }

    class SatEngine {
        -string Name
        -string Type
        -char Size
        -int Weight
        -int Hp
        -int Thrust
        -string FuelType
        -int FuelConsumption
    }

    class SatFuelTank {
        -string Name
        -string Type
        -char Size
        -int Weight
        -int Hp
        -int Capacity
        -int FuelLevel
        -int AdditionalWeight
        -int FuelWeightPerKg
        +RecalculateAdditionalWeight() void
    }

    class PositionTracker {
        -int Distance
        -double OrbitalPos
        -double AngularSpeed
    }

    class World {
        -List~SpaceObject~ OrbitingObjects
        -SpaceObject CentralBody
        -Satellite Sat
    }

    class App {
        -bool Debug
        +Run() void
        +RunTerminal(Terminal) void
        +RunEnviroment(Terminal, Satellite) void
    }

    class Terminal {
        -List~ICommandable~ CommandList
        -Satellite Satellite
        -World VirtualWorld
        +Run() void
        +ParseCommand(string) List~string~
    }

    class Menu {
        +SelectMultiple(string, List~string~) List~int~
        +YNoption(string, char) bool
    }

    class ISatellitePartable {
        <<interface>>
    }

    class IDegradeable {
        <<interface>>
    }

    class ICommandable {
        <<interface>>
    }

    Satellite --> SatelliteBuilder
    Satellite --> World
    Satellite --> PositionTracker
    Satellite --> SatBattery
    Satellite --> SatEngine
    Satellite --> SatFuelTank
    
    SatelliteBuilder --> SatBattery
    SatelliteBuilder --> SatFuelTank
    SatelliteBuilder --> SatEngine
    
    World --> SpaceObject
    World --> Satellite
    
    SatBattery --|> ISatellitePartable
    SatBattery --|> IDegradeable
    SatEngine --|> ISatellitePartable
    SatFuelTank --|> ISatellitePartable
    
    Terminal --> ICommandable
    Terminal --> Satellite
    Terminal --> World
    
    App --> Terminal
    App --> Satellite
```

## How to play?
- Once ingame you will be greeted with a welcome message and a terminal you can type into.
- For ingame help or tutorial type "help" or "help tutorial" respectively. The "help" command will show you other options for more detailed help.

## Commands
| Command | Description |
|---|---|
| `sat new` | Build a new satellite |
| `sat status` | Show satellite status |
| `sat travel height` | Change orbital height |
| `sat travel speed` | Change orbital speed |
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

## Linux support
Replace .csproj with this for linux support:


<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <OutputType>Exe</OutputType>
        <TargetFramework>net9.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
        
        <RuntimeIdentifier>linux-x64</RuntimeIdentifier>
    
    	<PublishSingleFile>true</PublishSingleFile>
    	<SelfContained>true</SelfContained>
    </PropertyGroup>

</Project>
