using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNAD.Entity;

// All the code in this file is included in all platforms.
[Table("Provincias")]
public class clsProvinciasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ProvinciaID { get; set; }
    public string Provincia { get; set; }
    public int PaisID { get; set; }

    //Relaciones
    public virtual clsPaisesBE Paises { get; set; }
    public virtual ICollection<clsCiudadesBE> Ciudades { get; set; }
}