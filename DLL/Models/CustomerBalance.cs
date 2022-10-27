using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DLL.Models
{
    public class CustomerBalance
    {
        public long CustomerBalanceId { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
