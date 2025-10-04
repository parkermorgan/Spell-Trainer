# Overview

Overview

This project is a Spell Trainer and Battle Demonstration implemented in C#, inspired by the Harry Potter franchise. It is divided into two primary components:
	1.	Instruction Module – Allows the user to view and upgrade a collection of spells. Each spell has properties such as name, type, description, and effectiveness value, which can be increased through training.
	2.	Combat Module – Enables the user to engage in battles against a set of enemies. Each enemy instance has unique attributes, including a name, health value, and base damage output. Enemy behavior and battle outcomes vary depending on the spells selected by the user.

Features
	•	Dynamic Combat System: User spell selection directly influences combat results and enemy stats.
	•	User Health Tracking: The player maintains a health value that determines battle continuation.
	•	Persistent Data Storage: User data can be saved to and loaded from .json files, allowing progress to be preserved or different user profiles to be loaded.
	•	Preset User Profiles: The project includes predefined user configurations for testing and demonstration purposes.

Purpose

The project demonstrates class-based design, file serialization/deserialization using JSON, and interactive gameplay mechanics in a C# console environment.

[Software Demo Video]https://youtu.be/PAbrtwBP424

# Development Environment

Tools Used:
    • Visual Studio Code - Code editor used for project development.
    • .NET SDK (C#) - Framework for building and running C# application.
    • System.Text.Json - JSON serialization and deserialization of player and enemy data.
    • C# Standard Library - Core language features.

# Useful Websites

- [C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)
- [How To Serialize JSON in C#](http://url.link.goes.here)
- [Access Modifiers](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)

# Future Work

- Implement an experience feature that increases based on enemies killed. The higher the experience, the strong the spells are.
- Implement the option to add new spells and enemies.
- Remove code redundancies and refine operations, particularly in the combat section.
