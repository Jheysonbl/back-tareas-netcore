using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba_to_do_api.Models;

public partial class Task
{
    [Key]
    public int IdTask { get; set; }

    public string? Task1 { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}