﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WbApi.Models
{
    public class BankAccount
    {
         [Key]
        public int BankAccountID { get; set; }
        [Column(TypeName ="nvarchar(20)")]
        [Required]
        public string AccountNumber { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string AccountHolder{ get; set; }
        [Required]
       
        public int BankID { get; set;}
        [Column(TypeName ="nvarchar(20)")]
        [Required]
        public string IFSC { get; set;}
    }
}
