using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Day6.Core.Models
{
    //I clienti hanno le seguenti proprietà:
    //Id (int, PK, auto-incrementale)
    //Codice Fiscale (nchar(16), not nullable)
    //Nome (varchar(30))
    //Cognome(varchar(20))
    //Il cliente può stipulare più polizze per cui è stata inserita una lista di polizze


    class Customer
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nchar(16)")]
        public string FiscalCode { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }

        public List<Policy> Policies { get; set; }


    }
}
