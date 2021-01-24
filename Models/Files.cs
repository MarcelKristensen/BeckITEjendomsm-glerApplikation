using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeckITEjendomsmæglerApplikation.Models
{
    [Table("Files")]
    public class Files
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int DocumentId { get; set; }

            [MaxLength(100)]
            [DisplayName("Navn")]
            public string Name { get; set; }

            [MaxLength(100)]
            [DisplayName("Fil type")]
            public string FileType { get; set; }

            [MaxLength]
            [DisplayName("Data")]
            public byte[] DataFiles { get; set; }

            [DisplayName("Skabt")]
            public DateTime CreatedOn { get; set; }
    }
}
