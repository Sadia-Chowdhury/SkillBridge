# SkillBridge

SkillBridge is a web-based job portal built using **ASP.NET Core MVC**, **Entity Framework Core**, and **ASP.NET Identity**. It connects **Clients** who post job opportunities with **Developers** who apply for them.

---

## ✨ Features

### 🔐 Authentication & Roles
- Role-based authentication using ASP.NET Core Identity
- Two user roles:
  - `Client`
  - `Developer`

### 👥 Client Features
- Register/Login as a client
- Post job listings
- Edit and delete their own job posts
- View applicants for their posted jobs (coming soon)

### 👨‍💻 Developer Features
- Register/Login as a developer
- View all job listings
- Apply for jobs
- View applied jobs in their dashboard

---

## 🗂️ Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (Code-First Approach)
- ASP.NET Identity with custom `ApplicationUser`
- SQL Server
- Razor Views + Bootstrap / Tailwind CSS
- Docker (In Progress)

---

## 🔧 Setup Instructions


---

## 🔧 Setup Instructions

**1. Clone the Repository**

Open your terminal or command prompt and run:

```
git clone https://github.com/YOUR_USERNAME/SkillBridge.git
cd SkillBridge
```

**2. Update the Connection String**

Open the `appsettings.json` file and update the SQL Server connection string as follows:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SkillBridgeDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Make sure to replace `YOUR_SERVER_NAME` with your actual SQL Server instance name, for example: `localhost\\SQLEXPRESS`.

**3. Apply Migrations**

Run this command to create the database and tables:

```
dotnet ef database update
```

This will create all necessary tables like JobPosts, Applications, AspNetUsers, IdentityRoles, etc.

**4. Run the Application**

Start the project with the following command:

```
dotnet run
```

Then open your browser and go to:

```
https://localhost:PORT
```

Replace `PORT` with the actual port shown in the terminal when the app runs.

---

###

<div align="center">
  <img height="200" src="https://i.ibb.co/XfJ6wjMx/Screenshot-2025-07-06-104322.png"  />
</div>

###
