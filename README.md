
# Wolcen Character Data Reader/Writer for C# .NET 6

## Description

This is a C# WPF .NET 6 library that simplifies editing Wolcen character JSON files. It allows users to make changes to their character without writing any JSON script manually.

## Features

- Easy to integrate with existing C# .NET 6 projects.
- Directly read character data into a C# class.
- Backup existing character data before making changes.
- Separate Item class for easier item creation and manipulation.

## Installation

1. Clone this repository or download the zip file.
2. Add the project to your existing C# WPF .NET 6 solution.
3. Add a reference to this project in your main project.

## Usage

### Reading Character Data

```csharp
CharacterData characterData = new CharacterData("PATH TO WOLCEN CHARACTER");
```

Now you can access any field that you would normally find in the raw JSON file.

### Saving the file is simple!

```csharp
CharacterData characterData  = new CharacterData("PATH TO WOLCEN CHARACTER");
characterData.Save();
```

This will create a `backups` folder in the base directory of the save file and copies the existing character file into that folder, iterating it so that no overwrites occur. Then proceeds to write the new file in place of the backedup save file we opened it with.

## Contributing

Feel free to contribute by submitting pull requests.

## License

MIT License
