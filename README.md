# Temperature Monitoring System

## Description

The Temperature Monitoring System is a web application for monitoring sensor data in real time. The application reads sensor measurements from a data source, processes them, and displays the information in a web dashboard. Users can view temperature, humidity and battery values and receive live updates through SignalR.

## Features

* Display sensor information
* Search sensors by serial number or name
* View temperature measurements
* View humidity measurements
* View battery percentage
* Real-time updates using SignalR
* REST API endpoint for sensor data
* Unit tests for the implemented design patterns

## Technologies

### Backend

* C#
* ASP.NET Core
* SignalR
* xUnit

### Frontend

* Vue.js
* Vuetify
* Axios

## Design Patterns

The following design patterns are used:

* Singleton
* Observer
* Strategy
* State
* Facade

## Project Structure

### Backend

* Controllers
* Models
* Services
* Patterns

  * Singleton
  * Observer
  * Strategy
  * State
  * Facade
* Hubs

### Frontend

* Components
* Views
* Router
* Plugins

## Prerequisites

Before running the application, make sure the following software is installed:

* .NET 8 SDK
* Node.js
* Yarn
* Git

## Installation

Clone the repository:

```bash
git clone <repository-url>
```

Navigate to the project folder:

```bash
cd TemperatureMonitoringSystem
```

Restore dependencies:

```bash
dotnet restore
```

Install frontend dependencies:

```bash
yarn install
```

## Running the Application

### Backend

Navigate to the API project:

```bash
cd TemperatureMonitoring.Api
```

Run the backend:

```bash
dotnet run
```

The backend will start on:

```text
https://localhost:8888
```

Swagger is available at:

```text
https://localhost:8888/swagger
```

Sensor API endpoint:

```text
https://localhost:8888/sensor
```

### Frontend

Navigate to the frontend project and run:

```bash
yarn dev
```

The frontend runs on:

```text
http://localhost:5173
```

## API

### Get Sensors

```http
GET /sensor
```

Example:

```text
https://localhost:8888/sensor
```

## SignalR

SignalR is used for real-time communication.

Hub endpoint:

```text
https://localhost:8888/sensorHub
```

Clients receive updates through:

```text
ReceiveSensorData
```

## Running Tests

Execute the unit tests using:

```bash
dotnet test
```

## Documentation

Additional documentation describing the implemented design patterns and the reasons for choosing them can be found in the accompanying PDF document.
