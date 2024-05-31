using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;
using YourNamespace.Data;

namespace YourNamespace.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MangasController : ControllerBase {
        private readonly AnimeContext _context;

        public MangasController(AnimeContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manga>>> GetMangas() {
            return await _context.Mangas.Include(m => m.Pais).Include(m => m.Tipo).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manga>> GetManga(int id) {
            var manga = await _context.Mangas.Include(m => m.Pais).Include(m => m.Tipo).FirstOrDefaultAsync(m => m.Id == id);

            if (manga == null) {
                return NotFound(new { error = true, msg = "Objeto no encontrado" });
            }

            return manga;
        }

        [HttpPost]
        public async Task<ActionResult<Manga>> CreateManga(Manga manga) {
            if (!_context.Paises.Any(p => p.Id == manga.PaisId)) {
                return BadRequest(new { error = true, msg = "Pais no existe" });
            }
            if (!_context.Tipos.Any(t => t.Id == manga.TipoId)) {
                return BadRequest(new { error = true, msg = "Tipo no existe" });
            }

            _context.Mangas.Add(manga);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManga), new { id = manga.Id }, manga);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManga(int id, Manga manga) {
