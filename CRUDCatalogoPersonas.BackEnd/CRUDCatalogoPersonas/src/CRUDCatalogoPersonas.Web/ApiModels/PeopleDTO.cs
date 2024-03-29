﻿using System.ComponentModel.DataAnnotations;

namespace CRUDCatalogoPersonas.Web.ApiModels
{
    public class PeopleDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
