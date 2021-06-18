using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App.Web.Models
{
    public class Cliente
    {
        [Key,Required(ErrorMessage = "Identificacion requerid!."), StringLength(16)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Identificacion")]
        public string Identificador { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El nombre es requerido"), StringLength(128)]
        public string NombreCompleto { get; set; }

    }
}