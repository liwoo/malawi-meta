# Group Village Head Aggregate Root

## Description

A Group Village Head (GVH) is a subdivision of the village hierarchy and represents a group of villages within a specific geographic area.

## Methods

```csharp
public interface IGroupVillageHeadSerivice
{
    public void UpdateMalePopulation(long population);
    public void UpdateFemalePopulation(long population);
    public void UpdateGeolocation(double latitude, double longitude);
    public void AddVillage(Guid villageId);
    public void RemoveVillage(Guid villageId);
    /*----------------------------*/
    public GroupVillageHead GetGroupVillageHeadById(Guid id);
    public List<GroupVillageHead> GetBatchGroupVillageHeadsById(List<Guid> ids);
    public GroupVillageHead SearchGroupVillageHeadByName(string name);
    public List<GroupVillageHead> GetGroupVillageHead();
    public List<Village> GetVillages(Guid id);
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "traditional-authority-id": "00000000-0000-0000-0000-000000000000",
  "village-ids": ["00000000-0000-0000-0000-000000000000"],
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
