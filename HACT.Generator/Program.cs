using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace HACT.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = args[0]; //path to directory containing HACT Data Standard
            var outputPath = args[1]; //output path for generated Dtos

            var excludedFiles = new List<string>();
            foreach (var inputFile in Directory.EnumerateFiles(inputPath, "*.json"))
            {
                var inputFileName = Path.GetFileNameWithoutExtension(inputFile);
                try
                {
                    Run(inputFileName, inputPath, outputPath).Wait();
                }
                catch (Exception e)
                {
                    excludedFiles.Add(inputFileName);
                }
            }

            var failedFilesOutput = excludedFiles.Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}");
            Console.WriteLine($"Failed to generate for the following files: {failedFilesOutput}");
        }

        public static async Task Run(string file, string inputPath, string outputPath)
        {
            var json = await File.ReadAllTextAsync(Path.Join(inputPath, $"{file}.json"));

            var replacedJson = json
                .Replace(@"""type"": ""#/defini", "\"$ref\": \"#/defini")
                .Replace(@"""type"": ""date""", "\"type\": \"string\", \"format\": \"date\"")
                .Replace(@"""type"": ""date-time""", "\"type\": \"string\", \"format\": \"date-time\"");

            JObject parsedFile = (JObject)JsonConvert.DeserializeObject(replacedJson);

            var data = parsedFile.Last;
            JObject properties = data.Last as JObject;
            parsedFile.Add("properties", properties.GetValue("properties"));
            parsedFile.Add("required", properties.GetValue("required"));
            data.Remove();

            var fixedFile = JsonConvert.SerializeObject(parsedFile);

            var schema = await JsonSchema.FromJsonAsync(fixedFile);
            schema.Title = file.Split('-', '.')[0];
            DisallowAdditionalProperties(schema, "");
            var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings
            {
                DateTimeType = "System.DateTime",
                DateType = "System.DateTime",
                Namespace = "HACT.Dtos",
                GenerateDefaultValues = false,
                GenerateOptionalPropertiesAsNullable = true
            });
            var codeFile = generator.GenerateFile();

            await File.WriteAllTextAsync(Path.Join(outputPath, $"{file}.cs"), codeFile);
        }

        private static void DisallowAdditionalProperties(JsonSchema schema, string pref)
        {
            if (schema is null)
                return;

            schema.AllowAdditionalProperties = false;

            foreach (var kv in schema.Definitions)
            {
                string arrow = pref + " -> def -> " + kv.Key;
                Console.WriteLine(arrow);
                DisallowAdditionalProperties(kv.Value, arrow);
            }

            foreach (var kv in schema.Properties)
            {
                if (kv.Value.Name == "M3NHFSORCode")
                {
                    kv.Value.ActualTypeSchema.Enumeration.Clear();
                }
                string arrow = pref + " -> prop -> " + kv.Key;
                Console.WriteLine(arrow);
                DisallowAdditionalProperties(kv.Value, arrow);
            }


            DisallowAdditionalProperties(schema.Item, " -> item -> ");
        }
    }
}
