namespace MVCExercise.Persistence.Queries.Pagination
{
    public record PaginationQuery(int Page, int PageSize, string SortingOrders);
}
