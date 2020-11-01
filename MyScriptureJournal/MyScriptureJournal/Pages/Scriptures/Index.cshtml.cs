using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        public string SortByBook { get; set; }
        public string SortByDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ScriptureNote { get; set; }

        public async Task OnGetAsync(string sortData)
        {
            SortByBook = String.IsNullOrEmpty(sortData) ? "sort_book_desc" : "";
            SortByDate = sortData == "DateCreated" ? "sort_date_desc" : "DateCreated";

            var scriptures = from m in _context.Scripture
                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.BookName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureNote))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(ScriptureNote));
            }

            switch (sortData)
            {
                case "sort_book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.BookName);
                    break;
                case "DateCreated":
                    scriptures = scriptures.OrderBy(s => s.DateCreated);
                    break;
                case "sort_date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.DateCreated);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.BookName);
                    break;
            }

            Scripture = await scriptures.ToListAsync();
        }
    }
}
