# City Aggregate Root

## Description
A City is a large human settlement. It can be defined as a permanent and densely settled place with administratively defined boundaries whose members work primarily on non-agricultural tasks. Cities generally have extensive systems for housing, transportation, sanitation, utilities, land use, and communication. Their density facilitates interaction between people, government organizations and businesses, sometimes benefiting different parties in the process, such as improving efficiency of goods and service distribution. This concentration also can have significant negative consequences, such as forming urban heat islands, concentrating pollution, and stressing water supplies and other resources.

## Methods
```csharp
public class ICityService
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    public void AddLocation(Guid districtId)
    public void RemoveLocation(Guid districtId)
    /*----------------------------*/
    public List<City> GetCities()
    public List<City> GetBatchCitiesById(List<Guid> ids)
    public City GetCityById(Guid id)
    public City SearchCityByName(string name)
    public List<Location> GetCityLocations(Guid id)
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "district_id": "00000000-0000-0000-0000-000000000000",
  "locations_ids": [
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