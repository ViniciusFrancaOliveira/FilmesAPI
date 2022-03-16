﻿using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace UsuariosApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; } 
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<string> destinatario, string assunto, 
            int usuarioId, string code)
        {
            Destinatario = new List<MailboxAddress>();
            //Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
            Destinatario.AddRange(destinatario.Select(d => MailboxAddress.Parse(d)));
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/ativa?UsuarioId={usuarioId}&CodigoDeAtivacao={code}";
        }
    }
}
