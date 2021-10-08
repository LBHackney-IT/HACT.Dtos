# HACT.Dtos
Housing Association Charitable Trust (HACT) have published a 
data standard for housing data interactions. This repo publishes a 
nuget which includes a C# implementation of the standard, allowing 
.NET applications to adhere to the HACT standard.

Data Transfer Object (DTO) is an object that carries data 
between processes in order to reduce the number of methods 
calls. For more information, see [Data Transfer Object](https://martinfowler.com/eaaCatalog/dataTransferObject.html)

## Getting started
The nuget is being hosted by [github packages](https://docs.github.com/en/packages/learn-github-packages/introduction-to-github-packages).

To consume the package in your project, first check if you have
City of Lincoln github set up as a nuget source. To do this run 
the following on you're terminal:

```
dotnet nuget list source 
```

If it s not in your list of registered sources, you will need to generate a github api token:

1) Select your profile on the top right and click on `settings`
2) On the side bar, click `developer settings`
3) Click on `Personal access token`
4) Click on `Generate new token`
5) Fill the note section accordingly
6) Check the `repo` and `read:packages` checkboxes
7) Click generate token 
8) Copy the token onto your clipboard (keep a note of this before you navigate off the page)

Replace `USERNAME` with your github username and `PASSWORD` 
with the token on your clipboard and run the following in the terminal:

```
dotnet nuget add source --username USERNAME --password PASSWORD --store-password-in-clear-text --name github "https://nuget.pkg.github.com/City-of-Lincoln-Council/index.json"
```
Check that you have now added github as a nuget source (see beginning of guide).

To add the package:

1) Click on `Packages` in the github repository page
2) Click on HACT.Dtos
3) Copy the command under `Install from the command line`
4) In the terminal, paste the command and replace `PROJECT` with the path to the project to which you would like to install your package

