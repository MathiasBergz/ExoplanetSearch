# Exoplanet Search

This project is a web application that allows users to search and analyze information about exoplanets, using calculations for signal-to-noise ratio (SNR) and maximum distance for characterization (ESmax). The application is built using ASP.NET Core with Razor Pages.

## Table of Contents

- [Description](#description)
- [Installation](#installation)
- [How to Use](#how-to-use)
- [Calculations](#calculations)
- [Glossary](#glossary)
- [Contributions](#contributions)
- [License](#license)

## Description

The Exoplanet Search application allows users to select an exoplanet and view its information, such as radius, distance to the star, and calculated data like SNR and ESmax. SNR is calculated to determine the feasibility of characterizing the planet, while ESmax provides the limiting distance for separating the exoplanet from its host star.

### Key Features

- Display information of the selected exoplanet.
- Calculate and display the results of SNR and ESmax based on the telescope diameter.
- Update calculated data in real-time through Ajax requests.

## Installation

To install and set up the application locally, follow the steps below:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/user/exoplanet-search.git

2. **Navigate to the project directory**:
   ```bash
   cd exoplanet-search
3. **Restore the dependencies**:
   ```bash
   dotnet restore 
4. **Run the application**:
   ```bash
   cd exoplanet-search
5. **Access the application in your browser at http://localhost:5000.**

## How to Use

1. Select a planet from the available list in the interface.
2. Adjust the telescope diameter using the slider control. The default value is 6.
3. The planet's information, along with the calculated results of SNR and ESmax, will be displayed automatically.

## Calculations

The formulas used for the calculations are as follows:
- **SNR (Signal-to-noise ratio)**:
  
  ![image](https://github.com/user-attachments/assets/3b90fefe-e86c-49fc-bf60-f6a06bde54a8)

- **ESmax (Limiting distance to separate the exoplanet from its host star)**:

  ![image](https://github.com/user-attachments/assets/68f88918-8b68-41f3-8f01-bfd5f6db07cf)

## Glossary

- **SNR**: Signal-to-noise ratio
- **R***: Stellar radius
- **RP**: Planet radius
- **ES**: Distance to the planetary system
- **D**: Telescope diameter
- **PS**: Planet-star distance
- **ESmax**: Limiting distance to separate the exoplanet from its host star
- **SNR0**: Default value of 100

## Contributions

Contributions are always welcome! Feel free to open an issue or submit a pull request.

To contribute, please follow these steps:

1. **Fork the repository**.
2. **Create a branch for your new feature**:
   ```bash
   git checkout -b feature/new-feature
3. **Commit your changes**:
   ```bash
   git commit -m 'Added new feature'
4. **Push to the main branch**:
   ```bash
   git push origin feature/new-feature
5. **Open a pull request.**
   
## License

This project is licensed under the MIT License.
