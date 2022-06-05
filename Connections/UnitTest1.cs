using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void deve_retornar_verdadeiro_quando_dois_numeros_estiverem_conectados_diretamente()
        {
            Network network = new Network(9);
            network.connect(1, 5);

            var estaConectado = network.query(1, 5);

            Assert.True(estaConectado);
        }

        [Fact]
        public void deve_retornar_falso_quando_dois_numeros_nao_estiverem_conectados_diretamente()
        {
            Network network = new Network(9);
            network.connect(1, 5);

            var estaConectado = network.query(1, 6);

            Assert.False(estaConectado);
        }

        [Fact]
        public void deve_retornar_verdadeiro_quando_dois_numeros_estiverem_conectados_indiretamente()
        {
            Network network = new Network(9);
            network.connect(1, 5);
            network.connect(3, 5);
            network.connect(3, 9);

            var estaConectado = network.query(1, 9);

            Assert.True(estaConectado);
        }

        [Fact]
        public void deve_retornar_verdadeiro_quando_dois_numeros_estiverem_conectados_indiretamente_sem_ordem_de_conexao()
        {
            Network network = new Network(9);
            network.connect(1, 5);
            network.connect(9, 3);
            network.connect(3, 6);
            network.connect(5, 3);

            var estaConectado = network.query(1, 9);

            Assert.True(estaConectado);
        }

        [Fact]
        public void deve_lancar_exececao_se_valor_informado_ao_construtor_for_negativo()
        {
            Action act = () => new Network(-1);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Quantidade de elementos deve no minimo maior que um.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_inicial_for_negativo_ao_conectar()
        {
            var teste = new Network(9);

            Action act = () => teste.connect(-5, 3);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento inicial deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_inicial_for_maior_que_a_quantidade_de_elementos_ao_conectar()
        {
            var teste = new Network(9);

            Action act = () => teste.connect(10, 11);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento inicial deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_final_for_negativo_ao_conectar()
        {
            var teste = new Network(9);

            Action act = () => teste.connect(3, -5);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento final deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_final_for_maior_que_a_quantidade_de_elementos_ao_conectar()
        {
            var teste = new Network(9);

            Action act = () => teste.connect(5, 11);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento final deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_inicial_for_negativo_ao_executar_query()
        {
            var teste = new Network(9);

            Action act = () => teste.query(-5, 3);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento inicial deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_inicial_for_maior_que_a_quantidade_de_elementos_ao_executar_query()
        {
            var teste = new Network(9);

            Action act = () => teste.query(10, 11);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento inicial deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_final_for_negativo_ao_executar_query()
        {
            var teste = new Network(9);

            Action act = () => teste.query(3, -5);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento final deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }

        [Fact]
        public void deve_lancar_exececao_se_final_for_maior_que_a_quantidade_de_elementos_ao_executar_query()
        {
            var teste = new Network(9);

            Action act = () => teste.query(5, 11);

            Exception exception = Assert.Throws<Exception>(act);
            Assert.Equal("Elemento final deve ser positiva e menor que a quantidade de elementos.", exception.Message);
        }
    }
}