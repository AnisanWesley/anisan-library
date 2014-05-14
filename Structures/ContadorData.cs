using System;
using System.Text;

namespace ContadorTempo
{
    public class ContadorTempo
    {
        public DateTime Data { get; set; }

        private TimeSpan _tp;

        StringBuilder sb;

        int diasTotais=0;

            int mesesTotais = 0;
        int semanasRestantes = 0;

        public string Calcula(DateTime novaData)
        {
            if (novaData == Data) return "Agora!";
            
            var futuro = novaData > Data;

            SetValues(novaData,futuro);
            
            sb = new StringBuilder();

            CalculaMaisDe24Horas();
            if(diasTotais==0)
            CalculaMenosDe24Horas();

            if (futuro) sb.Append(" a frente");
            else sb.Append(" atras");
            
            return sb.ToString();

        }

        private void AppendDays(int diasTotais)
        {
            if (diasTotais >= 30)
            {
                var meses = diasTotais / 30;
                if (meses == 1) sb.Append("1 mes");
                else sb.Append(String.Format("{0} meses", meses));
            }
        }
        private void SetValues(DateTime novaData,bool futuro)
        {
            if(futuro) _tp  = novaData - Data;
            else _tp = Data - novaData;

            diasTotais = _tp.Days;
            mesesTotais = _tp.Days / 30;
        }

        private void CalculaMaisDe24Horas()
        {
            AppendDays(diasTotais);

            var semanasRestantes = 0;
            if (diasTotais % 30 == 0) semanasRestantes = (diasTotais % 30) / 7;
            else semanasRestantes = (diasTotais % 30) / 7;

            if (semanasRestantes > 0)
            {
                if (diasTotais > 30) sb.Append(" ");
                if (semanasRestantes == 1) sb.Append("1 semana");
                if (semanasRestantes > 1) sb.Append(String.Format("{0} semanas", semanasRestantes));
            }

            var diasRestantes = 0;
            if (semanasRestantes == 0 && mesesTotais == 0)
            {
                diasRestantes = diasTotais;
            }
            else
            {
                if (semanasRestantes > 0 && mesesTotais == 0)
                {
                    diasRestantes = diasTotais % 7;
                }

                if (semanasRestantes == 0 && mesesTotais > 0)
                {
                    diasRestantes = diasTotais % 30;
                }
            }
            if (semanasRestantes > 0 && mesesTotais > 0)
            {
                diasRestantes = (diasTotais % 30) % 7;
            }

            if (diasRestantes > 0)
            {
                if (diasTotais > 30 || semanasRestantes > 0) sb.Append(" ");
                if (diasRestantes == 1) sb.Append("1 dia");
                else sb.Append(String.Format("{0} dias", diasRestantes));
            }
        }

        private void CalculaMenosDe24Horas()
        {
            var horasRestantes = _tp.Hours;
            var minutosRestantes = _tp.Minutes;
            var segundosRestantes = _tp.Seconds;
            var milisRestantes = _tp.Milliseconds;

            if (horasRestantes > 0)
            {
                if (horasRestantes == 1) sb.Append("1 hora");
                else sb.Append(String.Format("{0} horas", horasRestantes));
            }

            if (minutosRestantes > 0)
            {
                if (horasRestantes > 0) sb.Append(" ");
                if (minutosRestantes == 1) sb.Append("1 minuto");
                else sb.Append(String.Format("{0} minutos",minutosRestantes));
            }

            if (segundosRestantes > 0)
            {
                if (horasRestantes > 0 || minutosRestantes > 0) sb.Append(" ");
                if (segundosRestantes == 1) sb.Append("1 segundo");
                else sb.Append(String.Format("{0} segundos", segundosRestantes));
            }

            if (milisRestantes > 0)
            {
                if (horasRestantes > 0||minutosRestantes>0||segundosRestantes>0) sb.Append(" ");
                if (milisRestantes == 1) sb.Append("1 milisegundo");
                else sb.Append(String.Format("{0} milisegundos", milisRestantes));
            }

        }
    }
}