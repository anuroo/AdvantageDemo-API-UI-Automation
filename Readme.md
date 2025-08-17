# 🧪 Selenium C# Automation Framework – Advantage Demo Store

This is a **production-level Selenium Automation Framework** built using **C#**, designed for UI test automation of the [Advantage Demo Store](https://advantageonlineshopping.com/).  

It follows **industry best practices** including Page Object Model (POM), Thread-safe Parallel Execution, Extent Reporting, and CI/CD integration, making it a professional portfolio project to showcase automation engineering skills.

---

## 🚀 Features
- ✅ **Cross-browser testing** – Chrome, Firefox, Edge  
- ✅ **Thread-safe parallel execution** (NUnit)  
- ✅ **Page Object Model (POM)** design pattern  
- ✅ **Config-driven** (URLs, browsers, timeouts, credentials)  
- ✅ **Detailed HTML Reports** via Extent Reports  
- ✅ **Dockerized execution** (Selenium Grid support)  
- ✅ **CI/CD ready** (GitHub Actions / Jenkins integration)  
- ✅ **Screenshots on failure**  
- ✅ **Scalable & Maintainable design**  

---

## 🛠 Tech Stack
- **Language:** C#  
- **Test Framework:** NUnit  
- **Automation Tool:** Selenium WebDriver  
- **Reporting:** Extent Reports  
- **Build Tool:** .NET CLI  
- **CI/CD:** GitHub Actions / Jenkins  
- **Containerization:** Docker + Selenium Grid  

---

## 📂 Project Structure
SeleniumFramework/
│── Framework/
│   ├── Drivers/          # WebDriver management
│   ├── Pages/            # Page Object Models
│   ├── Tests/            # NUnit Test Classes
│   ├── Utils/            # Helpers, Config, Logger
│   └── Reports/          # HTML Reports & Screenshots
│
├── appsettings.json      # Configurations
├── Dockerfile            # Docker setup
├── docker-compose.yml    # Selenium Grid setup
├── README.md             # Documentation
└── .github/workflows/    # CI/CD pipeline configs

---

## ▶️ How to Run Tests

### 🔹 Local Execution
```bash
dotnet test

🔹 Cross-Browser Execution

Update appsettings.json:
"Browser": "Firefox"

and then run dotnet test

🔹 Docker + Selenium Grid
	1.	Start Selenium Grid:
    docker-compose up -d
    2.run tests:
    dotnet test

📊 Reports & Artifacts
	•	Test results generated using Extent Reports in Reports/
	•	Screenshots captured automatically on test failure

CI/CD Integration

This project supports CI/CD pipelines:
	•	GitHub Actions: .github/workflows/dotnet.yml included
	•	Jenkins: Can be triggered via dotnet test command
	•	Supports headless test execution inside pipelines