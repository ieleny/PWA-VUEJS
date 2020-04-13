using System;

namespace AspNetCore.Model
{
  
  public class Product
  {
    public string   Id { get; set; }
    public string   Nome { get; set; }
    public float    Valor  { get; set; }
    public int      Categoria {get; set;}
    public DateTime Data_criacao { get; set; }

  }

}