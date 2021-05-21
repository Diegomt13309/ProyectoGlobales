using Lesconario.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LESCOnario.Services
{
    public class ProductDataBase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ProductDataBase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Profesor).Name))
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Profesor)).ConfigureAwait(false);

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CursoxProfe).Name))
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(CursoxProfe)).ConfigureAwait(false);

                initialized = true;
            }
        }

        public Task<List<Profesor>> getProfesor()
        {
            return Database.Table<Profesor>().ToListAsync();
        }

        public Task<List<CursoxProfe>> getCursos()
        {
            return Database.Table<CursoxProfe>().ToListAsync();
        }

        public Task<int> saveProduct(Profesor product)
        {
            bool aux = false;
            var list = getProfesor().Result;
            if (list != null && list.Count > 0)
            {
                foreach (var prod in list)
                {
                    if (prod.id == product.id)
                    {
                        aux = true;
                    }
                }
            }
            else
            {
                return Database.InsertAsync(product); ;
            }

            if (aux == true)
            {
                return Database.UpdateAsync(product);
            }
            else
            {
                return Database.InsertAsync(product); ;
            }

        }

        public int saveCurso(CursoxProfe product)
        {
            bool aux = false;
            var list = getCursos().Result;
            if (list != null && list.Count > 0)
            {
                foreach (var prod in list)
                {
                    if(prod.nombre == product.nombre && prod.id == product.id)
                    {
                        aux = true;
                    }
                }
            }else{
                Database.InsertAsync(product);
                return 1;
            }

            if (aux == true)
            {
                Database.UpdateAsync(product);
                return 2;
            }
            else
            {
                Database.InsertAsync(product);
                return 1;
            }
        }

        public Task<int> deleteProduct(Profesor product)
        {
            return Database.DeleteAsync(product);
        }

        public Task<int> deleteCurso(CursoxProfe product)
        {
            return Database.DeleteAsync(product);
        }

        public bool findProfe(Profesor product)
        {
            bool aux = false;
            var list = getProfesor().Result;
            if (list != null && list.Count > 0)
            {
                foreach (var prod in list)
                {
                    if (prod.id == product.id)
                    {
                        aux = true;
                    }
                }
            }
            return aux;
        }

    }
}
