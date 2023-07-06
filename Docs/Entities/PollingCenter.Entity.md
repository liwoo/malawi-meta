# Polling Center Entity

## Description

A polling center is a designated location where eligible voters go to cast their votes during elections. These centers are established by the Malawi Electoral Commission (MEC), the independent body responsible for conducting elections in the country.

## Methods

```csharp
public interface IPollingCenterService
{
    public PollingCenter GetPollingCenterById(Guid id)
    public PollingCenter SearchPollingCenterByName(string name)
    public List<PollingCenter> GetBatchPollingCentersById(List<Guid> ids)
    public List<PollingCenter> GetPollingCenters()
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "string",
  "ward-id": "00000000-0000-0000-0000-000000000000",
  "geolocation": {
    "latitude": 0.0,
    "longitude": 0.0
  },
  "createdDateTime": "2021-10-20T00:00:00.000Z",
  "updatedDateTime": "2021-10-20T00:00:00.000Z"
}
```
