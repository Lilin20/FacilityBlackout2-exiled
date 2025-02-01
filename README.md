# Facility Blackout 2

**Facility Blackout 2** is a plugin that initiates blackous in various facility zones. It offers numerous configuration options to customize the frequency, duration, and zones of the blackouts.
It is a rework of my first plugin called "Facility Blackout".

## Features
- **Zone-based Blackouts**: Choose specific zones for blackouts (e.g., Entrance, Light Containment, Heavy Containment, Surface).
- **Flexible Timing Control**: Configure start delay, frequency, and duration of blackouts.
- **Cassie Integration**: Enable automated announcements during blackouts.

## Installation
1. Download the plugin.
2. Copy the file to your server's plugin directory.
3. Restart the server.

## Configuration
- `IsEnabled`: `true`  
  - Enables or disables the plugin.

- `Debug`: `false`  
  - Activates debug mode for detailed logs.

- `BlackoutZones`:  
  - `Entrance`
  - `LightContainment`
  - `HeavyContainment`
  - `Surface`
  Specifies the zones where blackouts will occur.

- `BlackoutAmount`: `5`  
  - Number of blackouts per round.

- `BlackoutRoundStartDelay`: `150`  
  - Initial delay (in seconds) before the first blackout.

- `BlackoutMinimumDelay`: `120`  
  - Minimum time (in seconds) between two blackouts.

- `BlackoutMaximumDelay`: `180`  
  - Maximum time (in seconds) between two blackouts.

- `BlackoutDelayBetween`: `60`  
  - Delay (in seconds) between individual blackout events.

- `BlackoutDuration`: `60`  
  - Duration (in seconds) of each blackout.

- `CassieEnabled`: `true`  
  - Enables or disables Cassie announcements during blackouts.

- `CassieText`:  
  - `"LIGHT SYSTEM MALFUNCTION . REPAIRING SYSTEMS"`
  - Customizable text for Cassie announcements.

## Contributing
Contributions are welcome! Simply create a pull request or open an issue if you have suggestions or found bugs.
