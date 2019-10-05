using NKN.Core.Contexts;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class WriteUsViewModel : INestedContentViewModel
    {
        public WriteUsViewModel(INestedContentContext<WriteUs> context)
        {
            Title = context.NestedContent.Title;
            FullName = context.NestedContent.FullName;
            Email = context.NestedContent.Email;
            Message = context.NestedContent.Message;
            BackgroundImage = context.NestedContent.BackgroundImage != null
                ? new ImageViewModel(context.NestedContent.BackgroundImage as Image)
                : null;
            OnSubmitMessage = context.NestedContent.OnSubmitMessage;
            SubmitButtonText = context.NestedContent.SubmitButtonText;
        }

        public string Title { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public ImageViewModel BackgroundImage { get; private set; }
        public string OnSubmitMessage { get; private set; }
        public string SubmitButtonText { get; private set; }
    }
}