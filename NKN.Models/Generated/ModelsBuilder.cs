// ModelsBuilder class - when saved will regenerate Umbraco models using API mode of Models Builder

using Umbraco.ModelsBuilder;

// This is a place to add global attributes that control model generation
[assembly: ModelsNamespace("NKN.Models.Generated")]
[assembly: IgnoreContentType("Member")]
