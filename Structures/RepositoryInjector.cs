public static class RepositoryInjector<T>
    {
#pragma warning disable 649
        private static PersistOption _option;
#pragma warning restore 649
        public static IRepository<T> GetRepository()
        {

            if (_option == PersistOption.EntityFramework)
            {
                switch (typeof(T).Name)
                {
					//exemplos
                    case "Funcionario": return new FuncionarioEntityRepository() as IRepository<T>;
                    case "Empresa": return new EmpresaEntityRepository() as IRepository<T>;
                    case "Cliente": return new ClienteEntityRepository() as IRepository<T>;
                    case "Venda": return new VendaEntityRepository() as IRepository<T>;
                    
                }
            }

            throw new NotImplementedException("Não tem repositorio de " + typeof(T).Name + " no RepositoryInjector");    
        }

        internal enum PersistOption
        {
            EntityFramework
        }

        public static void InicializeContext()
        {
            new ContextInicializer();
        }

        public static IService<T> GetService()
        {
            switch (typeof(T).Name)
            {
                case "Funcionario": return new FuncionarioService((IRepository<Funcionario>) GetRepository()) as IService<T>;
                case "Empresa": return new EmpresaService((IRepository<Empresa>)GetRepository()) as IService<T>;
                case "Cliente": return new ClienteService((IRepository<Cliente>)GetRepository()) as IService<T>;
                case "Venda": return new Vendaervice((IRepository<Venda>)GetRepository()) as IService<T>;
            }
            throw new NotImplementedException("Não tem service de "+typeof(T).Name+" no RepositoryInjector");    
        }
        public static void LimparBase()
        {
            RepositoryInjector<Funcionario>.GetService().RemoveAll();
            RepositoryInjector<Empresa>.GetService().RemoveAll();
            RepositoryInjector<Cliente>.GetService().RemoveAll();
            RepositoryInjector<Venda>.GetService().RemoveAll();

        }
    }