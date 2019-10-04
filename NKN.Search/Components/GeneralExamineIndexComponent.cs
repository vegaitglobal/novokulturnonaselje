using Examine;
using Examine.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Examine;
using NKN.Common.Extensions;
using NKN.Search.Indexes;
using NKN.Search.Models;

namespace NKN.Search.Components
{
	[RuntimeLevel(MinLevel = RuntimeLevel.Run)]
	public class GeneralExamineIndexComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			composition.Register(typeof(GeneralExamineIndexCreator));
			composition.Components().Append<GeneralExamineIndexComponent>();
		}
	}

	public class GeneralExamineIndexComponent : IComponent
	{
		private readonly IExamineManager _examineManager;
		private readonly GeneralExamineIndexCreator _indexCreator;

		public GeneralExamineIndexComponent(IExamineManager examineManager, GeneralExamineIndexCreator indexCreator)
		{
			_examineManager = examineManager ?? throw new ArgumentNullException(nameof(examineManager));
			_indexCreator = indexCreator ?? throw new ArgumentNullException(nameof(indexCreator));
		}

		public void Initialize()
		{
			foreach (var index in _indexCreator.Create())
			{
				((BaseIndexProvider)index).TransformingIndexValues += GeneralExamineIndexComponent_TransformingIndexValues;
				_examineManager.AddIndex(index);
			}
		}

		public void Terminate()
		{
		}

		private static void GeneralExamineIndexComponent_TransformingIndexValues(object sender, IndexingItemEventArgs e)
		{
			if (e.ValueSet.Category != IndexTypes.Content) return;

			StringBuilder builder = new StringBuilder();

			foreach (var key in e.ValueSet.Values.Keys)
			{
				var values = e.ValueSet.Values[key];

				values.ForEach(v => v?.ToString()
					.TryToDeserializeJson<List<NestedContentIndexData>>()
					?.ForEach(nd => builder.TryAppendLine(nd.GetSearchableContent())));
			}

			if (builder.Length == 0) return;

			e.ValueSet.Add(Constants.Fields.NestedContentData, builder.ToString());
		}
	}
}
