using MalawiMeta.Api.Domain.ValueObjects;

namespace MalawiMeta.Api.Domain.Aggregates
{
    public sealed class City : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Guid DistrictId { get; private set; }
        public List<Guid> LocationIds { get; private set; }
        public Geolocation Geolocation { get; private set; }
        public Population? Population { get; private set; }
        private City(Guid id, string name, Guid districtId, double latitude, double longitude) : base(id)
        {
            Name = name;
            DistrictId = districtId;
            LocationIds = new List<Guid>();
            Geolocation = new Geolocation(latitude, longitude);
        }
        public static City Create(string name, Guid districtId, double latitude, double longitude)
        {
            City city = new City(Guid.NewGuid(), name, districtId, latitude, longitude);
            return city;
        }
        public void SetPopulation(int totalPopulation, int malePopulation, int femalePopulation)
        {
            Population = new Population(totalPopulation, malePopulation, femalePopulation);
        }
        public void AddLocation(Guid locationId)
        {
            LocationIds.Add(locationId);
        }
        public void RemoveLocation(Guid locationId)
        {
            LocationIds.Remove(locationId);
        }
    }
}
