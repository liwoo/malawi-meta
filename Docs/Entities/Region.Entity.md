# Region Entity

## Description
A region is a large area of land that is different from other areas of land, for example because it is one of the different parts of a country with its own customs and characteristics, or because it has a particular geographical feature.

## Methods
```csharp
public class Region : Entity<Guid>
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void AddDistrict(Guid districtId)
    public void RemoveDistrict(Guid districtId)
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "district_ids": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "population": {
    "male": 556,
    "female": 556,
    "total": 1112
  },
  "createdBy": "string",
  "createdOn": "2021-10-20T00:00:00.000Z",
  "modifiedBy": "string",
  "modifiedOn": "2021-10-20T00:00:00.000Z",
  "isDeleted": true,
  "deletedBy": "string",
  "deletedOn": "2021-10-20T00:00:00.000Z"
}
```