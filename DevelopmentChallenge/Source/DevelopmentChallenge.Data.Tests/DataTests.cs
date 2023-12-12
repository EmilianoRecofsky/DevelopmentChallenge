using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class DataTests
{
    [TestCase]
    public void TestResumenListaVacia()
    {
        Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
            FormasReporte.Imprimir(new List<FormaGeometrica>(), "Castellano"));
    }

    [TestCase]
    public void TestResumenListaVaciaFormasEnIngles()
    {
        Assert.AreEqual("<h1>Empty list of shapes!</h1>",
            FormasReporte.Imprimir(new List<FormaGeometrica>(), "Ingles"));
    }

    [TestCase]
    public void TestResumenListaConUnCuadrado()
    {
        var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };
        var resumen = FormasReporte.Imprimir(cuadrados, "Castellano");
        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
    }

    [TestCase]
    public void TestResumenListaConMasCuadrados()
    {
        var cuadrados = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Cuadrado(1),
            new Cuadrado(3)
        };
        var resumen = FormasReporte.Imprimir(cuadrados, "Ingles");
        Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTipos()
    {
        var formas = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };
        var resumen = FormasReporte.Imprimir(formas, "Ingles");
        Assert.AreEqual(
            "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
            resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTiposEnCastellano()
    {
        var formas = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };
        var resumen = FormasReporte.Imprimir(formas, "Castellano");
        Assert.AreEqual(
            "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
            resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTiposEnItaliano()
    {
        var formas = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };
        var resumen = FormasReporte.Imprimir(formas, "Italiano");
        Assert.AreEqual(
            "<h1>Report di forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 forme Perimetro 97,66 Area 91,65",
            resumen);
    }

    [TestCase]
    public void TestResumenListaConFormasEspeciales()
    {
        var formasEspeciales = new List<FormaGeometrica>
        {
            new Cuadrado(5),
            new Circulo(3),
            new TrianguloEquilatero(4),
            new TrapecioRectangulo(6, 4, 5.5m),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };
        var resumen = FormasReporte.Imprimir(formasEspeciales, "Ingles");
        Assert.AreEqual(
            "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>1 Trapezoid | Area 27,5 | Perimeter 21 <br/>TOTAL:<br/>8 shapes Perimeter 118,66 Area 119,15",
            resumen);
    }

}
