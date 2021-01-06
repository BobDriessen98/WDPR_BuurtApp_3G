using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WDPR_BuurtApp_3G.Models

    //Viewmodel die wordt gebruikt op de lijst met meldingen op te delen in verschillende paginas.
{
    public class GepagineerdeLijst<Melding> : List<Melding>
    {
        public int Pagina { get; private set; }
        public int PaginaAantal { get; private set; }
        public GepagineerdeLijst(List<Melding> lijstDeel, int totaalAantal, int pagina, int perPagina)
        {
            Pagina = pagina;
            PaginaAantal = (int)Math.Ceiling(totaalAantal / (double)perPagina);
            this.AddRange(lijstDeel);
        }
        //Methoden om te controleren of er een vorige/volgende pagina is
        public bool HeeftVorige() { return Pagina > 0; }
        public bool HeeftVolgende() { return Pagina < PaginaAantal - 1; }

        public static async Task<GepagineerdeLijst<Melding>> CreateAsync(
        IQueryable<Melding> lijst, int pagina, int perPagina)
        {
            return new GepagineerdeLijst<Melding>(
                await lijst.Skip(pagina * perPagina).Take(perPagina).ToListAsync(),
                await lijst.CountAsync(),
                pagina,
                perPagina);
        }

    }

}