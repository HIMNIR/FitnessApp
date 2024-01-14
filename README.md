FitnessApp

Overview
The FitnessApp is a cross-platform mobile application built using the .NET MAUI framework, designed to assist users in tracking their fitness goals, daily activities, and nutrition. The app offers a user-friendly interface to manage user information, set fitness goals, and monitor daily progress.

Functionalities
1. User Information
User Details: Allows users to input and save personal details such as name, age, gender, weight, and height.
BMI Calculation: Automatically calculates the Body Mass Index (BMI) based on the provided weight and height.

2. Fitness Goals
Goal Setting: Users can set daily fitness goals for steps, calories, protein intake, carbs, sugar, fiber, fat, and water consumption.
Persistent Storage: Utilizes JSON serialization to store and retrieve user-specific fitness goals persistently.

3. Daily Activity Tracking
Accelerometer Integration: Uses the device's accelerometer to track and count steps, providing real-time feedback to users.
Nutrition Tracking: Users can log daily food intake, tracking calories, protein, carbs, fiber, fat, sugar, etc.

4. Database and Model
CSV Data Import: Reads nutritional information from a CSV file, populating the app's internal database with food items.
Model Classes: Defines structured classes like CollectionViewClass to represent food items with nutritional details.

5. MVVM Architecture
ViewModels: Implements the MVVM (Model-View-ViewModel) architecture for separation of concerns, enhancing maintainability.
Data Binding: Utilizes data binding techniques for seamless communication between the user interface and underlying logic.

6. Command Design Pattern
Command Pattern: Implements the Command design pattern for handling user interactions, ensuring clean and modular code.
Asynchronous Operations: Handles asynchronous operations like saving data to JSON files using commands.

7. Data Persistence
File System Access: Uses the .NET MAUI file system APIs for data persistence, storing user information and goals locally.
JSON Serialization: Employs JSON serialization and deserialization for efficient storage and retrieval of user-specific data.

8. Cross-Platform Development
.NET MAUI: A cross-platform framework that enables the development of native mobile apps for iOS and Android using a single codebase.


How to Run

Clone the repository.
Open the project in .NET MAUI development environment.
Build and deploy the app to your preferred device/emulator.
