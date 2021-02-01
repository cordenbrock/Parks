# Parks API

#### By Cory Nordenbrock
##### 1/31/21

## _What_ does it do?

* This is an API that follows RESTful standards and may be used to read/write onto an SQL database structured with two tables and various properties to detail national and state parks. This API also incorporates API versioning and Swagger's UI for visualizing all requests/responses in the browser.

## _Why_ does it do?

* This project was prompted by the wonderful people at [Epicodus](https://www.epicodus.com/) as an exercise in creating a RESTful web API with full CRUD functionality.

## Setup Instructions

   _**Note**: [.NET Core](https://dotnet.microsoft.com/download) must be installed for the following instructions (v 2.2 for current source code, later versions may be used by editing the ` <TargetFramework> ` element in Parks.csproj to reflect the correct version)._

* To clone and build program:

1. Clone this repository: ` git clone https://github.com/cordenbrock/Parks `
2. Navigate to this specific directory from project folder root: ` cd factory/Parks `
3. From this directory in your terminal, pass a ` dotnet restore ` command followed by a ` dotnet build ` command. This will install all the necessary dependencies and build the app.

* To setup database:

4. If no Migrations directory exists, pass the command ` dotnet ef migrations add Initial ` in your terminal from the root directory to generate a new Migrations directory that Entity will use to recreate the database schema.
5. Use ` dotnet ef database update ` command to scaffold database.

* To run program:

6. Pass the command ` dotnet run ` in your terminal from the root directory.
7. From your web browser, go to http://localhost:5000 to use Swagger's UI to make requests and generate JSON responses. Database schema is expandable and displayed at the bottom of the page.

## Endpoints

Base URL: `https://localhost:5000`

#### HTTP Request Structure
```
NationalParks

GET --  -- /api​/NationalParks
POST -- ​/api​/NationalParks
GET -- ​/api​/NationalParks​/{id}
PUT -- ​/api​/NationalParks​/{id}
DELETE -- ​/api​/NationalParks​/{id}

StateParksV1

GET -- ​/api​/StateParksV1
POST -- ​/api​/StateParksV1
GET -- ​/api​/StateParksV1​/{id}
PUT -- ​/api​/StateParksV1​/{id}
DELETE -- ​/api​/StateParksV1​/{id}

StateParksV2:

GET -- ​/api​/messages​/search
```


## Example read/write requests using Swagger UI

_For ParksAPI version 1.0, Click on the StateParksV1 "GET" method, followed by the "try it out" button, followed by the "Execute" button. Swagger will return the following JSON response, which is a retrieval of all entries from StateParks table:_

Response body:
```
[
  {
    "stateParkId": 1,
    "name": "Turkey Run SP",
    "location": "IN",
    "description": "Weird-looking trees"
  },
  {
    "stateParkId": 2,
    "name": "Snow Canyon SP",
    "location": "UT",
    "description": "Weird-looking lizards"
  },
  {
    "stateParkId": 3,
    "name": "Valley of Fire SP",
    "location": "NV",
    "description": "Weird-looking plants"
  }
]
```

Response headers:
```
 api-supported-versions: 1.0
 content-type: application/json; charset=utf-8
 date: Mon01 Feb 2021 09:41:49 GMT
 server: Kestrel
 transfer-encoding: chunked_1
```
_For ParksAPI version 2.0, click on the StateParksV2 "GET" method with the `/api/StateParksV2/search` endpoint, followed by the "try it out" button, then try querying the StatePark entity associated with Turkey Run SP name by typing "turkey" into the name parameter, finishing again with the "Execute" button. Swagger will return the following JSON response:_

Response body:
```
[
  {
    "stateParkId": 1,
    "name": "Turkey Run SP",
    "location": "IN",
    "description": "Weird-looking trees"
  }
]
```
Response headers
```
 api-supported-versions: 2.0 
 content-type: application/json; charset=utf-8 
 date: Mon01 Feb 2021 10:11:54 GMT 
 server: Kestrel 
 transfer-encoding: chunked
 ```

## Postman examples

_Alternatively, use the Postman client app to make the same queries demonstrated above with the following request methods and URLs, ordered respectively:_

```
GET -- http://localhost:5000/api/StateParksV1
```

```
GET -- http://localhost:5000/api/StateParksV2/search?name=turkey 
```

## Built with/Tools used

* _Visual Studio Code_
* _C#_
* _ASP.NET Core MVC_
* _MySQL_
* _Entity Framework Core 2.2.6
* _Identity_
* _Swagger - NSwag 13.3.0_
* _Postman_

### Known Bugs/Future Improvements

* No known bugs

### Legal

MIT License, (c) 2020 Cory Nordenbrock