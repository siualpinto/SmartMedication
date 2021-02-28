using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.Entities.Entities
{
    public class Medication
    {
        [Key]
        public Guid PKID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreationDate { get; set; }
    }
}
