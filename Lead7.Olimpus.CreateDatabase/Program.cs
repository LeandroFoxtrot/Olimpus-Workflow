using System;
using System.Collections.Generic;
using System.Configuration;
using Lead7.Olimpus.Domain;
using Lead7.Olimpus.Domain.Business;
using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Persistence.Util;

namespace Lead7.Olimpus.CreateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfgDB = ConfigurationManager.ConnectionStrings["Olimpus_Config"].ToString();
            var s1 = DatabaseUtil.CreateFactory<Modulo>(cfgDB, true).OpenSession();
            //s1.Close();

            var t = s1.BeginTransaction();

            var modulo = new Modulo() {Nome = "Workflow", Descricao = "Workflow"};
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Participantes", Descricao = "Participantes" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Imóvel", Descricao = "Imóvel" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Veículo", Descricao = "Veículo" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Ocorrência", Descricao = "Ocorrência" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "GED", Descricao = "GED" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Checklist", Descricao = "Checklist" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Parecer", Descricao = "Parecer" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Análise de Crédito", Descricao = "Análise de Crédito" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Análise Jurídica", Descricao = "Análise Jurídica" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Contrato", Descricao = "Contrato" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Histórico", Descricao = "Histórico" };
            s1.Save(modulo);

            modulo = new Modulo() { Nome = "Ficha de Aprovação", Descricao = "Ficha de Aprovação" };
            s1.Save(modulo);

            var menu = new Menu()
            {
                Nome = "Configurações",
                Ordem = 1,
                Classe = null,
                EnderecoURL = null,
                Filhos = new Func<List<Menu>>(delegate
                {
                    var result = new List<Menu>
                    {
                        new Menu()
                        {
                            Nome = "Tabelas",
                            Ordem = 1,
                            Classe = "fa fa-table",
                            EnderecoURL = null,
                            Filhos = new Func<List<Menu>>(delegate
                            {
                                var result2 = new List<Menu>
                                {
                                    new Menu()
                                    {
                                        Nome = "Empresas",
                                        Ordem = 1,
                                        Classe = "fa fa-clipboard pull-left",
                                        EnderecoURL = "/Empresa/Index"
                                    },
                                    new Menu()
                                    {
                                        Nome = "Usuários",
                                        Ordem = 2,
                                        Classe = "fa fa-clipboard pull-left",
                                        EnderecoURL = "/Usuario/Index"
                                    }
                                };
                                return result2;
                            }).Invoke()
                        }
                    };
                    return result;
                }).Invoke(),
                Pai = null
            };
            s1.Save(menu);

            var usuario = new Usuario()
            {
                Logon = "admin",
                Nome = "Administrador",
                Senha = "8R8O4DqbOHE0er7v2SOB9w==",
                DadosGerais = new DadosGerais() { DataAdmissao = DateTime.Now, Status = Status.Ativo, Email = null }
            };
            s1.Save(usuario);

            t.Commit();
            //cfgDB = ConfigurationManager.ConnectionStrings["Olimpus_Business"].ToString();
            //s1 = DatabaseUtil.CreateFactory<Participante>(cfgDB, true).OpenSession();
            //s1.Close();
        }
    }
}
