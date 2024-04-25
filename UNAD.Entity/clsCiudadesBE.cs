using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNAD.Entity;

// All the code in this file is included in all platforms.
[Table("Ciuades")]
public class clsCiudadesBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CiudadID { get; set; }
    public string Ciudad { get; set; }
    public int ProvinciaID { get; set; }

    //Relaciones
    public virtual clsProvinciasBE Provincias { get; set; }
}
