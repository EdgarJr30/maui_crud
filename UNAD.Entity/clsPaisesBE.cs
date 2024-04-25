using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNAD.Entity;

// All the code in this file is included in all platforms.
[Table("Paises")]
public class clsPaisesBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PaisID { get; set; }
    public string Pais { get; set; }

    //Relaciones
    public virtual ICollection<clsProvinciasBE> Provincias { get; set; }
}


