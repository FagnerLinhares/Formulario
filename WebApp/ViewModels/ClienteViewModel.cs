﻿namespace WebApp.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
    }
}
