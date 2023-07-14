namespace ApplicationServices.Wrappers
{
    public class ParameterResponse
    {
        public int PageNumber { get; set; } // Número de página
        public int PageSize { get; set; } // Tamaño de página
        public bool IsDeleted { get; set; } // Indicador de eliminación

        public ParameterResponse()
        {
            // Constructor predeterminado que establece los valores predeterminados de página y tamaño
            PageNumber = 1;
            PageSize = 15;
        }

        public ParameterResponse(int pageNumber, int pageSize)
        {
            // Constructor que permite establecer valores personalizados de página y tamaño
            // Asegura que el número de página sea mayor o igual a 1 y que el tamaño de página no sea mayor que 15
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 15 ? 15 : pageSize;
        }
    }
}