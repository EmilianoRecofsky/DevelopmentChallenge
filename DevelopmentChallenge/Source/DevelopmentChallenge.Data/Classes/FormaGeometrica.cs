using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    // TraduccionForma: Clase para guardar el valor de la palabra singular y plural de cada figura, para cada idioma.
    public class TraduccionForma
    {
        private readonly string _singular;
        private readonly string _plural;

        public TraduccionForma(string singular, string plural)
        {
            _singular = singular;
            _plural = plural;
        }

        public string ObtenerTraduccion(int cantidad)
        {
            return cantidad == 1 ? _singular : _plural;
        }
    }

    // FormaGeometrica: Clase principal abstracta de Figura, es la clase "padre" y de la misma heredan cada uno de los tipos de Figura (ejemplo el Cuadrado, Circulo, etc.)
    public abstract class FormaGeometrica
    {
        // Valor del "lado"
        protected readonly decimal _lado;

        // Cada forma geométrica tendrá Traducciones, que guarda para cada idioma el texto en singular y plural de la figura.
        public Dictionary<string, TraduccionForma> Traducciones { get; } = new Dictionary<string, TraduccionForma>();

        protected FormaGeometrica(decimal lado)
        {
            _lado = lado;
        }

        // El cálculo del area de la figura
        public abstract decimal CalcularArea();

        // El cálculo del perímetro de la figura
        public abstract decimal CalcularPerimetro();

        // Método para obtener el texto: cantidad y nombre figura (el cual depende de cantidad para saber si es singular o plural, y el idioma)
        public abstract string ObtenerNombreEnIdioma(int cantidad, string idioma);
    }

    public class Cuadrado : FormaGeometrica
    {
        public Cuadrado(decimal lado) : base(lado)
        {
            Traducciones.Add("Castellano", new TraduccionForma("Cuadrado", "Cuadrados"));
            Traducciones.Add("Ingles", new TraduccionForma("Square", "Squares"));
            Traducciones.Add("Italiano", new TraduccionForma("Quadrato", "Quadrati"));
        }

        public override decimal CalcularArea() => _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 4;

        public override string ObtenerNombreEnIdioma(int cantidad, string idioma)
        {
            // Retorna el texto cantidad y nombre de figura (formando el valor en función del idioma en el Dictionary y singular/plural)
            return $"{cantidad} {Traducciones[idioma].ObtenerTraduccion(cantidad)}";
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(decimal lado) : base(lado)
        {
            Traducciones.Add("Castellano", new TraduccionForma("Triángulo", "Triángulos"));
            Traducciones.Add("Ingles", new TraduccionForma("Triangle", "Triangles"));
            Traducciones.Add("Italiano", new TraduccionForma("Triangolo", "Triangoli"));
        }

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 3;

        public override string ObtenerNombreEnIdioma(int cantidad, string idioma)
        {
            return $"{cantidad} {Traducciones[idioma].ObtenerTraduccion(cantidad)}";
        }
    }

    public class Circulo : FormaGeometrica
    {
        public Circulo(decimal lado) : base(lado)
        {
            Traducciones.Add("Castellano", new TraduccionForma("Círculo", "Círculos"));
            Traducciones.Add("Ingles", new TraduccionForma("Circle", "Circles"));
            Traducciones.Add("Italiano", new TraduccionForma("Cerchio", "Cerchi"));
        }

        public override decimal CalcularArea() => (decimal)Math.PI * (_lado / 2) * (_lado / 2);

        public override decimal CalcularPerimetro() => (decimal)Math.PI * _lado;

        public override string ObtenerNombreEnIdioma(int cantidad, string idioma)
        {
            return $"{cantidad} {Traducciones[idioma].ObtenerTraduccion(cantidad)}";
        }
    }

    public class TrapecioRectangulo : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;

        public TrapecioRectangulo(decimal baseMayor, decimal baseMenor, decimal lado) : base(lado)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;

            Traducciones.Add("Castellano", new TraduccionForma("Trapecio", "trapecios"));
            Traducciones.Add("Ingles", new TraduccionForma("Trapezoid", "Trapezoids"));
            Traducciones.Add("Italiano", new TraduccionForma("Trapezio", "Trapezi"));
        }

        public override decimal CalcularArea() => _lado * ((_baseMenor + _baseMayor) / 2);

        public override decimal CalcularPerimetro() => _baseMenor + _baseMayor + (2 * _lado);

        public override string ObtenerNombreEnIdioma(int cantidad, string idioma)
        {
            return $"{cantidad} {Traducciones[idioma].ObtenerTraduccion(cantidad)}";
        }
    }

    public class IdiomaReporteImpreso
    {
        public string NombreIdioma { get; set; }
        public string TextoCuandoEsVacio { get; set; }
        public string TextoHeader { get; set; }
        public string TextoTotal { get; set; }
        public string TextoFormas { get; set; }
        public string TextoPerimetro { get; set; }
        public string TextoArea { get; set; }
    }

    public class Castellano : IdiomaReporteImpreso
    {
        public Castellano()
        {
            NombreIdioma = "Castellano";
            TextoCuandoEsVacio = "<h1>Lista vacía de formas!</h1>";
            TextoHeader = "<h1>Reporte de Formas</h1>";
            TextoTotal = "TOTAL";
            TextoFormas = "formas";
            TextoPerimetro = "Perimetro";
            TextoArea = "Area";
        }
    }

    public class Ingles : IdiomaReporteImpreso
    {
        public Ingles()
        {
            NombreIdioma = "Ingles";
            TextoCuandoEsVacio = "<h1>Empty list of shapes!</h1>";
            TextoHeader = "<h1>Shapes report</h1>";
            TextoTotal = "TOTAL";
            TextoFormas = "shapes";
            TextoPerimetro = "Perimeter";
            TextoArea = "Area";
        }
    }

    public class Italiano : IdiomaReporteImpreso
    {
        public Italiano()
        {
            NombreIdioma = "Italiano";
            TextoCuandoEsVacio = "<h1>Lista vuota di forme!</h1>";
            TextoHeader = "<h1>Report di forme</h1>";
            TextoTotal = "TOTALE";
            TextoFormas = "forme";
            TextoPerimetro = "Perimetro";
            TextoArea = "Area";
        }
    }

    public class FormasReporte
    {
        public static string Imprimir(List<FormaGeometrica> formas, string nombreIdioma)
        {
            // Se obtiene la instancia de clase (objeto) del idioma entrante para generar el reporte imprimir
            IdiomaReporteImpreso idioma;
            // Dado el nombreIdioma instancio clase (hago esto porque seguimos usando el envío de "id Idioma" (nombreIdioma) desde el lugar invocador)
            switch (nombreIdioma)
            {
                case "Castellano":
                    idioma = new Castellano();
                    break;
                case "Ingles":
                    idioma = new Ingles();
                    break;
                case "Italiano":
                    idioma = new Italiano();
                    break;
                default:
                    throw new ArgumentException("Idioma no soportado", nameof(nombreIdioma));
            }
            var sb = new StringBuilder();
            if (!formas.Any())
            {
                // Si no hay formas: el texto de vacío (pero dependiendo del idioma)
                sb.Append(idioma.TextoCuandoEsVacio);
            }
            else
            {
                // El texto de header (dependiendo del idioma)
                sb.Append(idioma.TextoHeader);
                // Agrupo formas por su tipo (Ejemplo, agrupo todos los Cuadrados, todos los Circulos, etc.)
                var gruposPorTipo = formas.GroupBy(f => f.GetType());
                // Se obtienen los textos para el reporte imprimir, pero dependiendo del idioma
                var traduccionTextoFormas = idioma.TextoFormas;
                var traduccionTextoArea = idioma.TextoArea;
                var traduccionTextoPerimetro = idioma.TextoPerimetro;
                // Se recorren los grupos (de formas)
                foreach (var grupo in gruposPorTipo)
                {
                    // Nombre del tipo de forma
                    var tipoForma = grupo.Key.Name;
                    // Cantidad de formas de este tipo
                    var cantidad = grupo.Count();
                    decimal areaTotal = grupo.Sum(f => f.CalcularArea());
                    decimal perimetroTotal = grupo.Sum(f => f.CalcularPerimetro());
                    // De la forma, se obtiene la traduccion al idioma requerido
                    var traduccionTipoForma = grupo.First().Traducciones[nombreIdioma];
                    // ObtenerTraduccion dado cantidad me da el singular o plural del idioma requerido para esa forma
                    sb.Append($"{cantidad} {traduccionTipoForma.ObtenerTraduccion(cantidad)} | ");
                    sb.Append($"{traduccionTextoArea} {areaTotal.ToString("#.##")} | ");
                    sb.Append($"{traduccionTextoPerimetro} {perimetroTotal.ToString("#.##")} <br/>");
                }
                // FOOTER
                var totalFormas = formas.Count;
                // El area total
                decimal totalArea = formas.Sum(f => f.CalcularArea());
                // El perimetro total
                decimal totalPerimetro = formas.Sum(f => f.CalcularPerimetro());
                // Se agregan lineas footer
                sb.Append($"{idioma.TextoTotal}:<br/>{totalFormas} {traduccionTextoFormas} ");
                sb.Append($"{traduccionTextoPerimetro} {totalPerimetro.ToString("#.##")} {traduccionTextoArea} {totalArea.ToString("#.##")}");
            }
            return sb.ToString();
        }
    }
}
