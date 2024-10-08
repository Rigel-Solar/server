﻿using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.Models;

namespace RigelSolarAPI.Repositories;

public class TecnicoRepository : BaseRepository<Tecnico>
{
    public TecnicoRepository(RigelSolarContext context) : base(context)
    {
    }

    public async Task<Tecnico?> VerDadosPorEmail(string email)
    {
        Tecnico? tecnico = await _context
            .Tecnicos
            .Include(x => x.IdUsuarioNavigation)
            .FirstOrDefaultAsync(x => x.IdUsuarioNavigation.Email == email);

        return tecnico;
    }
}
