using System;
using System.Collections.Generic;

namespace Tema1App.Models
{
    public enum ConsumerType { PessoaFisica, PessoaJuridica }

    public class Consumer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ConsumerType Type { get; set; } = ConsumerType.PessoaFisica;
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public List<Guid> AccountIds { get; set; } = new List<Guid>();

        public override string ToString() => $"{Name} ({(Type==ConsumerType.PessoaFisica?"CPF":"CNPJ")}) - ID: {Id}";
    }

    public abstract class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string RegistrationNumber { get; set; } = string.Empty;
        public Guid ConsumerId { get; set; }
        public decimal PreviousReading { get; set; }
        public decimal CurrentReading { get; set; }

        public decimal Consumption => CurrentReading - PreviousReading;

        protected abstract decimal Tariff { get; }
        protected abstract decimal TaxRate { get; }

        private const decimal ContribuicaoIluminacao = 9.25m;

        public decimal ValueWithoutTax() => (Consumption * Tariff) + ContribuicaoIluminacao;

        public decimal TaxAmount() => ValueWithoutTax() * TaxRate;

        public decimal TotalValue() => ValueWithoutTax() + TaxAmount();

        public abstract string AccountType { get; }
    }

    public class ResidentialAccount : Account
    {
        protected override decimal Tariff => 0.40m;
        protected override decimal TaxRate => 0.30m;
        public override string AccountType => "Residencial";
    }

    public class CommercialAccount : Account
    {
        protected override decimal Tariff => 0.35m;
        protected override decimal TaxRate => 0.18m;
        public override string AccountType => "Comercial";
    }
}
