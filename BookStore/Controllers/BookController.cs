using BookStoreManager.Interface;
using BookStoreModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.Controllers
{
    [Route("BookStore/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager bookManager;
        private readonly IDistributedCache distributedCache;
        public BookController(IBookManager bookManager, IDistributedCache distributedCache)
        {
            this.bookManager = bookManager;
            this.distributedCache = distributedCache;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("BookStore/AddBook")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                BookModel bookData = this.bookManager.AddBook(bookModel);
                if (bookData != null)
                {
                    return this.Ok(new { success = true, message = "Book Added Successfully", result = bookData });
                }
                return this.Ok(new { success = true, message = "Book Name Already Exists" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("BookStore/UpdateBook")]
        public IActionResult UpdateBook(int BookID, BookModel bookModel)
        {
            try
            {
                BookModel bookData = this.bookManager.UpdateBook(BookID, bookModel);
                if (bookData != null)
                {
                    return this.Ok(new { success = true, message = "Book Updated Successfully", result = bookData });
                }
                return this.Ok(new { success = true, message = "Book Not Updated" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("BookStore/DeleteBook")]
        public IActionResult DeleteBook(int BookID)
        {
            try
            {
                bool deleteBook = this.bookManager.DeleteBook(BookID);
                if (deleteBook)
                {
                    return this.Ok(new { success = true, message = "Book Deleted Successfully", result = deleteBook });
                }
                return this.Ok(new { success = true, message = "Book Not Deleted" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("BookStore/GetAllBook")]
        public IActionResult GetAllBook()
        {
            try
            {
                List<BookModel> allBooks = this.bookManager.GetAllBook();
                if (allBooks != null)
                {
                    return this.Ok(new { success = true, message = "All Books Get Successfully", result = allBooks });
                }
                return this.Ok(new { success = true, message = "No Books Present" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize(Roles = Role.User)]
        [HttpGet]
        [Route("BookStore/GetBookByID")]
        public IActionResult GetBookByID(int BookID)
        {
            try
            {
                BookModel Book = this.bookManager.GetBookByID(BookID);
                if (Book != null)
                {
                    return this.Ok(new { success = true, message = "Book Get Successfully", result = Book });
                }
                return this.Ok(new { success = true, message = "Enter Valid Book ID" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetAllBooksUsingRadisCache")]
        public async Task<IActionResult> GetAllNotesUsingRadis()
        {
            try
            {
                var cacheKey = "BooksList";
                List<BookModel> noteList;
                byte[] redisNoteList = await this.distributedCache.GetAsync(cacheKey);
                if (redisNoteList != null)
                {
                    var serializedNoteList = Encoding.UTF8.GetString(redisNoteList);
                    noteList = JsonConvert.DeserializeObject<List<BookModel>>(serializedNoteList);
                }
                else
                {
                    noteList = this.bookManager.GetAllBook();
                    var serializedNoteList = JsonConvert.SerializeObject(noteList);
                    var newRedisNoteList = Encoding.UTF8.GetBytes(serializedNoteList);
                    var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)).SetSlidingExpiration(TimeSpan.FromMinutes(5));
                    await this.distributedCache.SetAsync(cacheKey, newRedisNoteList, options);
                }

                return this.Ok(noteList);
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { sucess = false, message = ex.Message });
            }
        }
    }
}
