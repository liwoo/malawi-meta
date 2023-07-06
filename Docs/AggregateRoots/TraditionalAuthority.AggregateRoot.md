# Traditional Authority Aggregate Root

## Description

Traditional Authorities are responsible for governing and administering local areas, usually based on traditional cultural and customary practices. TA is an umbrella of all Group Village heads.

## Methods

```csharp
public interface ITraditionalAuthoritySerivice
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    public void AddGroupVillageHead(Guid groupVillageHeadId)
    public void RemoveAddGroupVillageHead(Guid groupVillageHeadId)
    /*----------------------------*/
    public TraditionalAuthority GetTraditionalAuthorityById(Guid id)
    public List<TraditionalAuthority> GetBatchTraditionalAuthoritiesById(List<Guid> ids)
    public TraditionalAuthority SearchTraditionalAuthorityByName(string name)
    public List<TraditionalAuthority> GetTraditionalAuthority()
    public List<GroupVillageHead> GetGroupVillageHeads(Guid id)
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "district-id": "00000000-0000-0000-0000-000000000000",
  "ZipCode-id": "00000000-0000-0000-0000-000000000000",
  "group-village-head-ids": ["00000000-0000-0000-0000-000000000000"],
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
