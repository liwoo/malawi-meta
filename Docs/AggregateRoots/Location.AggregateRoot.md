# Location Aggregate Root

## Description
A location is a township in a city. In Rural areas, it would occupy the same jurisdiction as a Traditional Authority.

## Methods
```csharp
public class LocationService : ILocationSerivice
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    /*----------------------------*/
    public Location GetLocationById(Guid id)
    public Location SearchLocationByName(string name)
    public List<Location> GetLocations()
    /*----------------------------*/
    public List<Constituency> GetConstituency(Guid id)
    public List<PollingCenter> GetPollingCenters(Guid id)
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "zip-code-id": "00000000-0000-0000-0000-000000000000",
  "city-id": "00000000-0000-0000-0000-000000000000",
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