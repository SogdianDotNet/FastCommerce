namespace FastCommerce.Domain.Common;

public class PagingModel
{
    public int Page { get; set; }
    public int PageSize { get; set; } = int.MaxValue;
    public string OrderBy { get; set; } = "Created";
    public SortDirection SortDirection { get; set; } = SortDirection.Descending;
}
