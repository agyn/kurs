namespace Kurs.Shared.Data.Dtos
{
    public class ExchangerSearchDto : PaginationDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}