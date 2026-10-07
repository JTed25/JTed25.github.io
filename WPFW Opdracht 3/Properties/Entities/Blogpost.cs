using System.Data.Common;
using System.Dynamic;

namespace WPFW_Opdracht_3;

public class Blogpost
{
    public int Id {get; set;}
    public string Titel {get; set;} = "";
    public string Inhoud {get; set;} = "";
    public DateTime Datum {get; set;}
}