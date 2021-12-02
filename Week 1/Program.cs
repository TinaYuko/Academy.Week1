// See https://aka.ms/new-console-template for more information
using Week_1;

Console.WriteLine("Hello, World!");

int a; //dichiarazione
a = 1; //assegnazione

int b = 2; //inizializzazione
b = 3; //lo riassegno

long c;

//decimal si usano per i decimali for the money

float e, f = 2.35F, g; //Posso dichiarare, inizializzare più variabili dello stesso tipo assieme

int h = 10;
h = 'c';

//Non si può mettere una stringa dentro un intero
//quindi per esempio no puedo poi fare h="ciao"

int i = 10000000;
long j = i;

long k = 1000000000000000000;
// non posso spostare un long in un intero int l = k
// però posso fare: 
int l = (int)k; //faccio il cast ma perdo informazioni

bool isValid = true; //il false è do default
char m = 'm';

DateTime date1 = new DateTime(2021, 4, 2);
DateTime date2 = new DateTime(); //rimane 0000,00,00
DateTime now=DateTime.Now;
DateTime today = DateTime.Today;

//Value type e reference type
int n = 100;
int o = n; //o=100
n = 1000;
o = 2000;

Console.WriteLine($"Valore di n: {n} e valore di o:{o} ");
Prodotto p1 = new Prodotto();
p1.Nome = "Chiavetta USB";

Prodotto p2 = p1;
p2.Nome = "Chiavetta USB 5.1";

//il var riconosce il tipo di oggetto da solo
var cognome = "Mattana";
var p = 30f;
var p3 = new Prodotto();

object r= new object();

PrintNumbers(1, 2, 3, 4, 5);

//Idem con patate se faccio così
int[] myArray = { 5, 6, 7, 8, 9, 10 };
Console.WriteLine("");
PrintNumbers(myArray);
PrintNumbers2(myArray);

//Tuple
(int, string) t = (30, "abc");
Console.WriteLine(t.Item1 + "" + t.Item2);

(string code, string descrizione) t2 = ("ABC123", "Zaino");
Console.WriteLine(t2.code + "" + t2.descrizione);

var t3 = (c: "ABC", d: "Monitor");

var (mean, sum) = CalcoloSumMean(myArray);

p3.Nome = "Custodia";

#region Metodi
static void PrintNumbers(params int[] list)
{
    //Posso passargli un numero x a caso di parametri, in questo caso di interi

    for (int i = 0; i < list.Length; i++)
    {
        Console.WriteLine(list[i]);
    }
}
static void PrintNumbers2(params object[] list)
{
    //Posso passargli un numero x a caso di parametri, in questo caso di interi

    for (int i = 0; i < list.Length; i++)
    {
        Console.WriteLine(list[i]);
    }
}

static Prodotto GetProdotto (Prodotto p)
{
    p.Nome += "123";
    return p;
}

static (int mean, int sum) CalcoloSumMean(int[] myArray)
{
    //calcolo media e somma
    return (10, 20);
}
#endregion Metodi