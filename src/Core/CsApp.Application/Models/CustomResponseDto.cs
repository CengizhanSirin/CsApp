namespace CsApp.Application.Models
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        public int HttpStatus { get; set; }
    }
}
