using BookManager.Core.Repositories;

namespace BookManager.Core.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IEmailService _emailService;     
        private readonly ILoanRepository _loanRepository;

        public SendEmailService(IEmailService emailService, ILoanRepository loanRepository)
        {
            _emailService = emailService;
            _loanRepository = loanRepository;
        }

        public async Task CreateLoanEmail(int idLoan)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(idLoan);

            var content = $"Empréstimo do livro {loan.Book.Title} com data devolução prevista para {loan.ExpectedDate}." +
                $"\n A data limite para renovação é {DateTime.Now.AddDays(6).ToShortDateString}";

            await _emailService.SendEmailAsync("Abertura de empréstimo de livro", content, loan.Client.Email, loan.Client.Name);
        }

        public async Task FinishLoanEmail(int idLoan)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(idLoan);

            var content = $"Empréstimo do livro {loan.Book.Title} realizado no dia {loan.LoanDate} foi encerrado com sucesso.";

            await _emailService.SendEmailAsync("Empréstimo finalizado", content, loan.Client.Email, loan.Client.Name);
        }

        public async Task RenewLoanEmail(int idLoan)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(idLoan);

            var content = $"O Empréstimo do livro {loan.Book.Title} foi renovando, sua nova data devolução é {loan.ExpectedDate}";

            await _emailService.SendEmailAsync("Renovação do empréstimo", content, loan.Client.Email, loan.Client.Name);
        }
    }
}
