using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDPR_BuurtApp_3G.Data;
using WDPR_BuurtApp_3G.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WDPR_BuurtApp_3G.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using WDPR_BuurtApp_3G.Models.ViewModels;

namespace WDPR_BuurtApp_3G.Controllers
{
    [Authorize]
    public class MeldingsController : Controller
    {
        private readonly WDPR_BuurtApp_3GContext _context;
        private readonly UserManager<WDPR_BuurtApp_3GUser> _userManager;
      
        public MeldingsController(WDPR_BuurtApp_3GContext context, UserManager<WDPR_BuurtApp_3GUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Meldings
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Index()
        {
            var wDPR_BuurtApp_3GContext = _context.Melding.Include(m => m.Categorie).Include(m => m.User);
            return View(await wDPR_BuurtApp_3GContext.ToListAsync());
        }

        // GET: Meldings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["LoggedInID"] = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (id == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MeldingID == id);
            if (melding == null)
            {
                return NotFound();
            }

            melding.AantalViews += 1;
            _context.Update(melding);
            await _context.SaveChangesAsync();
            MaakReactieVM reactieVM = new MaakReactieVM { Melding = melding };
            return View(reactieVM);
        }

        // GET: Meldings/Create
        public IActionResult Create()
        {
            ViewData["LoggedInID"] = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieID");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            MaakMeldingVM createVM = new MaakMeldingVM { Categories = _context.Categorie.ToList() };
            return View(createVM);
        }

        // POST: Meldings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeldingID,UserID,Titel,Omschrijving,CategorieID,Datum,Foto,Gesloten")] Melding melding)
        { 
            if(melding.Titel.Length < 3)
            {
                ViewData["TitelLengteError"] = "De titel moet minimaal 4 karakters bevatten.";
            }
            if(melding.Omschrijving.Length < 10)
            {
                ViewData["OmschrijvingError"] = "De omschrijving moet minimaal 10 karakters bevatten.";
            }
            if(_context.Melding.Any(m => m.Titel.Contains(melding.Titel)))
            {
                ViewData["TitelBestaatError"] = "De gekozen titel lijkt te erg op een al bestaande titel.";
            }
            if(melding.Omschrijving.Length < 10 || melding.Titel.Length < 3 || _context.Melding.Any(m => m.Titel.Contains(melding.Titel)))
            {
                MaakMeldingVM createVM = new MaakMeldingVM { Categories = _context.Categorie.ToList() };
                return View(createVM);
            }
            if(melding.Foto == null){
                melding.Foto = "https://vidi-touch.eu/wp-content/themes/vidistri/img/geen-afbeelding.jpg";
            }
            if (ModelState.IsValid)
            {
                _context.Add(melding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(OverzichtMeldingen));
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieID", melding.CategorieID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", melding.UserID);
            return View(melding);
        }
        [Authorize(Roles = "Moderator")]
        // GET: Meldings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding.FindAsync(id);
            if (melding == null)
            {
                return NotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieID", melding.CategorieID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", melding.UserID);
            return View(melding);
        }

        // POST: Meldings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("MeldingID,UserID,Titel,Omschrijving,CategorieID,Datum,Foto,Gesloten")] Melding melding)
        {
            if (id != melding.MeldingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(melding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeldingExists(melding.MeldingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieID", melding.CategorieID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", melding.UserID);
            return View(melding);
        }

        // GET: Meldings/Delete/5
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding
                .Include(m => m.Categorie)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MeldingID == id);
            if (melding == null)
            {
                return NotFound();
            }

            return View(melding);
        }

        // POST: Meldings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var melding = await _context.Melding.FindAsync(id);
            _context.Melding.Remove(melding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BeheerMeldingen));
        }

        private bool MeldingExists(int id)
        {
            return _context.Melding.Any(e => e.MeldingID == id);
        }

        //Indexpagina die wordt gebruikt om meldingen weer te geven, opgedeeld in pagina's
        public async Task<IActionResult> OverzichtMeldingen(int pagina, string sorteerType, string sorteerVolgorde, string filter, string status, string poster, DateTime date1, DateTime date2, bool likedby)
        {

            //Standaardwaarden indien parameters null zijn
            if (sorteerType == null)
            {
                sorteerType = "Datum";
            }
            if (sorteerVolgorde == null)
            {
                sorteerVolgorde = "aflopend";
            }
            if (status == null)
            {
                status = "Open";
            }
            if (poster == null)
            {
                poster = "Toon alles";
            }
            //Maak een user aan identiek aan de user die op dit moment is ingelogd. De FindByIDAsync methode zoekt een user in de usermanager. 
            //De parameter is een UserID. Deze wordt gevonden doormiddel van this.user (het huidig ingelogde user van het type ClaimType), waarna de eerste 
            //waarde hiervan wordt gevonden (van het type UserID).
            WDPR_BuurtApp_3GUser user = await _userManager.FindByIdAsync(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            //Check of ingelogd user moderator is. Boolean wordt meegestuurd in de viewdata
            ViewData["UserIsModerator"] = false;
            if (await _userManager.IsInRoleAsync(user, "Moderator"))
            {
                ViewData["UserIsModerator"] = true;
            }
            ViewData["Likedby"] = likedby;
            ViewData["Filter"] = filter;
            ViewData["SorteerType"] = sorteerType;
            ViewData["SorteerVolgorde"] = sorteerVolgorde;
            ViewData["Status"] = status;
            ViewData["Poster"] = poster;
            ViewData["Date1"] = DateFormat(date1);
            ViewData["Date2"] = DateFormat(date2);
            ViewData["LoggedInID"] = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //Stuur een gepagineerde, gesorteerde en gefilterde lijst mee terug aan de view.
            return View(await GepagineerdeLijst<Melding>.CreateAsync(DateRange(Filter(Sort(sorteerVolgorde, sorteerType), filter, status, poster, likedby), date1, date2), pagina, 5));
        }

        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> BeheerMeldingen(int pagina, string sorteerType, string sorteerVolgorde, string filter, string status, string poster, DateTime date1, DateTime date2, bool likedby)
        {
            //Standaardwaarden indien parameters null zijn
            if (sorteerType == null)
            {
                sorteerType = "Datum";
            }
            if (sorteerVolgorde == null)
            {
                sorteerVolgorde = "aflopend";
            }
            if (status == null)
            {
                status = "Open";
            }
            if (poster == null)
            {
                poster = "Toon alles";
            }

            ViewData["Filter"] = filter;
            ViewData["SorteerType"] = sorteerType;
            ViewData["SorteerVolgorde"] = sorteerVolgorde;
            ViewData["Status"] = status;
            ViewData["Poster"] = poster;
            ViewData["Date1"] = DateFormat(date1);
            ViewData["Date2"] = DateFormat(date2);
            ViewData["Likedby"] = likedby;

            //Stuur een gepagineerde, gesorteerde en gefilterde lijst mee terug aan de view.
            return View(await GepagineerdeLijst<Melding>.CreateAsync(DateRange(Filter(Sort(sorteerVolgorde, sorteerType), filter, status, poster, likedby), date1, date2), pagina, 5));
        }
        //Filtermethode die in een meegegeven lijst zoekt naar een bepaalde string. Geeft gefilterde lijst terug.
        private IQueryable<Melding> Filter(IQueryable<Melding> lijst, string filter, string status, string poster, bool likedby)
        {

            if (!String.IsNullOrEmpty(filter))
                lijst = lijst.Where(s => s.Omschrijving.Contains(filter));
            switch (poster)
            {
                case "Eigen": lijst = lijst.Where(m => m.UserID == this.User.FindFirst(ClaimTypes.NameIdentifier).Value); break;
                case "Toon alles": break;
            }
            switch (status)
            {
                case "Open": lijst = lijst.Where(m => m.Gesloten == false); break;
                case "Gesloten": lijst = lijst.Where(m => m.Gesloten == true); break;
                case "Toon alles": lijst = lijst.Where(m => m.Gesloten == true || m.Gesloten == false); break;
            }
            if (likedby)
            {
                lijst = lijst.Where(m => m.Likes.Where(l => l.UserID == this.User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault().MeldingID == m.MeldingID);
            }
            return lijst;
        }

        private IQueryable<Melding> DateRange(IQueryable<Melding> lijst, DateTime date1, DateTime date2)
        {
            DateTime datumIsNull = new DateTime(1, 1, 0001, 00, 00, 00);
            if (!date1.Equals(datumIsNull) && !date2.Equals(datumIsNull))
            {
                List<DateTime> datumlijst = new List<DateTime>() { date1, date2.AddHours(23).AddMinutes(59).AddSeconds(59) };
                lijst = lijst.Where(m => m.Datum >= datumlijst.Min() && m.Datum <= datumlijst.Max());
            }
            else if (!date1.Equals(datumIsNull) && date2.Equals(datumIsNull))
            {
                lijst = lijst.Where(m => m.Datum >= date1);
            }
            else if (date1.Equals(datumIsNull) && !date2.Equals(datumIsNull))
            {
                lijst = lijst.Where(m => m.Datum <= date2.AddHours(23).AddMinutes(59).AddSeconds(59));
            }
            return lijst;
        }

        //Sorteermethode die lijst sorteerd op basis van de meegegeven parameters.
        private IQueryable<Melding> Sort(string sorteerVolgorde, string sorteerType)
        {
            IQueryable<Melding> lijst = _context.Melding.Include(m => m.Categorie).Include(m => m.User);

            if (sorteerType == "Datum")
            {
                switch (sorteerVolgorde)
                {
                    case "aflopend": lijst = lijst.OrderByDescending(s => s.Datum); break;
                    default: lijst = lijst.OrderBy(s => s.Datum); break;
                }
            }
            else if (sorteerType == "Likes")
            {
                switch (sorteerVolgorde)
                {
                    case "aflopend": lijst = lijst.OrderByDescending(s => s.Likes.Count); break;
                    default: lijst = lijst.OrderBy(s => s.Likes.Count); break;
                }
            }
            else if (sorteerType == "Reacties")
            {
                switch (sorteerVolgorde)
                {
                    case "aflopend": lijst = lijst.OrderByDescending(s => s.Reacties.Count); break;
                    default: lijst = lijst.OrderBy(s => s.Reacties.Count); break;
                }
            }
            return lijst;
        }

        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> MeldingSluiten(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var melding = await _context.Melding
                .Include(m => m.Categorie)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MeldingID == id);
            if (melding == null)
            {
                return NotFound();
            }

            return View(melding);
        }

        // POST: Meldings/Delete/5
        [HttpPost, ActionName("MeldingSluiten")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> MeldingSluitenConfirmed(int id)
        {
            //Zoek melding in context, sluit de melding, update de context, sla veranderingen op
            var melding = await _context.Melding.FindAsync(id);
            melding.Gesloten = true;
            _context.Melding.Update(melding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BeheerMeldingen));
        }

        public string DateFormat(DateTime datum)
        {

            string maand;
            string dag;

            if (datum.Month.ToString().Length < 2)
            {
                maand = 0 + datum.Month.ToString();
            }
            else maand = datum.Month.ToString();
            if (datum.Day.ToString().Length < 2)
            {
                dag = 0 + datum.Day.ToString();
            }
            else dag = datum.Day.ToString();

            return (datum.Year.ToString() + "-" + maand + "-" + dag);

        }

    }
}
