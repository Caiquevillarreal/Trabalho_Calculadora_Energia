using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tema1App.Models;

namespace Tema1App.Data
{
    public class DataStore
    {
        public List<Consumer> Consumers { get; set; } = new List<Consumer>();
        public List<Account> Accounts { get; set; } = new List<Account>();
    }

    public class Repository
    {
        private readonly string _jsonPath;
        private readonly string _xmlPath;
        private DataStore _store = new DataStore();

        public Repository(string jsonPath, string xmlPath)
        {
            _jsonPath = jsonPath;
            _xmlPath = xmlPath;
            Load();
        }

        private JsonSerializerOptions JsonOptions => new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new AccountJsonConverter() }
        };

        public IEnumerable<Consumer> AllConsumers() => _store.Consumers;
        public IEnumerable<Account> AllAccounts() => _store.Accounts;

        public void AddConsumer(Consumer c)
        {
            _store.Consumers.Add(c);
            SaveJson(); // 
        }

        public void AddAccount(Account a)
        {
            _store.Accounts.Add(a);
            var cons = _store.Consumers.FirstOrDefault(x => x.Id == a.ConsumerId);
            if (cons != null) cons.AccountIds.Add(a.Id);
            SaveJson();
        }

        public Consumer? GetConsumer(Guid id) => _store.Consumers.FirstOrDefault(x => x.Id == id);
        public Account? GetAccount(Guid id) => _store.Accounts.FirstOrDefault(x => x.Id == id);

        public void SaveJson()
        {
            var json = JsonSerializer.Serialize(_store, JsonOptions);
            File.WriteAllText(_jsonPath, json);
        }

        public void SaveXml()
        {
            using var stream = File.Create(_xmlPath);
            var serializer = new XmlSerializer(typeof(DataStore), new Type[] { typeof(ResidentialAccount), typeof(CommercialAccount) });
            serializer.Serialize(stream, _store);
        }

        public void Load()
        {
            if (File.Exists(_jsonPath))
            {
                var json = File.ReadAllText(_jsonPath);
                _store = JsonSerializer.Deserialize<DataStore>(json, JsonOptions) ?? new DataStore();
            }
        }
    }

    public class AccountJsonConverter : JsonConverter<Account>
    {
        public override Account? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;
            if (!root.TryGetProperty("AccountType", out var p)) return null;
            var type = p.GetString();
            return type switch
            {
                "Residencial" => JsonSerializer.Deserialize<ResidentialAccount>(root.GetRawText(), options),
                "Comercial" => JsonSerializer.Deserialize<CommercialAccount>(root.GetRawText(), options),
                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, Account value, JsonSerializerOptions options)
        {
            if (value is ResidentialAccount ra) JsonSerializer.Serialize(writer, ra, options);
            else if (value is CommercialAccount ca) JsonSerializer.Serialize(writer, ca, options);
            else JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
