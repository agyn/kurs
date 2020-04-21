namespace Kurs.Shared.Data.Dtos
{
    public class KursSearchDto : PaginationDto
    {
        public string Name { get; set; }
        public int UserId {get;set;}
    }
}