namespace WMS_ADIB.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class PurchaseRequisition
{
    [Key]
    public int PRNumber { get; set; }

    [Required]
    public DateTime Date { get; set; }
}

