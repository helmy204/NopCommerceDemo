using Nop.Core;
using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Nop.Data
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        #endregion Methods

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }



        public void Insert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Table
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<T> TableNoTracking
        {
            get { throw new NotImplementedException(); }
        }

        #region Properties

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        //-->>

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        #endregion Properties
    }
}
