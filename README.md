# BIASK

A minimal ASP.NET web application built with Visual Studio.

## Requirements

- Visual Studio 2022 (or later) with the **ASP.NET and web development** workload
- .NET SDK (version matching the project's target framework)

## Getting Started

1. **Open the project**
   - Double-click the `.sln` file, or use **File > Open > Folder** to open the project directory.

2. **Restore packages**
   - Visual Studio restores NuGet packages automatically on build. To do it manually: right-click the solution in Solution Explorer and select **Restore NuGet Packages**.

3. **Build**
   - Select **Build > Build Solution** (or press `Ctrl+Shift+B`).

4. **Run**
   - Press `F5` to run in debug mode, or `Ctrl+F5` to run without debugging.
   - The browser opens automatically at `https://localhost:<port>`.

## Notes

- On first run, accept the prompt to trust the IIS Express SSL certificate.
- If the app fails to start, verify the ASP.NET workload is installed and the .NET SDK version matches the project's target framework.

## Project Structure

```
/Controllers    – MVC controllers (if applicable)
/Views          – Razor views (if applicable)
/wwwroot        – Static files (CSS, JS, images)
Program.cs      – Application entry point
appsettings.json – Configuration settings
```