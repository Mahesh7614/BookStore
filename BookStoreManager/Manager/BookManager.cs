using BookStoreManager.Interface;
using BookStoreModel;
using BookStoreRepository.Interface;

namespace BookStoreManager.Manager
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository bookRepository;
        public BookManager(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public BookModel AddBook(BookModel bookModel)
        {
            try
            {
                return this.bookRepository.AddBook(bookModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public BookModel UpdateBook(int BookID, BookModel bookModel)
        {
            try
            {
                return this.bookRepository.UpdateBook(BookID, bookModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteBook(int BookID)
        {
            try
            {
                return this.bookRepository.DeleteBook(BookID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BookModel> GetAllBook()
        {
            try
            {
                return this.bookRepository.GetAllBook();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public BookModel GetBookByID(int BookID)
        {
            try
            {
                return this.bookRepository.GetBookByID(BookID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
