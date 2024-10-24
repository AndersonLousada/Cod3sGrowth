using Cod3rsGrowth.DOMINIO.Carros;

namespace Cod3rsGrowth.TESTE.RepositorioMock
{
    internal sealed class Singleton
    {
        private static Singleton _instance = null;

        private static int _id = 3;

        private static List<Carro> _carros = new();
        public Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }

        public List<Carro> ObterCarros()
        {
            return _carros;
        }

        public int ObterNovoId()
        {
            return ++_id;
        }
    }
}