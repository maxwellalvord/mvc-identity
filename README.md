<!-- project name -->

<!-- by -->

## Technologies Used

* C#
* .Net 5.0
* HTML
* CSS
* Git
* VsCode
* EntityFrameWork
* REPL
* MySQL WorkBench

## Description 


## Setup/Installation Requirements 

* Clone this repo: <https://github.com/USERNAME/ProjectName.Solution>
* Enter the new directory using the command ```cd ProjectName.Solution```
* Create an appsetting.json file at the root directory
* Open the appsetting.json file and enter:

```js
{ 
  "ConnectionStrings": { 
    "DefaultConnection": "Server=localhost;Port=3306;database=[Database-Name];uid=root;pwd=[YOUR-PASSWORD];" 
  } 
}
```

* Run ```git add .gitignore```
* Commit your changes
* To ensure the project will run correctly,
* Download MySQL WorkBench
* Run ```dotnet tool install --global dotnet-ef --version 5.0.1``` at a global level
* Run the following from the project directory of ```ProjectName```
* Run ```dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0```
* Run ```dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2```
* Run ```dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0```
* Run ```dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0```
* Once all of the necessary setup is in place and we can successfully run dotnet build
* Run ```dotnet restore``` and ```dotnet build``` from the ProjectName directory
* Run ```dotnet ef migrations add Initial``` from the ProjectName Directory
* Once we have verified that the migration looks correct and made any necessary changes, we'll run the following command: ```dotnet ef database update```
* To interact with the local host website navigate to the University directory and run ```dotnet run```
* Click on  <http://localhost:5000>

## Known Bugs 

* No Known Issues

## License 


