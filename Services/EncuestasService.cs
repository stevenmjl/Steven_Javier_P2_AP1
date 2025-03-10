using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Steven_Javier_P2_AP1.DAL;
using Steven_Javier_P2_AP1.Models;

namespace Steven_Javier_P2_AP1.Services;

public class EncuestaService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Encuesta encuesta)
    {
        if (!await Existe(encuesta.Id))
        {
            return await Insertar(encuesta);
        }
        else
        {
            return await Modificar(encuesta);
        }
    }

    private async Task<bool> Existe(int encuestaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Encuestas
            .AnyAsync(e => e.Id == encuestaId);
    }

    private async Task<bool> Insertar(Encuesta encuesta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Encuestas.Add(encuesta);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Encuesta encuesta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(encuesta);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Encuesta?> Buscar(int encuestaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Encuestas
            .FirstOrDefaultAsync(e => e.Id == encuestaId);
    }

    public async Task<bool> Eliminar(int encuestaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Encuestas
            .AsNoTracking()
            .Where(e => e.Id == encuestaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Encuesta>> Listar(Expression<Func<Encuesta, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Encuestas
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}