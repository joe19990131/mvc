using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkShop4.Controllers
{
    public class MainController : Controller
    {
        Models.SearchService searchService = new Models.SearchService();
        Models.CodeService codeService = new Models.CodeService();
        // GET: Main
        [HttpGet()]
        public ActionResult SearchBook() {
            ViewBag.BookClassCodeData = this.codeService.GetClassCodeTable();
            ViewBag.BookKeeperCodeData = this.codeService.GetBookKeeperTable();
            ViewBag.BookStatusCodeData = this.codeService.GetBookStatusTable();
            return View();
        }


        [HttpPost()]
        public ActionResult SearchBook(Models.Search arg)
        {
            Models.SearchService searchService = new Models.SearchService();
            ViewBag.BookClassCodeData = this.codeService.GetClassCodeTable();
            ViewBag.BookKeeperCodeData = this.codeService.GetBookKeeperTable();
            ViewBag.BookStatusCodeData = this.codeService.GetBookStatusTable();
            ViewBag.SearchResult = searchService.GetBookByCondtioin(arg);
            //ViewBag.JobTitleCodeData = this.searchService.GetCodeTable("TITLE");
            return View("SearchBook");
        }

        [HttpPost()]
        public JsonResult DeleteBook(int bookId) {
            try
            {
                Models.SearchService searchService = new Models.SearchService();
                searchService.DeleteBookByName(bookId);
                return this.Json(true);
            }

            catch (Exception ex)
            {
                return this.Json(false);
            }
        }


        [HttpGet()]
        public ActionResult InsertBook()
        {
            ViewBag.BookClassCodeData = this.codeService.GetClassCodeTable();

            return View(new Models.Books());
        }

        [HttpPost()]
        public ActionResult InsertBook(Models.Books book)
        {
            ViewBag.BookData = this.codeService.GetClassCodeTable();
          
                Models.SearchService searchService = new Models.SearchService();
                ViewBag.BookClassCodeData = this.codeService.GetClassCodeTable();
                searchService.InsertBook(book);
                TempData["message"] = "存檔成功";
            
            return View(book);
        }

        [HttpGet()]
        public ActionResult LendRecord()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult LendRecord(int bookId)
        {
            Models.SearchService searchService = new Models.SearchService();
            ViewBag.LendRecord = searchService.GetRecordByCondtioin(bookId);
            return View("LendRecord");
        }

       

    }
   
}