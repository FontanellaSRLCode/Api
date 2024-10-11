using apiLogisticafs.Context;
using apiLogisticafs.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiLogisticafs.Operaciones
{
    public class RemitenteProductoDestinatarioDAO
    {
        public LogisticafsContext contexto = new LogisticafsContext();

        public List<RemitenteProductoDestinatario> seleccionarEnviosPorFechas(DateTime fechaInicio, DateTime fechaFin)//devuelve todos los remitos segun rango de fechas
        {
            var query = from r in contexto.Remitentes
                        join d in contexto.Destinatarios on r.IdEnvio equals d.DesId
                        join p in contexto.Productos on d.DesId equals p.ProDesId
                        where r.FechaCarga >= fechaInicio
                              && r.FechaCarga <= fechaFin
                              && r.Estado == 1
                        select new RemitenteProductoDestinatario
                        {
                            IdEnvio = r.IdEnvio,
                            RemitenteNombre = r.RemitenteNombre,
                            Fecha = r.Fecha,
                            EmailRemitente = r.EmailRemitente,
                            TelefonoRemitente = r.TelefonoRemitente,
                            InfoAdicional = r.InfoAdicional,
                            Estado = r.Estado,
                            RangoHorario = r.RangoHorario,
                            NombreEntrega = r.NombreEntrega,
                            CelularEntrega = r.CelularEntrega,
                            DireccionRetiro = r.DireccionRetiro,
                            PisoEntrega = r.ProvinciaEntrega,
                            DeptoEntrega = r.DeptoEntrega,
                            LocalidadEntrega = r.LocalidadEntrega,
                            ProvinciaEntrega = r.ProvinciaEntrega,
                            FechaCarga = r.FechaCarga,
                            DesNombre = d.DesNombre,
                            DesCelular = d.DesCelular,
                            DesDireccion = d.DesDireccion,
                            DesTransporte = d.DesTransporte,
                            InfoAdicionalDest = d.InfoAdicionalDest,
                            FechaEntregaDest = d.FechaEntregaDest,
                            RangoHorarioDest = d.RangoHorarioDest,
                            PisoDest = d.PisoDest,
                            DeptoDest = d.DeptoDest,
                            LocalidadDest = d.LocalidadDest,
                            ProvinciaDest = d.ProvinciaDest,
                            ProDetalle = p.ProDetalle,
                            ProCantidad = p.ProCantidad,
                            ProEmbalaje = p.ProEmbalaje,
                        };
            return query.ToList();
        }//
        public List<RemitenteProductoDestinatario> seleccionarIDRemito(int idRemito)// devuelve un remito segun su id
        {
            var query = from r in contexto.Remitentes
                        join d in contexto.Destinatarios on r.IdEnvio equals d.DesId
                        join p in contexto.Productos on d.DesId equals p.ProDesId
                        where r.IdEnvio == idRemito
                              && r.Estado == 1
                        select new RemitenteProductoDestinatario
                        {
                            IdEnvio = r.IdEnvio,
                            RemitenteNombre = r.RemitenteNombre,
                            Fecha = r.Fecha,
                            EmailRemitente = r.EmailRemitente,
                            TelefonoRemitente = r.TelefonoRemitente,
                            InfoAdicional = r.InfoAdicional,
                            Estado = r.Estado,
                            RangoHorario = r.RangoHorario,
                            NombreEntrega = r.NombreEntrega,
                            CelularEntrega = r.CelularEntrega,
                            DireccionRetiro = r.DireccionRetiro,
                            PisoEntrega = r.ProvinciaEntrega,
                            DeptoEntrega = r.DeptoEntrega,
                            LocalidadEntrega = r.LocalidadEntrega,
                            ProvinciaEntrega = r.ProvinciaEntrega,
                            FechaCarga = r.FechaCarga,
                            DesNombre = d.DesNombre,
                            DesCelular = d.DesCelular,
                            DesDireccion = d.DesDireccion,
                            DesTransporte = d.DesTransporte,
                            InfoAdicionalDest = d.InfoAdicionalDest,
                            FechaEntregaDest = d.FechaEntregaDest,
                            RangoHorarioDest = d.RangoHorarioDest,
                            PisoDest = d.PisoDest,
                            DeptoDest = d.DeptoDest,
                            LocalidadDest = d.LocalidadDest,
                            ProvinciaDest = d.ProvinciaDest,
                            ProDetalle = p.ProDetalle,
                            ProCantidad = p.ProCantidad,
                            ProEmbalaje = p.ProEmbalaje,
                        };
            return query.ToList();
        }
        public int insertarRemitente(string remitenteNombre, DateOnly fecha, string emailRemitente,
                                     string telefonoRemitente, string infoAdic, string rangoEntrega,
                                     string nombreEntrega, string celuEntrega, string direcRetiro,
                                     string pisoEntrega, string deptoEntrega, string localEntrega,
                                     string provincEntrega)
        {
            //inserta Remitente y devuelve el ID generado por la DB ,
            //si quiero solo true o false cambiar el Int por Bool y cambiar los return
            try
            {
                Remitente remitente = new Remitente();
                LogEvento evento = new LogEvento();
                remitente.RemitenteNombre = remitenteNombre;
                remitente.EmailRemitente = emailRemitente;
                remitente.Fecha = fecha;
                remitente.EmailRemitente = emailRemitente;
                remitente.TelefonoRemitente = telefonoRemitente;
                remitente.InfoAdicional = infoAdic;
                remitente.RangoHorario = rangoEntrega;
                remitente.NombreEntrega = nombreEntrega;
                remitente.CelularEntrega = celuEntrega;
                remitente.DireccionRetiro = direcRetiro;
                remitente.PisoEntrega = pisoEntrega;
                remitente.DeptoEntrega = deptoEntrega;
                remitente.LocalidadEntrega = localEntrega;
                remitente.ProvinciaEntrega = provincEntrega;

                contexto.Remitentes.Add(remitente);
                contexto.SaveChanges();

                evento.Evento = "INSERTAR REMITENTE";
                evento.Mensaje = "Insercion de remito OK";
                evento.SessionId = 1003;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();


                return remitente.IdEnvio;
            }
            catch (Exception ex)
            {
                LogEvento evento = new LogEvento();
                evento.Evento = "INSERTAR REMITENTE";
                evento.Mensaje = ex.Message;
                evento.SessionId = 1003;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return -1;
            }
        }//retorna ID
        public int insertarDestinatario(int idRemitente, string desNombre, string desCelular, string desDireccion,
                                        string desTransporte, string desInfoAdic, string fechaEntrega,
                                        string rangoHorarioEntrega, string desPiso, string desDepto,
                                        string desLocalidad, string desProvincia)
        {
            //inserta destinatario y devuelve el ID generado por la DB ,
            //si quiero solo true o false cambiar el Int por Bool y cambiar los return
            try
            {
                Destinatario dest = new Destinatario();
                LogEvento evento = new LogEvento();
                dest.DesRemId = idRemitente;
                dest.DesNombre = desNombre;
                dest.DesCelular = desCelular;
                dest.DesDireccion = desDireccion;
                dest.DesTransporte = desTransporte;
                dest.InfoAdicionalDest = desInfoAdic;
                dest.FechaEntregaDest = fechaEntrega;
                dest.RangoHorarioDest = rangoHorarioEntrega;
                dest.PisoDest = desPiso;
                dest.DeptoDest = desDepto;
                dest.LocalidadDest = desLocalidad;
                dest.ProvinciaDest = desProvincia;


                contexto.Destinatarios.Add(dest);
                contexto.SaveChanges();

                evento.Evento = "INSERTAR DESTINATARIO";
                evento.Mensaje = "Insercion de destinatario OK";
                evento.SessionId = 1004;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();


                return dest.DesId;
            }
            catch (Exception ex)
            {
                LogEvento evento = new LogEvento();
                evento.Evento = "INSERTAR DESTINATARO";
                evento.Mensaje = ex.Message;
                evento.SessionId = 1004;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return -1;
            }
        }//retorna ID

        public bool insertarProductos(int idRemitente, int idDest, string prodDetalle, int prodCantidad,
                                     string prodEmbalaje, string prodDimencion)
        {
            //inserta productos y devuelve true o false ,

            try
            {
                Producto prod = new Producto();
                LogEvento evento = new LogEvento();
                prod.ProRemId = idRemitente;
                prod.ProDesId = idDest;
                prod.ProDetalle = prodDetalle;
                prod.ProCantidad = prodCantidad;
                prod.ProEmbalaje = prodEmbalaje;
                prod.ProDimensiones = prodDimencion;

                contexto.Productos.Add(prod);
                contexto.SaveChanges();

                evento.Evento = "INSERTAR PRODUCTOS";
                evento.Mensaje = "Insercion de productos OK";
                evento.SessionId = 1005;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();


                return true;
            }
            catch (Exception ex)
            {
                LogEvento evento = new LogEvento();
                evento.Evento = "INSERTAR DESTINATARO";
                evento.Mensaje = ex.Message;
                evento.SessionId = 1004;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return false;
            }
        }//retorna True o False

        public bool modificarEstado(int idRemito)
        {
            try
            {
                LogEvento evento = new LogEvento();
                var remito = contexto.Remitentes.Where(a => a.IdEnvio == idRemito).FirstOrDefault();

                if (remito != null)
                {
                    remito.Estado = 1;
                    contexto.SaveChanges();
                    //cargar el log
                    evento.Evento = "MODIFICAR ESTADO DEL REMITENTE";
                    evento.Mensaje = "Estado actualizado correctamente, Remitente: " + idRemito;
                    evento.SessionId = 1006;

                    contexto.LogEventos.Add(evento);
                    contexto.SaveChanges();

                    return true;
                }
                else
                {
                    //cargar el log
                    evento.Evento = "MODIFICAR ESTADO DEL REMITENTE";
                    evento.Mensaje = "No se encuentra el Remiente: " + idRemito;
                    evento.SessionId = 1006;

                    contexto.LogEventos.Add(evento);
                    contexto.SaveChanges();
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogEvento evento = new LogEvento();
                evento.Evento = "MODIFICAR ESTADO DEL REMITENTE";
                evento.Mensaje = "Fallo la actualizacion del Estado del Remitente: " + idRemito;
                evento.SessionId = 1006;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return false;
            }
        }
    }
}


