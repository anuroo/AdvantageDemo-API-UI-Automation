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
selenium-csharp-framework/
 ┣ src/
 ┃ ┣ Framework/        # Core utilities (DriverFactory, ConfigReader, Helpers)
 ┃ ┣ Tests/            # Test classes (LoginTests, CheckoutTests etc.)
 ┃ ┣ Pages/            # Page Object Models
 ┃ ┣ TestData/         # JSON/CSV test data files
 ┃ ┗ Reports/          # Extent/NUnit reports
 ┣ docker/
 ┃ ┣ docker-compose.yml
 ┃ ┗ Dockerfile
 ┣ .github/workflows/  # GitHub Actions pipeline
 ┣ README.md
 ┣ .gitignore
 ┗ selenium-csharp-framework.sln

---

🚀 How to Run Tests

1️⃣ Run Locally

git clone https://github.com/<your-username>/selenium-csharp-framework.git
cd selenium-csharp-framework
dotnet test

2️⃣ Run with Docker

Build and run inside a container:

docker build -t selenium-csharp-framework .
docker run selenium-csharp-framework

3️⃣ Run with Selenium Grid (Optional)

Spin up Selenium Grid with Chrome & Firefox nodes:

docker-compose -f docker/docker-compose.yml up --build

📊 Reports

After execution, test reports are generated in the Reports/ folder.

CI/CD with GitHub Actions

This project includes a GitHub Actions pipeline to:
	•	Run tests on each push/pull request.
	•	Generate and upload test reports as artifacts.