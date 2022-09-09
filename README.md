# Kodlama.io.Devs
<h2>
<a href="https://documenter.getpostman.com/view/17832908/VUxSrQjV">Go To The Postman Documentation</a>
</h2>
<h2> Startup </h2>
<h3> ⬇️ Configure admin user in appsettings.json ⬇️ </h3>

```json
"AdminUser": {
    "FirstName": "admin_first_name",
    "LastName": "admin_last_name",
    "Email": "admin_email@hotmail.com",
    "Password": "admin_password"
  }
```
<hr>
<h3> ⬇️ Configure connection string in appsettings.json ⬇️ </h3>

```json
"ConnectionStrings": {
    "SqlServer": "Server=DESKTOP-HVLQH67\\SQLEXPRESS;Database=KodlamaDevDb;integrated security=true;"
  }
```
<h3> ⬇️ Create migration and create database in package manager console ⬇️ </h3>
<img src="screenshots/migrate.png"/>
<hr>
<h3> ⬇️ Configure token options in appsettings.json ⬇️ </h3>

```json
"TokenOptions": {
    "Audience": "kodlama.io.devs",
    "Issuer": "emir57",
    "AccessTokenExpiration": 30,
    "SecurityKey": "jKr1u.JDX5E14ZDs.K5ph8j7zEB.Vz82Mk",
    "RefreshTokenTTL": 0
  }
```
<hr>
<h2>
<a href="https://documenter.getpostman.com/view/17832908/VUxSrQjV">Postman Documentation</a>
</h2>
