using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            // verifcar se documento está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            // verificar se email está cadastrado.

            if (_repository.DocumentExists(command.PayerEmail))
            {
                AddNotification("Email", "Este email já está em uso");
            }

            // gerar vos

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.PayerEmail);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // gerar entidades

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, 
                command.TotalPaid, address, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), email);

            //Relacionamentos

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // agrupar as validações

            AddNotifications(name, document, email, address, student, subscription, payment);

            //checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");

            // salvar as informações

            _repository.CreateSubscription(student);

            // enciar email de boas vindas

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo a Nezoo Design", "Sua assinatura foi criada com sucesso.");

            // retonar informações

            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}
