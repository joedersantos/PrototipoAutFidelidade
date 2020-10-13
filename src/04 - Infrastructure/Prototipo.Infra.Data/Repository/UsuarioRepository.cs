using Microsoft.EntityFrameworkCore;
using Prototipo.Domain.Models;
using Prototipo.Domain.Repository;
using Prototipo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FidelidadeContext context;

        public UsuarioRepository(FidelidadeContext context)
        {
            this.context = context;
        }
        public async Task<Usuario> Inserir(Usuario model)
        {
            if (model == null) throw new ArgumentNullException("model");

            if (await EmailCadastrado(model.Email)) return null;

            var result = await context.Usuarios.AddAsync(model);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> EmailCadastrado(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("email");

            return await context.Usuarios.Where(o => o.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).AnyAsync();
        }

        public async Task<Usuario> BuscarPorEmailSenha(string email, string senha)
        {
            return await context.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();            
        }

        public async Task<Usuario> BuscarPorId(Guid id)
        {
            return await context.Usuarios.Include(c => c.EnderecosEntrega)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> AtaulizarEndereco(Usuario model)
        {            
            var entity = context.Usuarios.Update(model).Entity;
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<Usuario> Inserir(Endereco model)
        {
            if (model == null) throw new ArgumentNullException("model");

            await context.Enderecos.AddAsync(model);
            await context.SaveChangesAsync();

            return await context.Usuarios.Where(x => x.Id == model.UsuarioId).FirstOrDefaultAsync();
        }
    }
}
