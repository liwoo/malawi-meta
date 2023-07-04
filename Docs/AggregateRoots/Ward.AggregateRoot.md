# Ward Aggregate Root

## Description
A ward is a local authority area, typically used for electoral purposes. Wards are usually named after neighbourhoods, thoroughfares, parishes, landmarks, geographical features and in some cases historical figures connected to the area. It is common in the United States for wards to simply be numbered.

## Methods
```csharp
public class IWardService
{
    public void UpdateMalePopulation(long population)
    public void UpdateFemalePopulation(long population)
    public void UpdateGeolocation(double latitude, double longitude)
    public void AddPollingCenter(Guid pollingCenterId)
    public void RemovePollingCenter(Guid pollingCenterId) 
    /*----------------------------*/
    public Ward GetWardById(Guid id)
    public Ward SearchWardByName(string name)
    public List<Ward> GetBatchWardsById(List<Guid> ids)
    public List<Ward> GetWards()
    public List<PolingCenter> GetPollingCenters(Guid id)
    public Constituency GetConstituency(Guid id)
}
```

## Example Payload
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "string",
    "constituency_id": "00000000-0000-0000-0000-000000000000",
    "polling_center_ids": [
        "00000000-0000-0000-0000-000000000000"
    ],
    "population": {
      "male": 450,
      "female": 700,
      "total": 1150
    },
    "geolocation": {
      "latitude": 0.0,
      "longitude": 0.0
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