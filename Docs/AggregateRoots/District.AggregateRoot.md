# District Aggregate Root

## Description
A district is a smaller area of land that is part of a region. It is a smaller area of land that is different from other areas of land, for example because it is one of the different parts of a region with its own customs and characteristics, or because it has a particular geographical feature.

## Methods
```csharp
public class IDistrictService
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    public void AddTraditionalAuthority(Guid traditionalAuthorityId)
    public void RemoveTraditionalAuthority(Guid traditionalAuthorityId)
    public void AddCity(Guid cityId)
    public void RemoveCity(Guid cityId)
    public void AddConstituency(Guid constituencyId)
    public void RemoveConstituency(Guid constituencyId)
    /*----------------------------*/
    /*  Data Acess Methods (Repo) */
    /*----------------------------*/
    public District GetDistrictById(Guid id)
    public List<District> GetBatchDistrictsById(List<Guid> ids)
    public District SearchDistrictByName(string name)
    public List<District> GetDistricts()
    public List<TraditionalAuthority> GetTraditionalAuthorities(Guid id)
    public List<City> GetCities(Guid id)
    public List<Constituency> GetConstituencies(Guid id)
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "region-id": "00000000-0000-0000-0000-000000000000",
  "traditional-authority-ids": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "city-ids": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "constituency-ids": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "geolocation": {
    "latitude": 0.0,
    "longitude": 0.0
  },
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