//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.3.2.0 (Newtonsoft.Json v9.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace HACT.Dtos
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.2.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class JobStatusUpdate
    {
        [Newtonsoft.Json.JsonProperty("Reference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Reference Reference { get; set; }

        [Newtonsoft.Json.JsonProperty("RelatedWorkOrderReference", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Reference RelatedWorkOrderReference { get; set; } = new Reference();

        [Newtonsoft.Json.JsonProperty("RelatedWorkElementReference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Reference> RelatedWorkElementReference { get; set; }

        [Newtonsoft.Json.JsonProperty("EventTime", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? EventTime { get; set; }

        [Newtonsoft.Json.JsonProperty("TypeCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public JobStatusUpdateTypeCode? TypeCode { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherType { get; set; }

        [Newtonsoft.Json.JsonProperty("OperativesAssigned", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<OperativesAssigned> OperativesAssigned { get; set; }

        [Newtonsoft.Json.JsonProperty("RefinedAppointmentWindow", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RefinedAppointmentWindow RefinedAppointmentWindow { get; set; }

        [Newtonsoft.Json.JsonProperty("CustomerFeedback", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CustomerFeedback CustomerFeedback { get; set; }

        [Newtonsoft.Json.JsonProperty("CustomerCommunicationChannelAttempted", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CustomerCommunicationChannelAttempted CustomerCommunicationChannelAttempted { get; set; }

        [Newtonsoft.Json.JsonProperty("Comments", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }

        [Newtonsoft.Json.JsonProperty("MoreSpecificSORCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public WorkElement MoreSpecificSORCode { get; set; }

        [Newtonsoft.Json.JsonProperty("Evidence", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Attachment> Evidence { get; set; }

        [Newtonsoft.Json.JsonProperty("AdditionalWork", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AdditionalWork AdditionalWork { get; set; }


    }
}
