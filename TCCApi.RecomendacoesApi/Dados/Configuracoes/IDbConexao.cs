namespace TCCApi.RecomendacoesApi.Dados.Configuracoes
{
    public interface IDbConexao<T>
    {
        T GetDbInstance();
    }
}
