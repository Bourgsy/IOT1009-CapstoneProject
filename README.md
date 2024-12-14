# Under the Weather App

## Project Scope
- **Name:** Under the Weather App.
- **Goal:** Let users log their moods based on real time weather. See how others feel under the same conditions.
- **Login:** Hardcoded `admin:admin` (alpha testing).

## Features
- **Real-Time Weather:** Fetched at login from OpenWeatherMap API.
- **Mood Tracking:** Positive or negative mood inputs, stored alongside weather.
- **MVVM Pattern:** Clean architecture for easier maintenance and expansion.
- **SQLite integration:** Stores Mood records so that percentages are accurate.

## Technical Specs
- Built with .NET MAUI.
- Uses MVVM for separation of concerns.
- Potential for future journal and multi-account functionality.

## User Stories
- A user wants to test out the new application. admin:admin credentials are provided so that the user can try the alpha.
- A user wants to see the current weather conditions and have better understanding of their mood and the collective mood of users.