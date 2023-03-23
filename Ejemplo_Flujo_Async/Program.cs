using Ejemplo_Flujo_Async;
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

//----------------------[Parte Sincrona]------------------------------------------ 
/*Console.WriteLine("\nBienvenido a la calculadora de hipotecas sincorna");

var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosDeVidaLaboral();
Console.WriteLine($"\nAños de vida laboral obtenido: {aniosVidaLaboral}");

var contratoIndefinido = CalculadoraHipotecaSync.EsContratoIndefinido();
Console.WriteLine($"\nEs contrato indefinido: {(contratoIndefinido ? "Si" : "No")}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo neto obtenido: {sueldoNeto}€");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos mensuales obtenido: {gastosMensuales}€");

var hipotecaConcedida = CalculadoraHipotecaSync.SeConedeHipoteca(
    aniosVidaLaboral, contratoIndefinido, sueldoNeto, gastosMensuales, cantidadSolicitada: 50000, aniosPagar: 30);

var resultado = hipotecaConcedida ? "Aprobada" : "Rechazada";

Console.WriteLine($"\nAnalisis finalizado.\nSu solicitudo de hipoteca fue: {resultado}");


stopwatch.Stop();

Console.WriteLine($"\nLa operacion a durado: {stopwatch.Elapsed}");*/

//----------------------[Parte Asincrona]------------------------------------------ 
Console.WriteLine("\nBienvenido a la calculadora de hipotecas Asincorna");

var aniosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAniosDeVidaLaboral();
var contratoIndefinidoTask = CalculadoraHipotecaAsync.EsContratoIndefinido();
var sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();
var gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();

var analisisHipotcaTask = new List<Task>
{
    aniosVidaLaboralTask,
    contratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while (analisisHipotcaTask.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotcaTask);
    if (tareaFinalizada == aniosVidaLaboralTask)
    {
        Console.WriteLine($"\nAños de vida laboral obtenido: {aniosVidaLaboralTask.Result}");

    }
    else if (tareaFinalizada == contratoIndefinidoTask)
    {
        Console.WriteLine($"\nEs contrato indefinido: {(contratoIndefinidoTask.Result ? "Si" : "No")}");

    }
    else if(tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {sueldoNetoTask.Result}€");

    }
    else if(tareaFinalizada == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos mensuales obtenido: {gastosMensualesTask.Result}€");

    }

    analisisHipotcaTask.Remove(tareaFinalizada); //eliminamos de la lista de tareas para ir vaciando y salir del while
}

var hipotecaConcedida = CalculadoraHipotecaAsync.SeConedeHipoteca(
    aniosVidaLaboralTask.Result, contratoIndefinidoTask.Result, sueldoNetoTask.Result, gastosMensualesTask.Result,
    cantidadSolicitada: 50000, aniosPagar: 30);

var resultado = hipotecaConcedida ? "Aprobada" : "Rechazada";

Console.WriteLine($"\nAnalisis finalizado.\nSu solicitudo de hipoteca fue: {resultado}");


stopwatch.Stop();

Console.WriteLine($"\nLa operacion a durado: {stopwatch.Elapsed}");


