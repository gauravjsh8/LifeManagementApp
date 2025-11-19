using System;
using System.ComponentModel.DataAnnotations;

namespace LifeManagementApp.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}