using itransition_task5_server.DTOs;

namespace itransition_task5_server.Helpers
{
    public static class PaginationHelper
    {
        private const int InitialPageSize = 20;
        public static (int Skip, int Take) Calculate(BookRequestDto req)
        {
            if (req.Page == 0)
                return (0, InitialPageSize);

            int skip = InitialPageSize + (req.Page - 1) * req.PageSize;
            return (skip, req.PageSize);
        }
    }
}
