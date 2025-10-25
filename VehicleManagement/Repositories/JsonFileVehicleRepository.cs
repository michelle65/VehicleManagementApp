using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using VehicleManagement.Interfaces;
using VehicleManagement.Models;
using VehicleManagement.Seeder;

namespace VehicleManagement.Repositories
{
    public class JsonFileVehicleRepository : IVehicleRepository
    {
        public const string DefaultFileName = "vehicles.json";
        private readonly IConfiguration _configuration;
        private readonly string _dataFileVehicles;


        private readonly JsonSerializerOptions _json = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public JsonFileVehicleRepository(IConfiguration configuration, string? directory = null)
        {
            _configuration = configuration;

            string baseDirectory;

            if (!string.IsNullOrEmpty(directory))
            {
                baseDirectory = directory;
            }
            else
            {
                var configuredDirectory = directory ?? _configuration["BaseDirectory"];
                if (!string.IsNullOrWhiteSpace(configuredDirectory))
                {
                    baseDirectory = configuredDirectory;
                }
                else
                {
                    var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); 
                    baseDirectory = !string.IsNullOrEmpty(appData)
                                    ? Path.Combine(appData, "VehicleManagement")
                                    : AppContext.BaseDirectory;
                }
            }
            Directory.CreateDirectory(baseDirectory);
            _dataFileVehicles = Path.Combine(baseDirectory, DefaultFileName);
        }

        public List<Vehicle> LoadOrSeed(out string info)
        {
            if (TryLoad(_dataFileVehicles, out var loaded, out var reason))
            {
                info = "Loaded existing data.";
                return loaded;
            }

            Console.WriteLine($"Vehicles failed to load, reason {reason}");

            var seedVehicles = VehicleSeeder.SeedInitialVehicles();
            Save(seedVehicles);
            info = $"Seeded defaults ({reason}) and created '{_dataFileVehicles}'.";
            return seedVehicles;
        }

        public void Save(IEnumerable<Vehicle> vehicles)
        {
            var jsonFileVehicles = JsonSerializer.Serialize(vehicles.ToList(), _json);

            var temporaryFile = _dataFileVehicles + ".tmp";
            File.WriteAllText(temporaryFile, jsonFileVehicles);

            File.Move(temporaryFile, _dataFileVehicles, overwrite: true);
        }

        private bool TryLoad(string pathVehiclesFile, out List<Vehicle> vehicles, out string reason)
        {
            vehicles = new List<Vehicle>();

            if (!File.Exists(pathVehiclesFile)) { reason = "file missing"; return false; }
            if (new FileInfo(pathVehiclesFile).Length == 0) { reason = "empty file"; return false; }

            var contentVehiclesFile = File.ReadAllText(pathVehiclesFile);
            if (string.IsNullOrWhiteSpace(contentVehiclesFile)) { reason = "blank content"; return false; }

            try
            {
                var deserialzedVehicles = JsonSerializer.Deserialize<List<Vehicle>>(contentVehiclesFile, _json) ?? new List<Vehicle>();
                if (deserialzedVehicles.Count == 0) { reason = "empty list"; return false; }

                vehicles = deserialzedVehicles;
                reason = "ok";
                return true;
            }
            catch (JsonException)
            {
                reason = "malformed JSON";
                return false;
            }
        }
    }
}