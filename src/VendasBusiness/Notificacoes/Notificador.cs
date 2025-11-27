
namespace VendasBusiness.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        void INotificador.Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        List<Notificacao> INotificador.ObterNotificacoes()
        {
            return _notificacoes;
        }
    }
}
