
using BrynMawrLMS.Data;
using BrynMawrLMS.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BrynMawrLMS.Repositories
{
    public class LMSRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public LMSRepository(AppDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        // Books
        public IEnumerable<Book> GetAllBooks() => _context.Books.ToList();

        // Genres
        public IEnumerable<Genre> GetAllGenres() => _context.Genres.ToList();

        // Authors
        public IEnumerable<Author> GetAllAuthors() => _context.Authors.ToList();

        // Catalogues
        public IEnumerable<Catalogue> GetAllCatalogues() => _context.Catalogues.ToList();

        //Publishers
        public IEnumerable<Publisher> GetAllPublishers() => _context.Publishers.ToList();

        // Librarians
        public IEnumerable<Librarian> GetAllLibrarians() => _context.Librarians.ToList();

        // Members
        public IEnumerable<Member> GetAllMembers() => _context.Members.ToList();

        // Borrowing Records
        public IEnumerable<Borrowingrecord> GetAllBorrowingRecords() => _context.Borrowingrecords.ToList();
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        //Call Borrow Book Stored procedure
        public string BorrowBook(string catalogueId, string memberId, int dueDays, string librarian)
        {
            using (var conn = new OracleConnection(_connectionString))
            using (var cmd = new OracleCommand("BorrowBook", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_catalogueID", OracleDbType.Varchar2).Value = catalogueId;
                cmd.Parameters.Add("p_memberID", OracleDbType.Varchar2).Value = memberId;
                cmd.Parameters.Add("p_DueDays", OracleDbType.Int32).Value = dueDays;
                cmd.Parameters.Add("p_librarian", OracleDbType.Varchar2).Value = librarian;

               
                var resultParam = new OracleParameter("p_result", OracleDbType.Varchar2, 4000)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultParam);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return resultParam.Value?.ToString();
            }
        }
    }

}

