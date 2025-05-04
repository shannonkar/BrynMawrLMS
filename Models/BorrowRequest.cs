namespace BrynMawrLMS.Models
{
    public class BorrowRequest
    {
        public string CatalogueID { get; set; }
        public string MemberID { get; set; }
        public int DueDays { get; set; } = 60;
        public string Librarian {  get; set; }
    }
}
