$strconn = "Data Source=" + $args[0] + ";Initial Catalog=" + $args[1] + ";Integrated Security=True;Trust Server Certificate=true"
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.14
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.14
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold $strconn Microsoft.EntityFrameworkCore.SqlServer --force -o Model