using apiLogisticafs.Context;
using apiLogisticafs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiLogisticafs.Operaciones
{
    public class LogEventosDAO
    {
        public LogisticafsContext contexto = new LogisticafsContext();

        public ArraySegment<LogEvento> seleccionarTodos()
        {
            var eventos  = contexto.LogEventos.ToArray<LogEvento>();
            return eventos;
        }

        public bool insertarEventos(string even, string mensaje, int sessionid)
        {
            try
            {
                LogEvento evento = new LogEvento();
                evento.Evento = even;
                evento.Mensaje = mensaje;
                evento.SessionId = sessionid;

                contexto.LogEventos.Add(evento);
                contexto.SaveChanges();
                return true; 
            }
            catch (Exception ex) 
            { 
                return false;
            }
        }
    }
}
