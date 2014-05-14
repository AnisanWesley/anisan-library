using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContadorTest
{
    [TestClass]
    public class TestClass
    {
        private ContadorTempo _contador;

        [TestInitialize]
        public void Inicialize()
        {
            _contador = new ContadorTempo();
            _contador.Data = new DateTime(2011, 2, 7);
        }

        [TestCleanup]
        public void Clear()
        {
            _contador = null;
        }

        /*Legenda
         * ms - milisegundos
         * s - segundo
         * m - minuto
         * h - hora
         * d - dia
         * M - mes
         */

        [TestMethod]
        public void Mostra_2d_Atraz()
        {
            string result = _contador.Calcula(new DateTime(2011, 2, 5));
            Assert.AreEqual("2 dias atras", result);
        }

        [TestMethod]
        public void Mostra_3d_Atraz()
        {
            string result = _contador.Calcula(new DateTime(2011, 2, 4));
            Assert.AreEqual("3 dias atras", result);
        }

        [TestMethod]
        public void Mostra_1d_Atraz()
        {
            string result = _contador.Calcula(new DateTime(2011, 2, 6));
            Assert.AreEqual("1 dia atras", result);
        }

        [TestMethod]
        public void Mostra_1S_Atraz()
        {
            string result = _contador.Calcula(new DateTime(2011, 1, 31));
            Assert.AreEqual("1 semana atras", result);
        }

        [TestMethod]
        public void Mostra_3S_Atraz()
        {
            string result = _contador.Calcula(new DateTime(2011, 1, 24 - 7));
            Assert.AreEqual("3 semanas atras", result);
        }

        [TestMethod]
        public void Mostra_1S_2d_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-9));
            Assert.AreEqual("1 semana 2 dias atras", result);
        }

        [TestMethod]
        public void Mostra_3S_4d_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-22));
            Assert.AreEqual("3 semanas 1 dia atras", result);
        }

        [TestMethod]
        public void Mostra_1M_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-30));
            Assert.AreEqual("1 mes atras", result);
        }

        [TestMethod]
        public void Mostra_1M_1S_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-37));
            Assert.AreEqual("1 mes 1 semana atras", result);
        }

        [TestMethod]
        public void Mostra_1M_2S__4dAtraz()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-48));
            Assert.AreEqual("1 mes 2 semanas 4 dias atras", result);
        }

        [TestMethod]
        public void Mostra_2M_2d_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-62));
            Assert.AreEqual("2 meses 2 dias atras", result);
        }

        [TestMethod]
        public void Exibe_15h_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddHours(-15));
            Assert.AreEqual("15 horas atras", result);
        }
        [TestMethod]
        public void Exibe_7h_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddHours(-7));
            Assert.AreEqual("7 horas atras", result);
        }
        [TestMethod]
        public void Exibe_1h_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddHours(-7));
            Assert.AreEqual("7 horas atras", result);
        }
        [TestMethod]
        public void Exibe_24h_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddHours(-24));
            Assert.AreEqual("1 dia atras", result);
        }
        [TestMethod]
        public void Exibe_50m_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMinutes(-5));
            Assert.AreEqual("5 minutos atras", result);
        }
        [TestMethod]
        public void Exibe_1m_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMinutes(-1));
            Assert.AreEqual("1 minuto atras", result);
        }
        [TestMethod]
        public void Exibe_1h_14m_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMinutes(-74));
            Assert.AreEqual("1 hora 14 minutos atras", result);
        }
        [TestMethod]
        public void Exibe_4s_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddSeconds(-4));
            Assert.AreEqual("4 segundos atras", result);
        }
        [TestMethod]
        public void Exibe_1s_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddSeconds(-1));
            Assert.AreEqual("1 segundo atras", result);
        }
        [TestMethod]
        public void Exibe_8ms_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMilliseconds(-8));
            Assert.AreEqual("8 milisegundos atras", result);
        }
        [TestMethod]
        public void Exibe_4s_8ms_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMilliseconds(-8).AddSeconds(-4));
            Assert.AreEqual("4 segundos 8 milisegundos atras", result);
        }
        [TestMethod]
        public void Exibe_8h_20m_1s_8ms_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMilliseconds(-8)
                .AddSeconds(-1)
                .AddHours(-8)
                .AddMinutes(-20));
            Assert.AreEqual("8 horas 20 minutos 1 segundo 8 milisegundos atras", result);
        }
        [TestMethod]
        public void Exibe_1h_1s_1ms_Atraz()
        {
            string result = _contador.Calcula(_contador.Data.AddMilliseconds(-1)
                .AddSeconds(-1)
                .AddHours(-1));
            Assert.AreEqual("1 hora 1 segundo 1 milisegundo atras", result);
        }
        [TestMethod]
        public void Exibe_Agora()
        {
            string result = _contador.Calcula(_contador.Data);
            Assert.AreEqual("Agora!", result);
        }
        [TestMethod]
        public void Exibe_1d_afrente()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(1));
            Assert.AreEqual("1 dia a frente", result);
        }
        [TestMethod]
        public void Exibe_8h_20m_1s_8ms_afrente()
        {
            string result = _contador.Calcula(_contador.Data.AddMilliseconds(8)
                .AddSeconds(1)
                .AddHours(8)
                .AddMinutes(20));
            Assert.AreEqual("8 horas 20 minutos 1 segundo 8 milisegundos a frente", result);
        }
        [TestMethod]
        public void Mostra_2M_2d_afrente()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(62));
            Assert.AreEqual("2 meses 2 dias a frente", result);
        }

        [TestMethod]
        public void Mostra_10M_2S_3d_atras()
        {
            string result = _contador.Calcula(_contador.Data.AddDays(-317));
            Assert.AreEqual("10 meses 2 semanas 3 dias atras", result);
        }
    }
}