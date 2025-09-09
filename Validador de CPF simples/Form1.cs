namespace Validador_de_CPF_simples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool Valida(string cpf)
        {
            // Vetores de multiplicadores para o cálculo dos dígitos verificadores
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Limpa o CPF, removendo espaços, pontos e traços
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            // Calcula o primeiro dígito verificador
            for (int i = 0; i < multiplicador1.Length; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            tempCpf += primeiroDigito;
            soma = 0;

            // Calcula o segundo dígito verificador
            for (int i = 0; i < multiplicador2.Length; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            string digitosCalculados = primeiroDigito.ToString() + segundoDigito.ToString();

            return cpf.EndsWith(digitosCalculados);
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Msk_CPF.Text = "";
            Lbl_Resultado.Text = "";
        }

        private void Btn_Validar_Click(object sender, EventArgs e)
        {
            bool validarCPF = false;
            validarCPF = Valida(Msk_CPF.Text);
            if (validarCPF)
            {
                Lbl_Resultado.ForeColor = Color.Green;
                Lbl_Resultado.Text = "CPF Válido!";
            }
            else
            {
                Lbl_Resultado.ForeColor = Color.Red;
                Lbl_Resultado.Text = "CPF Inválido!";
            }
        }

        private void Msk_CPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
