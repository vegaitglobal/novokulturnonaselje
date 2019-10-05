using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKN.Core.Contexts;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Pages
{
    public class StandardContentPageViewModel : PageViewModel
    {
        public StandardContentPageViewModel(IPageContext<STanda> context) : base(context)
        {
        }
    }
}
