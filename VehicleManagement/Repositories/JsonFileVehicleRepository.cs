using System.Text.Json;
using System.Text.Json.Serialization;
using VehicleManagement.Dtos;
using VehicleManagement.Helpers;
using VehicleManagement.Interfaces;
using VehicleManagement.Models;
using VehicleManagement.Seeder;

namespace VehicleManagement.Repositories
{
    public class JsonFileVehicleRepository : IVehicleRepository
    {
        private readonly string _dataFile;
        public const string DefaultFileName = "vehicles.json";

        private readonly JsonSerializerOptions _json = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public JsonFileVehicleRepository(string? dir = null)
        {
            var baseDir = string.IsNullOrWhiteSpace(dir) ? ResolveDataDirectory() : dir!;
            Directory.CreateDirectory(baseDir);
            _dataFile = Path.Combine(baseDir, DefaultFileName);
        }

        public List<Vehicle> LoadOrSeed(out string info)
        {
            if (TryLoad(_dataFile, out var loaded, out var reason))
            {
                info = "Loaded existing data.";
                return loaded;
            }

            var seed = VehicleSeeder.SeedInitialVehicles();
            Save(seed);
            info = $"Seeded defaults ({reason}) and created '{_dataFile}'.";
            return seed;
        }

        public void Save(IEnumerable<Vehicle> vehicles)
        {
            var snapshot = vehicles.ToList();

            var json = JsonSerializer.Serialize(snapshot, _json);

            var tmp = _dataFile + ".tmp";
            File.WriteAllText(tmp, json);

            File.Move(tmp, _dataFile, overwrite: true);

        }

        private static string ResolveDataDirectory()
        {
            var env = Environment.GetEnvironmentVariable("VEHICLE_APP_DATA_DIR");
            if (!string.IsNullOrWhiteSpace(env)) return env;

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!string.IsNullOrEmpty(appData)) return Path.Combine(appData, "VehicleManagement");

            return AppContext.BaseDirectory;
        }

        private bool TryLoad(string path, out List<Vehicle> vehicles, out string reason)
        {
            vehicles = new List<Vehicle>();

            if (!File.Exists(path)) { reason = "file missing"; return false; }
            if (new FileInfo(path).Length == 0) { reason = "empty file"; return false; }

            var text = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(text)) { reason = "blank content"; return false; }

            try
            {
                var dtos = JsonSerializer.Deserialize<List<VehicleDto>>(text, _json) ?? new List<VehicleDto>();
                var list = dtos.Select(VehicleMapper.FromDto).ToList();
                if (list.Count == 0) { reason = "empty list"; return false; }

                vehicles = list;
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