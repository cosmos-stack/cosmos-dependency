@echo off

::create nuget_pub
if not exist nuget_pub (
    md nuget_pub
)

::clear nuget_pub
for /R "nuget_pub" %%s in (*) do (
    del %%s
)

dotnet pack src/Cosmos.Extensions.Dependency.Core -c Release -o nuget_pub
dotnet pack src/Cosmos.Extensions.Autofac -c Release -o nuget_pub
dotnet pack src/Cosmos.Extensions.AspectCoreInjector -c Release -o nuget_pub
dotnet pack src/Cosmos.Extensions.DependencyInjection -c Release -o nuget_pub

for /R "nuget_pub" %%s in (*symbols.nupkg) do (
    del %%s
)

echo.
echo.

set /p key=input key:
set source=https://www.myget.org/F/alexinea/api/v2/package

for /R "nuget_pub" %%s in (*.nupkg) do ( 
    call nuget push %%s %key% -Source %source%	
	echo.
)

pause