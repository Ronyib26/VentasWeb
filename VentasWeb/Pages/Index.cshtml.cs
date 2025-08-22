using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentasWeb.Models;

namespace VentasWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VentasContext _context;

        public IndexModel(VentasContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int? CategoriaSeleccionada { get; set; }

        public List<SelectListItem> CategoriasConVentas2019 { get; set; } = new List<SelectListItem>();
        public List<string> ProductosVendidos { get; set; } = new List<string>();
        public string? NombreCategoriaSeleccionada { get; set; }

        public async Task OnGetAsync(int? categoriaId = null)
        {

            await CargarCategoriasConVentas2019();


            if (categoriaId.HasValue && categoriaId > 0)
            {
                CategoriaSeleccionada = categoriaId;
                await CargarProductosVendidosPorCategoria(categoriaId.Value);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await CargarCategoriasConVentas2019();


            if (CategoriaSeleccionada.HasValue && CategoriaSeleccionada > 0)
            {
                await CargarProductosVendidosPorCategoria(CategoriaSeleccionada.Value);
            }

            return Page();
        }

        private async Task CargarCategoriasConVentas2019()
        {

            var categorias = await _context.Categoria
                .Where(c => c.Productos.Any(p =>
                    p.Ventas.Any(v => v.Fecha.Year == 2019)))
                .OrderBy(c => c.Nombre)
                .Select(c => new SelectListItem
                {
                    Value = c.CodigoCategoria.ToString(),
                    Text = c.Nombre,
                    Selected = c.CodigoCategoria == CategoriaSeleccionada
                })
                .ToListAsync();


            CategoriasConVentas2019 = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Seleccione una categoría --", Selected = !CategoriaSeleccionada.HasValue }
            };
            CategoriasConVentas2019.AddRange(categorias);
        }

        private async Task CargarProductosVendidosPorCategoria(int categoriaId)
        {

            NombreCategoriaSeleccionada = await _context.Categoria
                .Where(c => c.CodigoCategoria == categoriaId)
                .Select(c => c.Nombre)
                .FirstOrDefaultAsync();

            ProductosVendidos = await _context.Producto
                .Where(p => p.CodigoCategoria == categoriaId &&
                           p.Ventas.Any(v => v.Fecha.Year == 2019))
                .Select(p => p.Nombre)
                .Distinct()
                .OrderBy(nombre => nombre)
                .ToListAsync();
        }
    }
}