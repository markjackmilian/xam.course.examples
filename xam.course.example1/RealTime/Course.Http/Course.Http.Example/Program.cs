// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Net.Http.Json;
using Course.Http.Example;
using Course.Http.Example.Resources;
using HttpTracer;
using HttpTracer.Logger;
using Refit;

Console.WriteLine("Hello, World!");

// var handler = new HttpClientHandler();
// handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;




// try
// {
//     await rickAndortyclient.AddUser(new RickResponse());
//
// }
// catch (ApiException e)
// {
//     Console.WriteLine(e);
//     throw;
// }

var tracer = new HttpTracerHandler(new Output2())
{
    Verbosity = HttpMessageParts.All
};
var client = new HttpClient(tracer);
client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("PIPPO");
client.DefaultRequestHeaders.Add("Mio-Header","Mio il valore");

var rickAndortyclient = RestService.For<IRickAndMortyResource>(client);
var user = await rickAndortyclient.GetCharacter(2);

// // var response = await client.GetStringAsync("character/2");
// var response = await client.GetFromJsonAsync<RickResponse>("character/2");
//
// await client.PostAsJsonAsync("", response);


// Console.WriteLine(response);


class Output2 : ILogger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
    }
}