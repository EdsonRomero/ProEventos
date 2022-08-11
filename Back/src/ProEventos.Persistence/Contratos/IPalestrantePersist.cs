using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        
        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos = false);


    }
}