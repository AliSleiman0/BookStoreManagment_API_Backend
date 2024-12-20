﻿namespace BookStoreManagement.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("purchase")]
    public class Purchase
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [Column("purchase_date"), Required]
        public DateTime PurchaseDate { get; set; }

        [Column("book_id"), Range(1, int.MaxValue, ErrorMessage = "BookId must be a positive integer.")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        [Column("book_price"), Required, Range(0.01, double.MaxValue, ErrorMessage = "Book price must be greater than zero.")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Bookprice { get; set; }


        [Column("quantity"), Required, Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [NotMapped] // save data storagr, byenamalla calculate when needed.
        public decimal TotalPrice => Bookprice * Quantity;

        //add quantity and book id here  ----done
        //delete PurchaseDetails -done
        //Add proper annotations (see other tables)--done
    }
}