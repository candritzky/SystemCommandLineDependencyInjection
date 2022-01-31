namespace SystemCommandLineTest.Commands
{
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Common base class for command arguments showing how to share common parameters.
    /// </summary>
    internal class CommonArgs
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public string Common { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, this.GetType(), JsonSerializerOptions);
        }
    }
}
