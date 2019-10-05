using System.Collections.Generic;

namespace NKN.Core.Models
{
    public interface IPagination
    {
        int Page { get; }
        int TotalPages { get; }
        long TotalResults { get; }

        IReadOnlyList<Page> Pages { get; }

        bool HasPreviousPage();
        bool HasNextPage();
    }
}