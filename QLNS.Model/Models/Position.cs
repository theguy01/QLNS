﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Model.Models
{
    [Table("Position")]
    public class Position : Abstracts.Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //Navigation Properties
        public virtual IEnumerable<Employee> Employees { get; set; }

        public virtual IEnumerable<WorkingProcess> WorkingProcesses { get; set; }
    }
}