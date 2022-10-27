using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DLL.Models
{
    public class TransactionHistory
    {
        public int TransactionHistoryId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Amount { get; set; }
    }
}
