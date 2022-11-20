namespace ApplicationServices.Wrappers
{
    public class PaginateResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsDeleted { get; set; }
        public PaginateResponse(T data, int pageNumber, int pageSize, bool isDeleted)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
            IsDeleted = isDeleted;
        }
    }
}
