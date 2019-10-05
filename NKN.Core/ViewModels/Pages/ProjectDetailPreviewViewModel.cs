using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System;

namespace NKN.Core.ViewModels.Pages
{
    public class ProjectDetailPreviewViewModel
    {
        public ProjectDetailPreviewViewModel(IPageContext<ProjectDetail> context)
        {
            Title = context.Page.PageTitle;
            ReleaseDate = context.Page.ReleaseDate;
            SmallImage = (context.Page.SmallImage as Image).ToViewModel();
            Summary = context.Page.Summary;
        }

        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ImageViewModel SmallImage { get; private set; }
        public string Summary { get; set; }
    }
}
