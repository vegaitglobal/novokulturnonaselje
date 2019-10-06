using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System;

namespace NKN.Core.ViewModels.Pages
{
    public class ProjectDetailPreviewViewModel
    {
        public ProjectDetailPreviewViewModel(ProjectDetail model)
        {
            Title = model.PageTitle;
            ReleaseDate = model.ReleaseDate;
            SmallImage = (model.SmallImage as Image).ToViewModel();
            Summary = model.Summary;
            Url = model.Url;
        }

        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ImageViewModel SmallImage { get; private set; }
        public string Summary { get; set; }
        public string Url { get; set; }
    }
}
