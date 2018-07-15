using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGenericoMVC5.Services.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        void Agregar(TEntity entity);
        void AgregarVarios(IEnumerable<TEntity> entities);

        void Eliminar(TEntity entity);
        void EliminarVarios(IEnumerable<TEntity> entities);

        TEntity Obtener(int Id);
        IEnumerable<TEntity> ObtenerTodos();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        void Actualizar(TEntity entity);

        void Guardar();
    }
}
