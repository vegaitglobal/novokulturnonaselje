using Examine;
using Umbraco.Examine;

namespace NKN.Search.FieldDefinitions
{
    public class GeneralExamineIndexFieldDefinitionCollection : FieldDefinitionCollection
    {
        public GeneralExamineIndexFieldDefinitionCollection() : base(IndexFieldDefinitions)
        {
        }

        public static readonly FieldDefinition[] IndexFieldDefinitions =
        {
            new FieldDefinition(Constants.Fields.ParentId, FieldDefinitionTypes.Integer),
            new FieldDefinition(Constants.Fields.NodeName, FieldDefinitionTypes.Raw),
            new FieldDefinition(UmbracoExamineIndex.NodeKeyFieldName, FieldDefinitionTypes.InvariantCultureIgnoreCase),
            new FieldDefinition(Constants.Fields.NodeType, FieldDefinitionTypes.InvariantCultureIgnoreCase),
            new FieldDefinition(Constants.Fields.UrlName, FieldDefinitionTypes.InvariantCultureIgnoreCase),
            new FieldDefinition(Constants.Fields.Path, FieldDefinitionTypes.Raw),
            new FieldDefinition(UmbracoExamineIndex.PublishedFieldName, FieldDefinitionTypes.Raw),
            new FieldDefinition(UmbracoContentIndex.VariesByCultureFieldName, FieldDefinitionTypes.Raw),
            new FieldDefinition(Constants.Fields.PageTitle, FieldDefinitionTypes.Raw),
            new FieldDefinition(Constants.Fields.HideFromSiteSearch, FieldDefinitionTypes.Raw),
            new FieldDefinition(Constants.Fields.MainContent, FieldDefinitionTypes.Raw),
        };
    }
}