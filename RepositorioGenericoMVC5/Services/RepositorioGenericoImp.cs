using RepositorioGenericoMVC5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RepositorioGenericoMVC5.Services
{
    public class RepositorioGenericoImp<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public RepositorioGenericoImp(DbContext context)
        {
            _context = context;
        }

        public void Actualizar(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Agregar(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AgregarVarios(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public void Eliminar(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void EliminarVarios(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }        

        public TEntity Obtener(int Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> ObtenerTodos()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }
    }
}