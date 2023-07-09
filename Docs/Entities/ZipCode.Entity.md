# ZipCode Entity

## Description

A ZIP code, which stands for Zone Improvement Plan code, is a numerical code used by postal services to facilitate efficient mail sorting and delivery. ZIP codes help organize mail into specific geographic regions, making it easier to process and route mail to the intended destinations.

## Methods

```csharp
public interface IZipCodeService
{
    public void UpdateGeolocation(double latitude, double longitude)
    /*----------------------------*/
    public ZipCode GetZipCodeById(Guid id)
    public ZipCode SearchZipCodeByCode(string code)
    public List<ZipCode> GetBatchZipCodesById(List<Guid> ids)
    public List<ZipCode> GetZipCodes()
}
```

## Example Payload

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "code": "string",
  "traditional-authority-id": "00000000-0000-0000-0000-000000000000",
  "location-id": "00000000-0000-0000-0000-000000000000",
  "geolocation": {
    "latitude": 0.0,
    "longitude": 0.0
  },
  "createdDateTime": "2021-10-20T00:00:00.000Z",
  "updatedDateTime": "2021-10-20T00:00:00.000Z"
}
```
