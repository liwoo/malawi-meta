# Constituency Aggregate Root

## Description

A constituency is a defined geographic area or electoral district within the country. It represents a division of the population for the purpose of electing representatives to the Malawian Parliament.

## Methods

```csharp
public interface IConstituencySerivice
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    public void AddWard(Guid wardId)
    public void RemoveWard(Guid wardId)
    /*----------------------------*/
    public Constituency GetConstituencyById(Guid id)
    public List<Constituency> GetBatchConstituenciesById(List<Guid> ids)
    public Constituency SearchConstituencyByName(string name)
    public List<Constituency> GetConstituencies()
    public List<Ward> GetWards(Guid id)
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "district-id": "00000000-0000-0000-0000-000000000000",
  "ward-ids": ["00000000-0000-0000-0000-000000000000"],
  "geolocation": {
    "latitude": 0.0,
    "longitude": 0.0
  },
  "population": {
    "male": 556,
    "female": 556,
    "total": 1112
  },
  "createdDateTime": "2021-10-20T00:00:00.000Z",
  "updatedDateTime": "2021-10-20T00:00:00.000Z"
}
```
