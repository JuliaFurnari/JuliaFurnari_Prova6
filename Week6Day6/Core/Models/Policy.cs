using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Day6.Core.Models
{
    //Le polizze hanno le seguenti proprietà:
    //Id (int, PK, auto-incrementale)
    //Numero Polizza (int, not nullable)
    //Data di scadenza (date)
    //Rata mensile(decimal)
    //Tipo (RCAuto, Furto, Vita)
    //Ogni polizza è personalizzata per un cliente per cui viene inserita la NP 
    // e l'ID del cliente per creare la relazione uno a molti con la classe cliente
    class Policy
    {
        public int Id { get; set; }

        [Required]
        public int PolicyNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public TypePolicy Type { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public enum TypePolicy
    {
        RCAuto,
        Theft,
        Life
    }
}
