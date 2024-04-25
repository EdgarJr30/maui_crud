using Microsoft.EntityFrameworkCore;
using UNAD.DAL;
using UNAD.Entity;

namespace UNAD.Core;

// All the code in this file is included in all platforms.
public class Manager
{
    Context db;
    string Guardado = "Registro Guardado Correctamente.";
    string Modificado = "Registro Modificado Correctamente.";
    string Eliminado = "Registro Eliminado Correctamente.";


    public  Manager()
    {
        db = new DAL.Context();
    }

    #region Paises

    public string PaisesCreate(string Pais)
    {
        try
        {
            db = new Context();
            int ID = (db.clsPaisesBE.Count() == 0 ? 100000 : db.clsPaisesBE.Max(x => x.PaisID)) + 1;
            db.clsPaisesBE.Add(new clsPaisesBE { PaisID = ID, Pais = Pais});
            db.SaveChanges();
            return Guardado;
        }
        catch(Exception ex) {
            return ex.Message;
        }
    }

    public string PaisesUpdate(int PaisID, string Pais)
    {
        try
        {
            var row = db.clsPaisesBE.Where(x => x.PaisID == PaisID).FirstOrDefault();
            if (row != null)
            {
                row.Pais = Pais;
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Modificado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string PaisesDeleteGetByPaisID(int PaisID)
    {
        try
        {
            var row = db.clsPaisesBE.Where(x => x.PaisID == PaisID).FirstOrDefault();
            if (row != null)
            {
                db.Entry(row).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return Eliminado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public clsPaisesBE PaisesGetByPaisID(int PaisID)
    {
        try
        {
            return db.clsPaisesBE.Where(x => x.PaisID == PaisID).FirstOrDefault(); 
        }
        catch 
        {
            return new clsPaisesBE();
        }
    }

    public List<clsPaisesBE> PaisesGet()
    {
        try
        {
            return db.clsPaisesBE.ToList();
        }
        catch
        {
            return new List<clsPaisesBE>();
        }
    }

    #endregion

    #region Provincias

    public string ProvinciasCreate(string Provincia, int PaisID)
    {
        try
        {
            int ID = (db.clsProvinciasBE.Count() == 0 ? 100000 : db.clsProvinciasBE.Max(x => x.ProvinciaID)) + 1;
            db.clsProvinciasBE.Add(new clsProvinciasBE { ProvinciaID = ID, Provincia = Provincia, PaisID = PaisID });
            db.SaveChanges();
            return Guardado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string ProvinciasUpdate(int ProvinciaID, string Provincia, int PaisID)
    {
        try
        {
            var row = db.clsProvinciasBE.Where(x => x.ProvinciaID == ProvinciaID).FirstOrDefault();
            if (row != null)
            {
                row.Provincia = Provincia;
                row.PaisID = PaisID;
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Modificado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string ProvinciasDeleteGetByProvinciaID(int ProvinciaID)
    {
        try
        {
            var row = db.clsProvinciasBE.Where(x => x.ProvinciaID == ProvinciaID).FirstOrDefault();
            if (row != null)
            {
                db.Entry(row).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return Eliminado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public clsProvinciasBE ProvinciasGetByProvinciaID(int ProvinciaID)
    {
        try
        {
            return db.clsProvinciasBE.Where(x => x.ProvinciaID == ProvinciaID).FirstOrDefault();
        }
        catch
        {
            return new clsProvinciasBE();
        }
    }

    public List<clsProvinciasBE> ProvinciasGet()
    {
        try
        {
            return db.clsProvinciasBE.ToList();
        }
        catch
        {
            return new List<clsProvinciasBE>();
        }
    }

    #endregion

    #region Ciudades

    public string CiudadesCreate(string Ciudad, int ProvinciaID)
    {
        try
        {
            int ID = (db.clsCiudadesBE.Count() == 0 ? 100000 : db.clsCiudadesBE.Max(x => x.CiudadID)) + 1;
            db.clsCiudadesBE.Add(new clsCiudadesBE { CiudadID = ID, Ciudad = Ciudad, ProvinciaID = ProvinciaID });
            db.SaveChanges();
            return Guardado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string CiudadesUpdate(int CiudadID, string Ciudad, int ProvinciaID)
    {
        try
        {
            var row = db.clsCiudadesBE.Where(x => x.CiudadID == CiudadID).FirstOrDefault();
            if (row != null)
            {
                row.Ciudad = Ciudad;
                row.ProvinciaID = ProvinciaID;
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Modificado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string CiudadesDeleteGetByCiudadID(int CiudadID)
    {
        try
        {
            var row = db.clsCiudadesBE.Where(x => x.CiudadID == CiudadID).FirstOrDefault();
            if (row != null)
            {
                db.Entry(row).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return Eliminado;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public clsCiudadesBE CiudadesGetByCiudadID(int CiudadID)
    {
        try
        {
            return db.clsCiudadesBE.Where(x => x.CiudadID == CiudadID).FirstOrDefault();
        }
        catch
        {
            return new clsCiudadesBE();
        }
    }

    public List<clsCiudadesBE> CiudadesGet()
    {
        try
        {
            return db.clsCiudadesBE.ToList();
        }
        catch
        {
            return new List<clsCiudadesBE>();
        }
    }

    #endregion

}


