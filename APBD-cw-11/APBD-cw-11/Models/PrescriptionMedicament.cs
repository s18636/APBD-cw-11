using System;
using System.Collections.Generic;

namespace Wyklad10Sample.Models
{
    public partial class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

        public virtual Medicament Medicament { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
