# Temperature Monitoring System

## Description

The Temperature Monitoring System is a web application for monitoring sensor data in real time. The application reads sensor measurements from a data source, processes them, and displays the information in a web dashboard. Users can view temperature, humidity, and battery values and receive live updates through SignalR.

## Features

* Display sensor information
* Search sensors by serial number or name
* View temperature measurements
* View humidity measurements
* View battery percentage
* Real-time updates using SignalR
* REST API endpoint for sensor data

## Technologies

### Backend

* C#
* ASP.NET Core
* SignalR

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

## API

### Get sensors

```
GET /sensor
```

Example:

```
https://localhost:8888/sensor
```

## SignalR

SignalR is used for live updates.

Hub endpoint:

```
https://localhost:8888/sensorHub
```

Clients receive updates through:

```
ReceiveSensorData
```

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

Restore backend dependencies:

```bash
dotnet restore
```

Install frontend dependencies:

```bash
yarn install
```

## Running the application

### Backend

Navigate to the backend project and run:

```bash
dotnet run
```

Backend runs on:

```
https://localhost:8888
```

### Frontend

Navigate to the frontend project and run:

```bash
yarn dev
```

Frontend runs on:

```
http://localhost:5173
```

## Documentation

Additional documentation describing the implemented design patterns and the reasons for choosing them can be found in the accompanying PDF document.
