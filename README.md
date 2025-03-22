# Weather Monitoring and Reporting System

This is a C# console application that simulates a real-time weather monitoring and reporting service. The system uses various design patterns such as Observer, Factory, and Strategy to provide a flexible and extensible architecture for handling weather data.

## Features

- Weather Monitoring Bots: Includes RainBot, SunBot, and SnowBot, which react to incoming weather data based on configurable thresholds.

- Configurable Bots: Bot configurations are loaded from an external JSON file, allowing easy customization.

- Multiple Data Formats: Supports weather data input in JSON and XML formats.

- Design Patterns: Uses Observer pattern for notifying bots and Factory pattern for creating bot instances.

## Technologies Used

- C#

- .NET Core

- Newtonsoft.Json (for JSON parsing)

- Observer, Factory, and Strategy design patterns

## Project Structure

```
├── Config                    # Configuration files (botconfig.json)
├── Interfaces                # Interfaces for Bot and Data Parsing
├── Models                    # Data Models and Enums
├── Services                  # Core Services (Bot implementations, WeatherDataParser, etc.)
├── Utilities                 # Main Menu handling
├── Program.cs                # Application entry point
├── README.md                 # Project documentation (this file)
```

## Configuration

The bot configurations are stored in `botconfig.json`:

```
{
    "RainBot": {
      "Enabled": true,
      "Threshold": 70,
      "Message": "It looks like it's about to pour down!"
    },
    "SunBot": {
      "Enabled": true,
      "Threshold": 30,
      "Message": "Wow, it's a scorcher out there!"
    },
    "SnowBot": {
      "Enabled": false,
      "Threshold": 0,
      "Message": "Brrr, it's getting chilly!"
    }
}
```

## How To Run The Application

1. Clone the repository and navigate to the project directory.

2. Make sure you are on the desired branch (main or dev).

    `git checkout <branch-name>`

3. Build the project:

    `dotnet build`

4. Run the project:

    `dotnet run`

## Usage

- After running the program, you will see a menu with options to enter weather data or exit.

- Enter weather data in either JSON or XML format. Example:

  ```
  {"Location": "City Name", "Temperature": 32, "Humidity": 40}
  ```

- The program will process the data and activate the relevant bots based on the configuration.

## Future Improvements

- Implement persistent data storage (e.g., save weather reports).

- Add more bots for different weather scenarios (e.g., WindBot, StormBot).

- Improve UI for better user interaction.

## License

This project is licensed under the MIT License.
