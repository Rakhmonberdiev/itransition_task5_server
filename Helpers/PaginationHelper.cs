namespace itransition_task5_server.Helpers
{
    public static class PaginationHelper
    {
        public static (int Skip, int Take) Calculate(int page, int pageSize, int initialPageSize)
        {
            if (page == 0)
                return (0, initialPageSize);

            int skip = initialPageSize + (page - 1) * pageSize;
            return (skip, pageSize);
        }
    }
}
