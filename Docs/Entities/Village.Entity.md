# Village Entity

## Description

A village is a small community or settlement consisting of a group of households. Villages in Malawi are typically rural and are the fundamental building blocks of the country's social structure. They serve as the primary units for local governance, community development, and resource management.

## Methods

```csharp
public interface IVillageService
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    /*----------------------------*/
    public Village GetVillageById(Guid id)
    public List<Village> GetBatchVillagesById(List<Guid> ids)
    public Village SearchVillageByName(string name)
    public List<Village> GetVillages()
}

```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "group-village-head-id": "00000000-0000-0000-0000-000000000000",
  "population": {
    "male": 556,
    "female": 556,
    "total": 1112
  },
  "geolocation": {
    "latitude": 0.0,
    "longitude": 0.0
  },
  "createdDateTime": "2021-10-20T00:00:00.000Z",
  "updatedDateTime": "2021-10-20T00:00:00.000Z"
}
```
