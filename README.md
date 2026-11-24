# Duyan – AI-Powered Multi-Hotel Reservation and Management System

**Duyan** is a web-based, AI-powered multi-hotel reservation and management system designed to help multiple independent hotels manage their daily operations through one shared platform.

The system allows each registered hotel to independently manage its hotel information, staff, rooms, guests, reservations, check-ins, check-outs, and payment records while keeping its data separate from other hotels.

---

## Project Overview

Unlike a traditional hotel management system designed for a single establishment, Duyan supports multiple independent hotels within one application and database.

Each hotel has its own authorized users and operational records. The platform uses role-based access control and hotel-specific data restrictions to ensure that users can only access information they are authorized to manage.

Duyan also incorporates AI-powered functionalities to assist hotel staff in answering inquiries, recommending rooms, and understanding returning guests.

## Key Features

### 1. Multi-Hotel Management
- Supports multiple independent hotel establishments.
- Maintains individual hotel profiles and records.
- Separates hotel-specific data within a shared database.
- Provides centralized platform-level hotel management.

### 2. User Authentication and Role Management
Duyan supports three user roles:

| Role | Responsibilities |
|---|---|
| Platform Administrator | Manages registered hotels and platform-level information. |
| Hotel Administrator | Manages hotel information, staff accounts, rooms, and room types. |
| Hotel Staff | Handles guest registration, reservations, check-in/check-out, and payments. |

### 3. Hotel Operations Management
- Guest information and reservation history management.
- Room type and room management.
- Room availability checking.
- Reservation creation, modification, and cancellation.
- Guest check-in and check-out.
- Billing and payment recording.
- Hotel dashboard and operational statistics.

### 4. AI-Powered Features

| AI Feature | Description |
|---|---|
| **AI Hotel Assistant** | Answers hotel-related inquiries about policies, amenities, services, room types, and reservation procedures using the relevant hotel's information. |
| **AI Room Recommendation System** | Recommends suitable rooms based on guest requirements, budget, occupancy, preferences, and verified room availability. |
| **AI Guest Profile Summarizer** | Summarizes returning guests' reservation histories, recorded preferences, and special requests. |

**Important:** AI serves as an assistant to hotel staff. It does not independently confirm reservations, process payments, or modify hotel records. Room availability is verified by the application before AI recommendations are generated.

---

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Primary programming language |
| ASP.NET Core MVC | Web application framework |
| Bootstrap | Frontend styling and responsive interface |
| MySQL | Relational database |
| MySQL Workbench | Database design and administration |
| Entity Framework Core | Database access and object-relational mapping |
| NUnit | Unit testing |
| Playwright | Browser-based testing |
| AI API | AI-powered functionalities |
| Git and GitHub | Version control and collaboration |

---

## System Architecture

Duyan follows the **Model-View-Controller (MVC)** architectural pattern.

| Component | Responsibility |
|---|---|
| **Model** | Represents application data and entities. |
| **View** | Displays the user interface using Razor Views, HTML, CSS, and Bootstrap. |
| **Controller** | Handles incoming requests and coordinates application operations. |
| **Services** | Handles business logic, such as reservation validation, room availability, and AI integration. |
| **Database** | Stores hotel, user, guest, room, reservation, and payment information. |
| **AI Service** | Communicates with the external AI provider to perform AI-powered tasks. |

### Multi-Hotel Architecture

Duyan uses one shared application and one shared database for multiple hotels.

Hotel-specific records are associated with a `HotelID`. Server-side authorization and database queries enforce data separation.

For example:
- Hotel A can only manage its own guests, rooms, and reservations.
- Hotel B can only manage its own guests, rooms, and reservations.
- Hotel A cannot access Hotel B's private operational records.
- The Platform Administrator can manage registered hotel accounts.

---

## Database Overview

The initial database design includes the following tables:

| Table | Description |
|---|---|
| `Hotels` | Stores registered hotel information. |
| `Users` | Stores user accounts and assigned roles. |
| `Guests` | Stores hotel-specific guest information. |
| `GuestPreferences` | Stores recorded guest preferences and special requests. |
| `RoomTypes` | Stores room categories, descriptions, rates, and capacity. |
| `Rooms` | Stores individual room information and operational statuses. |
| `Reservations` | Stores guest reservations and stay information. |
| `Payments` | Stores payments associated with reservations. |

Primary keys and foreign keys establish relationships and help maintain data integrity.

---

## Project Scope and Limitations

The initial version focuses on the essential operations of independent hotels.

The following are outside the initial project scope:

- Online payment gateway integration.
- Guest self-service accounts.
- Third-party booking platform integration.
- Advanced hotel-chain and branch management.
- Physical access control integration.
- Advanced revenue forecasting.
- Autonomous AI transactions.

---

## Getting Started

### Prerequisites

Before running the project, make sure you have the following installed:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/)
- [Git](https://git-scm.com/)

### Installation

1. Clone the repository:

   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory:

   ```bash
   cd Duyan
   ```

3. Open the solution file in Visual Studio.

4. Configure the MySQL database connection using the project's configuration settings.

5. Create the required database and apply the database migrations or SQL scripts.

6. Restore the required NuGet packages.

7. Configure the required AI API credentials using secure configuration or environment variables. Do not commit API keys or passwords to GitHub.

8. Build and run the application.

> **Note:** Setup instructions, database scripts, and configuration details will be finalized as development progresses.

---

## Development and Testing

The project uses the following testing tools:

- **NUnit** – For testing individual application components and business logic.
- **Playwright** – For testing browser-based workflows and user interactions.

Important test scenarios include:

- User authentication and role permissions.
- Hotel-specific data isolation.
- Guest and room management.
- Room availability and reservation overlap prevention.
- Check-in and check-out operations.
- Billing and payment calculations.
- AI responses and hotel-specific data access.

---

## Project Status

<badge>In Development</badge>

Duyan is an academic software development project. Its features and implementation are subject to refinement throughout the development process.

## Contributors

Developed collaboratively as a software development finals project.

Contributors and their respective responsibilities will be documented as development progresses.

---

## Project Goal

**Duyan aims to provide one shared, secure, and intelligent hotel management platform where multiple independent hotels can manage their operations efficiently while using AI to support better guest services.**
