# HACT.Dtos
Housing Association Charitable Trust (HACT) have published a 
[data standard](https://www.hact.org.uk/DataStandard) for housing data interactions. This repo publishes a 
nuget which includes a C# implementation of the standard, allowing 
.NET applications to adhere to the HACT standard.

Data Transfer Object (DTO) is an object that carries data 
between processes in order to reduce the number of methods 
calls. For more information, see [Data Transfer Object](https://martinfowler.com/eaaCatalog/dataTransferObject.html)

## Getting started
The nuget is being hosted by [github packages](https://docs.github.com/en/packages/learn-github-packages/introduction-to-github-packages).

To consume the package in your project, first check if you have
City of Lincoln GitHub set up as a nuget source. To do this run 
the following on you're terminal:

```
dotnet nuget list source 
```
Check that you have the following set as one of your registered sources:

```
 1. github [Enabled]
 https://nuget.pkg.github.com/City-of-Lincoln-Council/index.json
```

If it s not in your list of registered sources, you will need to generate a GitHub api token:

1) Navigate to https://github.com/settings/tokens/new
2) Fill the note section accordingly
3) Check the `repo` and `read:packages` checkboxes
4) Click generate token 
5) Copy the token onto your clipboard (keep a note of this before you navigate off the page)

Replace `USERNAME` with your GitHub username and `PASSWORD` 
with the token on your clipboard and run the following in the terminal:

```
dotnet nuget add source --username USERNAME --password PASSWORD --store-password-in-clear-text --name github "https://nuget.pkg.github.com/City-of-Lincoln-Council/index.json"
```
Check that you have now added GitHub as a nuget source (see beginning of guide).

To add the package, replace PROJECT with the path to the project the nuget will be installed to and run:

```
dotnet add PROJECT package HACT.Dtos
```

## Discrepencies between use case definitions and data model 
The use case JSON definitions consumed by the HACT.Generator project do not provide complete definition of the HACT entities. The full data model can be viewed [here](https://www.oscre.org/idm).
Due to the incompleteness of entity definitions within the use cases, if a need arises to make a generated DTO more (not necessarily completely) reflective of the full definition, then follow these steps:
- Create a partial class definition with the same name as the entity.
The HACT.Generator produces partial classes, which this new class would be combined with. 
- Ensure the namespace of the new partial class is `HACT.Dtos`, which is the default namespace of all classes the HACT.Generator produces.
- Add required additions within this class definition.

An example of this is `PropertyAddress`, where the use case JSON does not define an Reference property that is defined in the [data model](https://www.oscre.org/idm?version=idm-main-3_3&content=entity/PropertyAddress&product=HACT).

The following is the partial class needed to add the Reference property to `PropertyAddress`:  
```
namespace HACT.Dtos
{
    public partial class PropertyAddress
    {
        public Reference Reference { get; set; }
    }
}
```
