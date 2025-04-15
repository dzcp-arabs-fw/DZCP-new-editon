# DZCP Framework

Welcome to the **DZCP Framework**, an open-source plugin framework designed to simplify and enhance the development of plugins for **SCP: Secret Laboratory (SCP:SL)** servers. This framework provides a modular and extensible architecture, enabling developers to create robust and feature-rich plugins with ease.

---

## 🌟 Features

- **Modular Architecture**: Each component is encapsulated, promoting maintainability and scalability.
- **Comprehensive API**: Offers a wide range of functionalities to interact with game mechanics seamlessly.
- **Custom Roles and Items**: Easily define and manage custom roles and items to enrich gameplay.
- **Permission Management**: Fine-grained control over user permissions and access levels.
- **Event Handling**: Hook into game events to create dynamic and responsive plugins.
- **Database Integration**: Built-in support for database operations to store and retrieve persistent data.
- **Web Interface**: Optional web module for administrative tasks and real-time monitoring.

---

## 📁 Project Structure

The repository is organized into the following directories:

- `DZCP.API`: Core API definitions and interfaces.
- `DZCP.Commands`: Implementation of custom commands.
- `DZCP.Database`: Database context and models.
- `DZCP.Permissions`: Permission handling and user roles.
- `DZCP.Plugins`: Sample plugins demonstrating framework usage.
- `DZCP.Statistics`: Collection and analysis of game statistics.
- `DZCP.Teams`: Team management functionalities.
- `DZCP.RPG`: Role-playing game elements and mechanics.
- `DZCP.Cosmetics`: Cosmetic items and customization options.
- `DZCP.CustomRoles`: Definition and management of custom roles.
- `DZCP.CustomItems`: Creation and handling of custom items.
- `DZCP.Events`: Event listeners and handlers.
- `DZCP.Logging`: Logging utilities for debugging and monitoring.
- `DZCP.Loader`: Plugin loader and initializer.
- `DZCP.Installer`: Installation scripts and setup tools.
- `DZCP.Map`: Map-related functionalities and tools.
- `DZCP.Patcher`: Tools for patching and updating components.
- `DZCP.ElitePlayers`: Features targeting elite player management.
- `DZCP.Analytics`: Analytical tools for data-driven insights.
- `DZCP.Web`: Web interface for administration and monitoring.

---

## ⚙️ Installation

To set up the DZCP Framework on your SCP:SL server, follow these steps:

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/dzcp-arabs-fw/DZCP-new-editon.git
   ```

2. **Build the Solution**:

   Navigate to the cloned directory and build the solution using your preferred C# IDE (e.g., Visual Studio).

3. **Deploy to Server**:

   - Copy the compiled DLLs to your server's plugin directory.
   - Ensure all dependencies are satisfied and properly referenced.

4. **Configure Settings**:

   - Edit the configuration files located in the `Configs` directory to tailor the framework to your server's needs.

5. **Restart the Server**:

   - Restart your SCP:SL server to apply the changes and load the DZCP Framework.

---

## 🧩 Creating Plugins

To develop plugins using the DZCP Framework:

1. **Reference the API**:

   - In your plugin project, add a reference to `DZCP.API.dll`.

2. **Implement Interfaces**:

   - Create classes that implement the necessary interfaces provided by the framework.

3. **Handle Events**:

   - Utilize the event system to respond to in-game events.

4. **Build and Deploy**:

   - Compile your plugin and place the resulting DLL into the server's plugin directory.

5. **Test and Iterate**:

   - Test your plugin in a controlled environment before deploying to a live server.

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for more details.

---

## 🤝 Contributing

Contributions are welcome! If you'd like to contribute to the DZCP Framework:

- Fork the repository.
- Create a new branch for your feature or bugfix.
- Commit your changes with clear messages.
- Submit a pull request detailing your modifications.

Please adhere to the coding standards and guidelines outlined in the `CONTRIBUTING.md` file.

---

## 📬 Contact

For support, questions, or suggestions:

- **GitHub Issues**: Submit an issue on the [GitHub repository](https://github.com/dzcp-arabs-fw/DZCP-new-editon/issues).
- **Email**: Contact us at [support@dzcp-framework.org](mailto:support@dzcp-framework.org).
- **Discord**: Join our community on [Discord](https://discord.gg/dzcp-framework).

---

Thank you for using the DZCP Framework! We hope it enhances your SCP:SL server experience.
