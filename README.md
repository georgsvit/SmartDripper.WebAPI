# **"SmartDripper.WebAPI" - Backend for Smart Dripper project.**
---
## Agenda
- [Description](#Description)
- [Technologies](#Technologies)
- [Setup](#Setup)
---

## **Description**
The main idea of the "SmartDripper" software system is to simplify the work of medical staff with systems for intravenous drip and optimize the part of the work of medical staff that is related to accounting.

---

## **Technologies**
- ASP.Net Core 3.1 (MVC)
- Entity Framework Core 3.1
- JWT Authentication

## **Setup**
To run this project, download it and open with Visual Studio. Before start up ypu should specify database connection string in file **secrets.json**.
```
{
  "ConnectionStrings": {
    "DevConnection": "PLACE DEV DB CONNECTION STRING HERE",
    "ReleaseConnection": "PLACE RELEASE DB CONNECTION STRING HERE"
  }
}
```
Then build and run project.
>Note: In case if database doesn't exist, app will create and configure it.

By default database has user:
- administrator (Email: test@test.com, Password: password)

