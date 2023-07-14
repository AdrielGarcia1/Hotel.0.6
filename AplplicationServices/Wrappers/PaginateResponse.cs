namespace ApplicationServices.Wrappers
{
    public class PaginateResponse<T> : Response<T>
    {
        public int PageNumber { get; set; } // Número de página
        public int PageSize { get; set; } // Tamaño de página
        public bool IsDeleted { get; set; } // Indicador de eliminación

        public PaginateResponse(T data, int pageNumber, int pageSize, bool isDeleted)
        {
            // Constructor que establece los valores de página, tamaño, datos y otras propiedades heredadas
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